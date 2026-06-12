DECLARE @CityId INT = 1;
DECLARE @Now DATETIME2 = GETUTCDATE();
DECLARE @AptId INT;

-- 1. Студия 1
INSERT INTO Apartments (Name, CityId, Category, Rooms, Area, Price, ImageUrl, Status, CreatedAt, UpdatedAt)
VALUES (N'Лофт студия на Ботанике', @CityId, N'Студия', 1, 35, 32000, N'https://images.unsplash.com/photo-1554995207-c18c203602cb?w=800', 0, @Now, @Now);
SET @AptId = SCOPE_IDENTITY();
INSERT INTO ApartmentDescriptions (ApartmentId, Description, District, Floor, Entrance, TotalFloors, HasParking, HasElevator)
VALUES (@AptId, N'Стильная лофт-студия с открытой планировкой. Кирпичные стены, высокие потолки и огромные окна создают неповторимую атмосферу творческого пространства. В квартире установлена барная стойка и дизайнерское освещение. Идеально для креативных людей. Рядом парк Долина Роз.', N'Ботаника', 3, 1, 5, 1, 0);

-- 2. Студия 2
INSERT INTO Apartments (Name, CityId, Category, Rooms, Area, Price, ImageUrl, Status, CreatedAt, UpdatedAt)
VALUES (N'Студия с террасой', @CityId, N'Студия', 1, 40, 41000, N'https://images.unsplash.com/photo-1497366216548-37526070297c?w=800', 0, @Now, @Now);
SET @AptId = SCOPE_IDENTITY();
INSERT INTO ApartmentDescriptions (ApartmentId, Description, District, Floor, Entrance, TotalFloors, HasParking, HasElevator)
VALUES (@AptId, N'Уютная студия с собственной террасой в новом жилом комплексе. Внутри современная бытовая техника, панорамные окна и система "умный дом". Прекрасное место для утреннего кофе на свежем воздухе. Закрытый двор и видеонаблюдение.', N'Телецентр', 2, 2, 8, 1, 1);

-- 3. 1-комн 1
INSERT INTO Apartments (Name, CityId, Category, Rooms, Area, Price, ImageUrl, Status, CreatedAt, UpdatedAt)
VALUES (N'Светлая 1-комнатная квартира', @CityId, N'1 комната', 1, 45, 45000, N'https://images.unsplash.com/photo-1560448204-e02f11c3d0e2?w=800', 0, @Now, @Now);
SET @AptId = SCOPE_IDENTITY();
INSERT INTO ApartmentDescriptions (ApartmentId, Description, District, Floor, Entrance, TotalFloors, HasParking, HasElevator)
VALUES (@AptId, N'Просторная однокомнатная квартира с отдельной спальней и большой кухней. Сделан евроремонт: ламинат, натяжные потолки, качественные межкомнатные двери. Квартира продается с мебелью и техникой. Развитая инфраструктура, рядом школы и садики.', N'Буюканы', 5, 1, 9, 0, 1);

-- 4. 1-комн 2
INSERT INTO Apartments (Name, CityId, Category, Rooms, Area, Price, ImageUrl, Status, CreatedAt, UpdatedAt)
VALUES (N'Однокомнатная бизнес-класса', @CityId, N'1 комната', 1, 50, 55000, N'https://images.unsplash.com/photo-1505691938895-1758d7feb511?w=800', 0, @Now, @Now);
SET @AptId = SCOPE_IDENTITY();
INSERT INTO ApartmentDescriptions (ApartmentId, Description, District, Floor, Entrance, TotalFloors, HasParking, HasElevator)
VALUES (@AptId, N'Шикарная однокомнатная квартира в элитном новострое. Авторский дизайн, дорогая сантехника, пол с подогревом. Большая гардеробная комната. Жилой комплекс имеет закрытую охраняемую территорию, подземный паркинг и фитнес-клуб на первом этаже.', N'Центр', 7, 3, 12, 1, 1);

-- 5. 2-комн 1
INSERT INTO Apartments (Name, CityId, Category, Rooms, Area, Price, ImageUrl, Status, CreatedAt, UpdatedAt)
VALUES (N'Семейная двушка на Чеканах', @CityId, N'2 комнаты', 2, 65, 58000, N'https://images.unsplash.com/photo-1493809842364-78817add7ffb?w=800', 0, @Now, @Now);
SET @AptId = SCOPE_IDENTITY();
INSERT INTO ApartmentDescriptions (ApartmentId, Description, District, Floor, Entrance, TotalFloors, HasParking, HasElevator)
VALUES (@AptId, N'Отличная двухкомнатная квартира с раздельной планировкой. Две лоджии, раздельный санузел. Квартира очень теплая, неугловая. Во дворе находится новая детская площадка. Идеальный вариант для молодой семьи с ребенком.', N'Чеканы', 4, 4, 10, 1, 1);

