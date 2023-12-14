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

-- Inserting Company Data
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating") VALUES (1, 'WellnessTools', 'Enhancing patient care with top-notch equipment.', 1, 3.52);
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating") VALUES (2, 'WellnessTools', 'Committed to delivering superior medical devices.', 2, 3.83);
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating") VALUES (3, 'WellnessTools', 'Enhancing patient care with top-notch equipment.', 3, 3.51);
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating") VALUES (4, 'ThriveEquip', 'Dedicated to the advancement of medical technology.', 4, 3.4);
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating") VALUES (5, 'LifeSolutions', 'Revolutionizing patient care through innovation.', 5, 2.91);
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating") VALUES (6, 'ThriveEquip', 'Committed to delivering superior medical devices.', 6, 3.62);
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating") VALUES (7, 'HealWell', 'Innovative medical solutions for modern healthcare.', 7, 1.54);
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating") VALUES (8, 'HealthEquip', 'Leading provider of medical equipment.', 8, 3.29);
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating") VALUES (9, 'LifeSolutions', 'Trusted tools for healthcare professionals.', 9, 3.61);
INSERT INTO medequipcentral."Company" ("Id", "Name", "Description", "LocationId", "Rating") VALUES (10, 'HealthEquip', 'Leading provider of medical equipment.', 10, 2.72);

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

-- Inserting Equipment Data
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId") VALUES (1, 'Equipment 1', 'Medical equipment for healthcare use', 6, 8);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId") VALUES (2, 'Equipment 2', 'Medical equipment for healthcare use', 5, 6);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId") VALUES (3, 'Equipment 3', 'Medical equipment for healthcare use', 7, 10);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId") VALUES (4, 'Equipment 4', 'Medical equipment for healthcare use', 6, 3);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId") VALUES (5, 'Equipment 5', 'Medical equipment for healthcare use', 9, 3);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId") VALUES (6, 'Equipment 6', 'Medical equipment for healthcare use', 9, 8);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId") VALUES (7, 'Equipment 7', 'Medical equipment for healthcare use', 3, 7);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId") VALUES (8, 'Equipment 8', 'Medical equipment for healthcare use', 1, 3);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId") VALUES (9, 'Equipment 9', 'Medical equipment for healthcare use', 1, 4);
INSERT INTO medequipcentral."Equipment" ("Id", "Name", "Description", "TypeId", "CompanyId") VALUES (10, 'Equipment 10', 'Medical equipment for healthcare use', 5, 2);

