using AutoMapper;
using MedEquipCentral.BL.Contracts.DTO;
using MedEquipCentral.BL.Contracts.IService;
using MedEquipCentral.DA.Contracts;
using MedEquipCentral.DA.Contracts.Model;
using MedEquipCentral.DA.Contracts.Shared;
using RabbitMQPublisher;
using RabbitMQConsumer;
using System.Diagnostics;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using System.Threading.Channels;

namespace MedEquipCentral.BL.Service
{
    public class EquipmentService : IEquipmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        static IConnection conn;
        static IModel channel;

        public EquipmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<EquipmentDto> Add(EquipmentDto equipmentDto)
        {
            var equipmentEntity = _mapper.Map<Equipment>(equipmentDto);
            equipmentEntity.Company = null;
            equipmentEntity.Type = null;
            var equipment = await _unitOfWork.GetEquipmentRepository().Add(equipmentEntity);
            await _unitOfWork.Save();
            return _mapper.Map<EquipmentDto>(equipment.Entity);
        }

        public List<EquipmentDto> GetAll()
        {
            var equipment = _unitOfWork.GetEquipmentRepository().GetAll();
            return _mapper.Map<List<EquipmentDto>>(equipment);
        }

        public async Task<List<EquipmentDto>> GetAllForCompany(int companyId)
        {
            var equipment = await _unitOfWork.GetEquipmentRepository().GetAllForCompany(companyId);
            return _mapper.Map<List<EquipmentDto>>(equipment);
        }

        public async Task<PagedResult<EquipmentDto>> Search(EquipmentPagedIn dataIn)
        {
            var result = await _unitOfWork.GetEquipmentRepository().GetAllBySearch(dataIn);
            List<EquipmentDto> resultDto = _mapper.Map<List<EquipmentDto>>(result);

            return new PagedResult<EquipmentDto>
            {
                Result = resultDto,
                Count = resultDto.Count
            };
        }

        public async Task<EquipmentDto> Update(EquipmentDto equipmentDto)
        {
            var equipmentEntity = _mapper.Map<Equipment>(equipmentDto);
            equipmentEntity.Company = null;
            equipmentEntity.Type = null;
            var equipment = _unitOfWork.GetEquipmentRepository().Update(equipmentEntity);
            await _unitOfWork.Save();
            return _mapper.Map<EquipmentDto>(equipment);
        }

        public async Task<bool> Delete(int equipmentId)
        {
            var appointments = await _unitOfWork.GetAppointmentRepository().GetAllForEquipment(equipmentId);
            if(appointments.Count == 0) //Prosiriti ovu logiku kada se doda da rezervacija nije pokupljena
            {
                var isDeleted = await _unitOfWork.GetEquipmentRepository().Delete(equipmentId);
                if (isDeleted)
                {
                    await _unitOfWork.Save();
                    return true;
                }
            }

            return false;
        }

        public async Task<EquipmentDto> GetById(int equipmentId)
        {
            var equipment = await _unitOfWork.GetEquipmentRepository().GetByIdAsync(equipmentId);
            var equipmentDto = _mapper.Map<EquipmentDto>(equipment);

            return equipmentDto;
        }

        public async Task<List<EquipmentDto>> ReduceQuantity(int appointmentId)
        {
            var appointment = await _unitOfWork.GetAppointmentRepository().GetById(appointmentId);
            var result = new List<Equipment>();
            foreach (var equipmentId in appointment.EquipmentIds)
            {
                var equipment = await _unitOfWork.GetEquipmentRepository().GetByIdAsync(equipmentId);
                equipment.Quantity -= 1;
                equipment.Reserved -= 1;

                if (!result.Contains(equipment))
                {
                    result.Add(equipment);
                    _unitOfWork.GetEquipmentRepository().Update(equipment);
                }         
            }
            await _unitOfWork.Save();

            return _mapper.Map<List<EquipmentDto>>(result);
        }

        public async Task<bool> StartDelivery()
        {
            try
            {
                var appPath = AppContext.BaseDirectory;
                Process.Start("RabbitMQPublisher.exe");


            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<string> GetMessage()
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                HostName = "localhost",
                VirtualHost = "/",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            List<string> coordinates = new List<string>();
            using (var conn = factory.CreateConnection())
            using (var channel = conn.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (sender, e) =>
                {
                    string message = Encoding.UTF8.GetString(e.Body.ToArray());

                    coordinates.Add(message);
                    Console.WriteLine($"Received: {message}");

                    channel.BasicAck(e.DeliveryTag, false);
                };

                var consumerTag = channel.BasicConsume("my.queue1", false, consumer);

                // Wait for a certain period (adjust timeout as needed)
                Task.Delay(10).Wait();
            }

            return coordinates;
        }

    }
}
