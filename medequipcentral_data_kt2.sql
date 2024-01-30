-- Inserting Location Data
INSERT INTO medequipcentral."Locations" ("Id", "Latitude", "Longitude", "Street", "StreetNumber", "City", "Zip", "Country") VALUES (1, -16.494491909692428, -54.85865280037311, 'Willow St', '324', 'Rivertown', '84117', 'USA');
INSERT INTO medequipcentral."Locations" ("Id", "Latitude", "Longitude", "Street", "StreetNumber", "City", "Zip", "Country") VALUES (2, 83.11219833260395, 171.476248585794, 'Elm St', '441', 'Sunnyvale', '67056', 'USA');
INSERT INTO medequipcentral."Locations" ("Id", "Latitude", "Longitude", "Street", "StreetNumber", "City", "Zip", "Country") VALUES (3, 64.15899754863645, 144.61324581477976, 'Cherry St', '8', 'Mapleton', '94986', 'USA');
INSERT INTO medequipcentral."Locations" ("Id", "Latitude", "Longitude", "Street", "StreetNumber", "City", "Zip", "Country") VALUES (4, 39.14170596559171, 0.11546760330148231, 'Elm St', '16', 'Fairview', '69992', 'USA');
INSERT INTO medequipcentral."Locations" ("Id", "Latitude", "Longitude", "Street", "StreetNumber", "City", "Zip", "Country") VALUES (5, 42.23453640891654, 124.87621066438311, 'Oak St', '266', 'Brookside', '39248', 'USA');
INSERT INTO medequipcentral."Locations" ("Id", "Latitude", "Longitude", "Street", "StreetNumber", "City", "Zip", "Country") VALUES (6, 50.32212936552577, -7.449984003394775, 'Main St', '257', 'Oakdale', '16008', 'USA');
INSERT INTO medequipcentral."Locations" ("Id", "Latitude", "Longitude", "Street", "StreetNumber", "City", "Zip", "Country") VALUES (7, 46.10856780118493, -52.60445157901144, 'Pine St', '261', 'Brookside', '56372', 'USA');
INSERT INTO medequipcentral."Locations" ("Id", "Latitude", "Longitude", "Street", "StreetNumber", "City", "Zip", "Country") VALUES (8, 42.82083759538827, -26.107669860783176, 'Elm St', '12', 'Sunnyvale', '87070', 'USA');
INSERT INTO medequipcentral."Locations" ("Id", "Latitude", "Longitude", "Street", "StreetNumber", "City", "Zip", "Country") VALUES (9, -56.437329390657375, -51.47927720599364, 'Elm St', '303', 'Pleasantville', '12466', 'USA');
INSERT INTO medequipcentral."Locations" ("Id", "Latitude", "Longitude", "Street", "StreetNumber", "City", "Zip", "Country") VALUES (10, 9.351150838273256, -21.00925581060511, 'Park St', '440', 'Mapleton', '63458', 'USA');
ALTER SEQUENCE medequipcentral."Locations_Id_seq" RESTART WITH 11;

-- Inserting Company Data
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating", "StartTime", "EndTime") VALUES (1, 'WellnessTools', 'Enhancing patient care with top-notch equipment.', 1,  3.52, '07:00:00', '17:00:00');
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating", "StartTime", "EndTime") VALUES (2, 'WellnessTools', 'Committed to delivering superior medical devices.', 2, 3.83, '07:00:00', '17:00:00');
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating", "StartTime", "EndTime") VALUES (3, 'WellnessTools', 'Enhancing patient care with top-notch equipment.', 3,  3.51, '07:00:00', '17:00:00');
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating", "StartTime", "EndTime") VALUES (4, 'ThriveEquip', 'Dedicated to the advancement of medical technology.', 4, 3.40, '07:00:00', '17:00:00');
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating", "StartTime", "EndTime") VALUES (5, 'LifeSolutions', 'Revolutionizing patient care through innovation.', 5,  2.91, '07:00:00', '17:00:00');
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating", "StartTime", "EndTime") VALUES (6, 'ThriveEquip', 'Committed to delivering superior medical devices.', 6,   3.62, '07:00:00', '17:00:00');
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating", "StartTime", "EndTime") VALUES (7, 'HealWell', 'Innovative medical solutions for modern healthcare.', 7,    1.54, '07:00:00', '17:00:00');
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating", "StartTime", "EndTime") VALUES (8, 'HealthEquip', 'Leading provider of medical equipment.', 8,              3.29, '07:00:00', '17:00:00');
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating", "StartTime", "EndTime") VALUES (9, 'LifeSolutions', 'Trusted tools for healthcare professionals.', 9,       3.61, '07:00:00', '17:00:00');
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating", "StartTime", "EndTime") VALUES (10, 'HealthEquip', 'Leading provider of medical equipment.', 10,            2.72, '07:00:00', '17:00:00');
ALTER SEQUENCE medequipcentral."Company_Id_seq" RESTART WITH 11;