-- 6. 2-комн 2
INSERT INTO Apartments (Name, CityId, Category, Rooms, Area, Price, ImageUrl, Status, CreatedAt, UpdatedAt)
VALUES (N'Двухкомнатная с видом на парк', @CityId, N'2 комнаты', 2, 70, 72000, N'https://images.unsplash.com/photo-1536376072261-38c75010e6c9?w=800', 0, @Now, @Now);
SET @AptId = SCOPE_IDENTITY();
INSERT INTO ApartmentDescriptions (ApartmentId, Description, District, Floor, Entrance, TotalFloors, HasParking, HasElevator)
VALUES (@AptId, N'Роскошная двушка с потрясающим видом на парковую зону. Просторная гостиная объединена с кухней, отдельная уютная спальня с панорамными окнами. Квартира полностью укомплектована дорогой техникой (Bosch, Miele). Заходи и живи!', N'Рышкановка', 8, 1, 14, 1, 1);

-- 7. 2-комн 3
INSERT INTO Apartments (Name, CityId, Category, Rooms, Area, Price, ImageUrl, Status, CreatedAt, UpdatedAt)
VALUES (N'Уютная 2-комнатная квартира', @CityId, N'2 комнаты', 2, 58, 49000, N'https://images.unsplash.com/photo-1484154218962-a197022b5858?w=800', 0, @Now, @Now);
SET @AptId = SCOPE_IDENTITY();
INSERT INTO ApartmentDescriptions (ApartmentId, Description, District, Floor, Entrance, TotalFloors, HasParking, HasElevator)
VALUES (@AptId, N'Недорогая и очень уютная двухкомнатная квартира во вторичном фонде. Капитальный ремонт проводился 3 года назад: заменены трубы и электропроводка. Чистый подъезд, тихие соседи. Отличная транспортная доступность.', N'Ботаника', 2, 2, 5, 0, 0);

-- 8. 3-комн 1
INSERT INTO Apartments (Name, CityId, Category, Rooms, Area, Price, ImageUrl, Status, CreatedAt, UpdatedAt)
VALUES (N'Просторная 3-комнатная для большой семьи', @CityId, N'3 комнаты', 3, 90, 85000, N'https://images.unsplash.com/photo-1512917774080-9991f1c4c750?w=800', 0, @Now, @Now);
SET @AptId = SCOPE_IDENTITY();
INSERT INTO ApartmentDescriptions (ApartmentId, Description, District, Floor, Entrance, TotalFloors, HasParking, HasElevator)
VALUES (@AptId, N'Прекрасная трехкомнатная квартира с тремя изолированными спальнями и огромной кухней-столовой. В квартире два санузла. Отлично подойдет для большой семьи. В пешей доступности лучшие лицеи города, спортивный комплекс и торговый центр.', N'Буюканы', 6, 1, 10, 1, 1);

-- 9. 3-комн 2
INSERT INTO Apartments (Name, CityId, Category, Rooms, Area, Price, ImageUrl, Status, CreatedAt, UpdatedAt)
VALUES (N'Пентхаус 3-комнатный', @CityId, N'3 комнаты', 3, 120, 150000, N'https://images.unsplash.com/photo-1560185127-6ed189bf02f4?w=800', 0, @Now, @Now);
SET @AptId = SCOPE_IDENTITY();
INSERT INTO ApartmentDescriptions (ApartmentId, Description, District, Floor, Entrance, TotalFloors, HasParking, HasElevator)
VALUES (@AptId, N'Элитный пентхаус на последнем этаже престижного комплекса. Три просторные комнаты, высота потолков 3.2 метра. Собственная смотровая терраса площадью 30 кв.м. Ремонт премиум-класса. В стоимость включено два места в подземном паркинге.', N'Центр', 15, 1, 15, 1, 1);

-- 10. 3-комн 3
INSERT INTO Apartments (Name, CityId, Category, Rooms, Area, Price, ImageUrl, Status, CreatedAt, UpdatedAt)
VALUES (N'Классическая трехкомнатная', @CityId, N'3 комнаты', 3, 80, 75000, N'https://images.unsplash.com/photo-1502005229762-cf1b2da7c5d6?w=800', 0, @Now, @Now);
SET @AptId = SCOPE_IDENTITY();
INSERT INTO ApartmentDescriptions (ApartmentId, Description, District, Floor, Entrance, TotalFloors, HasParking, HasElevator)
VALUES (@AptId, N'Классическая трехкомнатная квартира с качественным дубовым паркетом и дверьми из массива дерева. Квартира двусторонняя, очень светлая и теплая. Тихий зеленый двор с закрытой территорией.', N'Телецентр', 3, 3, 6, 1, 1);
