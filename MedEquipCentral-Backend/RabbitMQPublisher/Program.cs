using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMQPublisher
{

    public class Program
    {
        public static void Main()
        {
            List<(double Latitude, double Longitude)> coordinates = new List<(double Latitude, double Longitude)>
        {
            (44.8184, 20.3091),
            (44.84120526315789, 20.284247368421052),
            (44.86401052631579, 20.259394736842108),
            (44.88681578947368, 20.23454210526316),
            (44.90962105263158, 20.20968947368421),
            (44.93242631578947, 20.184836842105263),
            (44.95523157894737, 20.159984210526318),
            (44.97803684210526, 20.13513157894737),
            (45.00084210526315, 20.11027894736842),
            (45.02364736842105, 20.085426315789473),
            (45.046452631578944, 20.060573684210528),
            (45.06925789473684, 20.03572105263158),
            (45.092063157894735, 20.01086842105263),
            (45.11486842105263, 19.986015789473683),
            (45.137673684210526, 19.961163157894738),
            (45.16047894736842, 19.93631052631579),
            (45.18328421052632, 19.91145789473684),
            (45.20608947368421, 19.886605263157893),
            (45.22889473684211, 19.86175263157895),
            (45.2517, 19.8369)
        };

            IConnection conn;
            IModel channel;

            ConnectionFactory factory = new ConnectionFactory();
            factory.HostName = "localhost";
            factory.VirtualHost = "/";
            factory.Port = 5672;
            factory.UserName = "guest";
            factory.Password = "guest";

            conn = factory.CreateConnection();
            channel = conn.CreateModel();

            channel.ExchangeDeclare(
                "ex.fanout",
                ExchangeType.Fanout,
                true,
                false,
                null);

            channel.QueueDeclare(
                "my.queue1",
                true,
                false,
                false,
                null);

            channel.QueueBind("my.queue1", "ex.fanout", "");


            foreach (var coordinate in coordinates)
            {
                
            channel.BasicPublish(
                "ex.fanout",
                "",
                null,
                Encoding.UTF8.GetBytes($"{coordinate.Latitude}/{coordinate.Longitude}")
                ) ;
            }



            Console.WriteLine("Press a key to exit.");
            Console.ReadKey();

            channel.QueueDelete("my.queue1");
            channel.ExchangeDelete("ex.fanout");

            channel.Close();
            conn.Close();
        }
    }
}