-- Inserting EquipmentType Data
INSERT INTO medequipcentral."EquipmentType" ("Id", "Type", "Description") VALUES (1, 'X-Ray Machine', 'Used for radiographic imaging');
INSERT INTO medequipcentral."EquipmentType" ("Id", "Type", "Description") VALUES (2, 'MRI Scanner', 'Magnetic resonance imaging device');
INSERT INTO medequipcentral."EquipmentType" ("Id", "Type", "Description") VALUES (3, 'Ultrasound', 'Used for examining the body');
INSERT INTO medequipcentral."EquipmentType" ("Id", "Type", "Description") VALUES (4, 'ECG Machine', 'Records the electrical activity of the heart');
INSERT INTO medequipcentral."EquipmentType" ("Id", "Type", "Description") VALUES (5, 'Ventilator', 'Supports breathing');
INSERT INTO medequipcentral."EquipmentType" ("Id", "Type", "Description") VALUES (6, 'Defibrillator', 'Delivers a dose of electric current to the heart');
INSERT INTO medequipcentral."EquipmentType" ("Id", "Type", "Description") VALUES (7, 'Anesthesia Machine', 'Delivers anesthesia during surgery');
INSERT INTO medequipcentral."EquipmentType" ("Id", "Type", "Description") VALUES (8, 'Patient Monitor', 'Monitors vital signs of patients');
INSERT INTO medequipcentral."EquipmentType" ("Id", "Type", "Description") VALUES (9, 'Sterilizer', 'Sterilizes equipment');
INSERT INTO medequipcentral."EquipmentType" ("Id", "Type", "Description") VALUES (10, 'Infusion Pump', 'Delivers fluids in controlled amounts');
ALTER SEQUENCE medequipcentral."EquipmentType_Id_seq" RESTART WITH 11;

-- Inserting Equipment Data
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId", "Quantity", "EquipmentId", "Price") VALUES (1, 'HealthEquip Defibrillator', 'Medical equipment for healthcare use', 6,          8, 3, 1, 100);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId", "Quantity", "EquipmentId", "Price") VALUES (2, 'ThriveEquip Ventilator', 'Medical equipment for healthcare use', 5,             6, 3, 2, 150);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId", "Quantity", "EquipmentId", "Price") VALUES (3, 'HealthEquip Anesthesia Machine', 'Medical equipment for healthcare use', 7,     10, 3, 3, 170);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId", "Quantity", "EquipmentId", "Price") VALUES (4, 'WellnessTools Defibrillator', 'Medical equipment for healthcare use', 6,        3, 3, 4, 160);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId", "Quantity", "EquipmentId", "Price") VALUES (5, 'WellnessTools Sterilizer', 'Medical equipment for healthcare use', 9,           3, 3, 5, 120);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId", "Quantity", "EquipmentId", "Price") VALUES (6, 'HealthEquip Sterilizer', 'Medical equipment for healthcare use', 9,             8, 3, 6, 130);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId", "Quantity", "EquipmentId", "Price") VALUES (7, 'HealWell Ultrasound', 'Medical equipment for healthcare use', 3,                7, 3, 7, 145);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId", "Quantity", "EquipmentId", "Price") VALUES (8, 'WellnessTools X-Ray Machine', 'Medical equipment for healthcare use', 1,        3, 3, 8, 157);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId", "Quantity", "EquipmentId", "Price") VALUES (9, 'ThriveEquip X-Ray Machine', 'Medical equipment for healthcare use', 1,          4, 3, 9, 185);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId", "Quantity", "EquipmentId", "Price") VALUES (10, 'WellnessTools Ventilator', 'Medical equipment for healthcare use', 5,          2, 3, 10, 190);
ALTER SEQUENCE medequipcentral."Equipment_Id_seq" RESTART WITH 11;