-- Inserting Users Data
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (1, 'william.johnson@example.com', 'da48961a9f5efb9ca8a4aa133f47b50e', 'William', 'Johnson', 'Brookside', 'Italy', '+16491453150', 'Doctor', 'Medical', 4, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (2, 'charles.wilson@example.com', '0eab17a482b5c96dd8427fa96b02e188', 'Charles', 'Wilson', 'Springfield', 'USA', '+19509740546', 'HR', 'Non-profit', 3, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (3, 'mary.johnson@example.com', '66c59e816ab36dcda7abc5b5a0096dcc', 'Mary', 'Johnson', 'Hillcrest', 'Brazil', '+13736747021', 'Salesperson', 'University', 7, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (4, 'richard.davis@example.com', '72b0ae598729bac79aee8b0f2d2e6602', 'Richard', 'Davis', 'Springfield', 'Brazil', '+15613528325', 'Salesperson', 'Healthcare', 4, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (5, 'david.brown@example.com', '3ee910705534ff10520536f0ce127b63', 'David', 'Brown', 'Hillcrest', 'Canada', '+12865738928', 'Technician', 'University', 3, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (6, 'joseph.wilson@example.com', '0f18739de00ae1a5fbf6bd229c5b24e2', 'Joseph', 'Wilson', 'Oakdale', 'Spain', '+16889860873', 'Technician', 'Hospital', 4, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (7, 'sarah.smith@example.com', 'b967c1aa0ebd90126d49dcfedf74c690', 'Sarah', 'Smith', 'Mapleton', 'Australia', '+13360781132', 'Accountant', 'Clinic', 6, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (8, 'michael.brown@example.com', '0c547641f462cc79d4d319e1fc350b5d', 'Michael', 'Brown', 'Oakdale', 'USA', '+11002172098', 'HR', 'University', 3, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (9, 'david.rodriguez@example.com', 'e0354ed85655634bdd010c1a7fa0f7d9', 'David', 'Rodriguez', 'Fairview', 'Brazil', '+18038887373', 'Support Staff', 'Research', 2, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (10, 'james.rodriguez@example.com', 'a826842b12cdb2467ef3fbcf298b2d2d', 'James', 'Rodriguez', 'Sunnyvale', 'Spain', '+11298168367', 'Manager', 'Medical', 4, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (11, 'robert.jones@example.com', 'cd21d8bc785634c943a1ec61438fde2d', 'Robert', 'Jones', 'Hillcrest', 'Canada', '+13791958790', 'Support Staff', 'Corporate', 4, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (12, 'karen.smith@example.com', '607168aaef6d697f04e13629cb0f4c4a', 'Karen', 'Smith', 'Springfield', 'USA', '+16140484076', 'Manager', 'Research', 4, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (13, 'john.davis@example.com', '789f092b67be1aa18240d37e25119f9a', 'John', 'Davis', 'Sunnyvale', 'Canada', '+17014570823', 'HR', 'University', 2, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (14, 'sarah.brown@example.com', '501628454676969579b4bf3368a8a9d3', 'Sarah', 'Brown', 'Sunnyvale', 'UK', '+15844053207', 'Doctor', 'Laboratory', 4, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (15, 'mary.johnson@example.com', '66c59e816ab36dcda7abc5b5a0096dcc', 'Mary', 'Johnson', 'Brookside', 'Germany', '+14429552351', 'HR', 'Research', 9, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (16, 'karen.davis@example.com', '9cba12138ed660d9b9bc702bbc4626a7', 'Karen', 'Davis', 'Fairview', 'Canada', '+11032132070', 'Engineer', 'Clinic', 2, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (17, 'john.smith@example.com', 'e7624f83b5aa81ca40b1a4d40b2288ae', 'John', 'Smith', 'Hillcrest', 'Brazil', '+17319860753', 'Manager', 'Healthcare', 9, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (18, 'mary.johnson@example.com', '66c59e816ab36dcda7abc5b5a0096dcc', 'Mary', 'Johnson', 'Fairview', 'Brazil', '+14483518635', 'Engineer', 'University', 4, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (19, 'richard.miller@example.com', '3d75ec6525af35827dc3f4e64d1d683d', 'Richard', 'Miller', 'Fairview', 'Australia', '+12688411189', 'Administrator', 'Clinic', 2, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (20, 'john.johnson@example.com', '32e58875bae7af60ebe475674259ac20', 'John', 'Johnson', 'Fairview', 'Spain', '+12096256874', 'Accountant', 'Non-profit', 9, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (21, 'linda.rodriguez@example.com', 'acd7e695a470094cd0d96aad7ed9936c', 'Linda', 'Rodriguez', 'Hillcrest', 'Australia', '+19471976184', 'Nurse', 'Corporate', 3, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (22, 'jessica.jones@example.com', 'a7350e53c81c9b229a75e2d045364f82', 'Jessica', 'Jones', 'Brookside', 'India', '+12133854487', 'Accountant', 'Pharmacy', 5, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (23, 'barbara.williams@example.com', '9c676872dc04575bb95281a78549d9e4', 'Barbara', 'Williams', 'Fairview', 'Australia', '+16432746563', 'Doctor', 'Research', 5, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (24, 'patricia.brown@example.com', '0fad3afd32a052082815acd1cc7ff383', 'Patricia', 'Brown', 'Sunnyvale', 'Spain', '+18885272401', 'Administrator', 'Pharmacy', 5, 2);
INSERT INTO medequipcentral."Users" ("Id", "Email", "Password", "Name", "Surname", "City", "Country", "Phone", "Job", "CompanyInfo", "CompanyId", "Role") VALUES (25, 'patricia.davis@example.com', '97f13bb293509bbb9e6324c33eabd1a2', 'Patricia', 'Davis', 'Fairview', 'Spain', '+18554216265', 'Engineer', 'Non-profit', 2, 2);