-- Inserting Updated Users Data
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (1, 'william.johnson@example.com', 'william', 'William', 'Johnson', 'Brookside', 'Italy', '+16491453150', 'Doctor', 'Medical', 4, 2, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (2, 'charles.wilson@example.com', 'charles', 'Charles', 'Wilson', 'Springfield', 'USA', '+19509740546', 'HR', 'Non-profit', null, 1, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (3, 'mary.johnson@example.com', 'mary', 'Mary', 'Johnson', 'Hillcrest', 'Brazil', '+13736747021', 'Salesperson', 'University', null, 1, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (4, 'richard.davis@example.com', 'richard', 'Richard', 'Davis', 'Springfield', 'Brazil', '+15613528325', 'Salesperson', 'Healthcare', null, 3, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (5, 'david.brown@example.com', 'david', 'David', 'Brown', 'Hillcrest', 'Canada', '+12865738928', 'Technician', 'University', null, 3, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (6, 'joseph.wilson@example.com', 'joseph', 'Joseph', 'Wilson', 'Oakdale', 'Spain', '+16889860873', 'Technician', 'Hospital', null, 3, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (7, 'sarah.smith@example.com', 'sarah', 'Sarah', 'Smith', 'Mapleton', 'Australia', '+13360781132', 'Accountant', 'Clinic', null, 3, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (8, 'michael.brown@example.com', 'michael', 'Michael', 'Brown', 'Oakdale', 'USA', '+11002172098', 'HR', 'University', null, 1, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (9, 'david.rodriguez@example.com', 'david', 'David', 'Rodriguez', 'Fairview', 'Brazil', '+18038887373', 'Support Staff', 'Research', null, 1, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (10, 'james.rodriguez@example.com', 'james', 'James', 'Rodriguez', 'Sunnyvale', 'Spain', '+11298168367', 'Manager', 'Medical', null, 1, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (11, 'robert.jones@example.com', 'robert', 'Robert', 'Jones', 'Hillcrest', 'Canada', '+13791958790', 'Support Staff', 'Corporate', 4, 2, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (12, 'karen.smith@example.com', 'karen', 'Karen', 'Smith', 'Springfield', 'USA', '+16140484076', 'Manager', 'Research', 4, 2, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (13, 'john.davis@example.com', 'john', 'John', 'Davis', 'Sunnyvale', 'Canada', '+17014570823', 'HR', 'University', null, 1, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (14, 'sarah.brown@example.com', 'sarah', 'Sarah', 'Brown', 'Sunnyvale', 'UK', '+15844053207', 'Doctor', 'Laboratory', null, 1, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (15, 'karen.davis@example.com', 'karen', 'Karen', 'Davis', 'Fairview', 'Canada', '+11032132070', 'Engineer', 'Clinic', 2, 2, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (16, 'john.smith@example.com', 'john', 'John', 'Smith', 'Hillcrest', 'Brazil', '+17319860753', 'Manager', 'Healthcare', 9, 2, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (17, 'richard.miller@example.com', 'richard', 'Richard', 'Miller', 'Fairview', 'Australia', '+12688411189', 'Administrator', 'Clinic', null, 1, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (18, 'john.johnson@example.com', 'john', 'John', 'Johnson', 'Fairview', 'Spain', '+12096256874', 'Accountant', 'Non-profit', 9, 2, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (19, 'linda.rodriguez@example.com', 'linda', 'Linda', 'Rodriguez', 'Hillcrest', 'Australia', '+19471976184', 'Nurse', 'Corporate', 3, 2, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (20, 'jessica.jones@example.com', 'jessica', 'Jessica', 'Jones', 'Brookside', 'India', '+12133854487', 'Accountant', 'Pharmacy', 5, 2, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (21, 'barbara.bobak@example.com', 'barbara', 'Barbara', 'Bobak', 'Fairview', 'Australia', '+16432746563', 'Doctor', 'Research', null, 3, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (22, 'patricia.brown@example.com', 'patricia', 'Patricia', 'Brown', 'Sunnyvale', 'Spain', '+18885272401', 'Administrator', 'Pharmacy', null, 1, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (23, 'patricia.davis@example.com', 'patricia', 'Patricia', 'Davis', 'Fairview', 'Spain', '+18554216265', 'Engineer', 'Non-profit', 2, 2, True, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (24, 'projekat.isa@gmail.com', 'Test!!123', 'Projekat', 'Isa', 'Novi Sad', 'Srbija', '+381654216265', 'Engineer', 'Non-profit', 2, 2, False, 0);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role", "IsFirstLogin", "PenalPoints") VALUES (25, 'projekat.user@gmail.com', 'Test!!123', 'Projekat', 'User', 'Novi Sad', 'Srbija', '+381654346265', 'Nurse', 'Non-profit', null, 1, False, 0);
ALTER SEQUENCE medequipcentral."Users_Id_seq" RESTART WITH 24;

-- Inserting Appointments Data
INSERT INTO medequipcentral."Appointments" ("Id", "Duration", "CompanyId", "AdminId", "BuyerId", "StartTime", "EquipmentIds", "Price", "Status") VALUES (1, 70, 2, 11, 5, '2023-12-20 01:10:52', '{}', 200, 0);
INSERT INTO medequipcentral."Appointments" ("Id", "Duration", "CompanyId", "AdminId", "BuyerId", "StartTime", "EquipmentIds", "Price", "Status") VALUES (2, 155, 9, 20, 3, '2023-12-22 03:56:58', '{10}', 150, 0);
INSERT INTO medequipcentral."Appointments" ("Id", "Duration", "CompanyId", "AdminId", "BuyerId", "StartTime", "EquipmentIds", "Price", "Status") VALUES (3, 110, 9, 20, 3, '2023-12-20 10:05:11', '{4}', 2000, 0);
INSERT INTO medequipcentral."Appointments" ("Id", "Duration", "CompanyId", "AdminId", "BuyerId", "StartTime", "EquipmentIds", "Price", "Status") VALUES (4, 149, 9, 20, 3, '2023-12-21 21:14:56', '{6, 1}', 700, 0);
INSERT INTO medequipcentral."Appointments" ("Id", "Duration", "CompanyId", "AdminId", "BuyerId", "StartTime", "EquipmentIds", "Price", "Status") VALUES (5, 135, 2, 11, 5, '2023-12-20 01:54:33', '{}', 900, 0);
INSERT INTO medequipcentral."Appointments" ("Id", "Duration", "CompanyId", "AdminId", "BuyerId", "StartTime", "EquipmentIds", "Price", "Status") VALUES (6, 97, 9, 20, 9, '2023-12-20 17:38:38', '{4}', 345, 0);
INSERT INTO medequipcentral."Appointments" ("Id", "Duration", "CompanyId", "AdminId", "BuyerId", "StartTime", "EquipmentIds", "Price", "Status") VALUES (7, 80, 9, 20, 10, '2023-12-22 15:26:09', '{9}', 230, 0);
INSERT INTO medequipcentral."Appointments" ("Id", "Duration", "CompanyId", "AdminId", "BuyerId", "StartTime", "EquipmentIds", "Price", "Status") VALUES (8, 150, 9, 20, 10, '2023-12-20 09:28:55', '{2, 1}', 500, 0);
INSERT INTO medequipcentral."Appointments" ("Id", "Duration", "CompanyId", "AdminId", "BuyerId", "StartTime", "EquipmentIds", "Price", "Status") VALUES (9, 135, 2, 11, 13, '2023-12-20 19:11:11', '{5}', 400, 0);
INSERT INTO medequipcentral."Appointments" ("Id", "Duration", "CompanyId", "AdminId", "BuyerId", "StartTime", "EquipmentIds", "Price", "Status") VALUES (10, 30, 2, 24, 25, '2023-12-22 15:49:12', '{8, 9, 7}', 300, 0);
INSERT INTO medequipcentral."Appointments" ("Id", "Duration", "CompanyId", "AdminId", "BuyerId", "StartTime", "EquipmentIds", "Price", "Status") VALUES (11, 30, 2, 24, 25, '2023-12-23 15:49:12', '{8, 9, 7}', 300, 0);
INSERT INTO medequipcentral."Appointments" ("Id", "Duration", "CompanyId", "AdminId", "BuyerId", "StartTime", "EquipmentIds", "Price", "Status") VALUES (12, 30, 2, 24, 25, '2023-12-24 15:49:12', '{8, 9, 7}', 300, 0);
INSERT INTO medequipcentral."Appointments" ("Id", "Duration", "CompanyId", "AdminId", "BuyerId", "StartTime", "EquipmentIds", "Price", "Status") VALUES (13, 30, 2, 24, 25, '2023-12-25 15:49:12', '{8, 9, 7}', 300, 0);
ALTER SEQUENCE medequipcentral."Appointments_Id_seq" RESTART WITH 11;

-- Inserting QrCodes Data
INSERT INTO medequipcentral."QrCodes" ("Id", "AdminId", "BuyerId", "AppointmentId", "AppointmentStatus", "Path") VALUES (1, 11, 5, 1, 0, 'reservation11.png');
INSERT INTO medequipcentral."QrCodes" ("Id", "AdminId", "BuyerId", "AppointmentId", "AppointmentStatus", "Path") VALUES (2, 20, 3, 2, 0, 'reservation12.png');
INSERT INTO medequipcentral."QrCodes" ("Id", "AdminId", "BuyerId", "AppointmentId", "AppointmentStatus", "Path") VALUES (3, 20, 3, 3, 0, 'reservation13.png');
INSERT INTO medequipcentral."QrCodes" ("Id", "AdminId", "BuyerId", "AppointmentId", "AppointmentStatus", "Path") VALUES (4, 20, 3, 4, 0, 'reservation17.png');
INSERT INTO medequipcentral."QrCodes" ("Id", "AdminId", "BuyerId", "AppointmentId", "AppointmentStatus", "Path") VALUES (5, 11, 5, 5, 0, 'reservation18.png');
INSERT INTO medequipcentral."QrCodes" ("Id", "AdminId", "BuyerId", "AppointmentId", "AppointmentStatus", "Path") VALUES (6, 20, 9, 6, 0, 'reservation19.png');
INSERT INTO medequipcentral."QrCodes" ("Id", "AdminId", "BuyerId", "AppointmentId", "AppointmentStatus", "Path") VALUES (7, 20, 10, 7, 0, 'reservation24.png');
INSERT INTO medequipcentral."QrCodes" ("Id", "AdminId", "BuyerId", "AppointmentId", "AppointmentStatus", "Path") VALUES (8, 20, 10, 8, 0, 'reservation25.png');
INSERT INTO medequipcentral."QrCodes" ("Id", "AdminId", "BuyerId", "AppointmentId", "AppointmentStatus", "Path") VALUES (9, 11, 13, 9, 0, 'reservation26.png');
INSERT INTO medequipcentral."QrCodes" ("Id", "AdminId", "BuyerId", "AppointmentId", "AppointmentStatus", "Path") VALUES (10, 24, 25, 10, 0, 'reservation27.png');
INSERT INTO medequipcentral."QrCodes" ("Id", "AdminId", "BuyerId", "AppointmentId", "AppointmentStatus", "Path") VALUES (11, 24, 25, 11, 0, 'reservation28.png');
INSERT INTO medequipcentral."QrCodes" ("Id", "AdminId", "BuyerId", "AppointmentId", "AppointmentStatus", "Path") VALUES (12, 24, 25, 12, 0, 'reservation29.png');
INSERT INTO medequipcentral."QrCodes" ("Id", "AdminId", "BuyerId", "AppointmentId", "AppointmentStatus", "Path") VALUES (13, 24, 25, 13, 0, 'reservation11.png');