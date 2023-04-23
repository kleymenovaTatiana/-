create table Orders
(
Order_code int,
id_user int,
ltem_number int,
Employee_Code int,
Date_and_time datetime not null,
Status nvarchar(50) not null,
Quantity int,
Delivery_method nvarchar(50) not null,
primary key(Order_code, id_user, ltem_number, Employee_Code),
foreign key(id_user) references Customers(ClieNt_code),
foreign key(ltem_number) references Products1(ltem_number),
foreign key(Employee_Code) references Staff(Employee_code)
)
insert into Orders
(
Order_code,
id_user,
ltem_number,
Employee_Code,
Date_and_time,
Status,
Quantity,
Delivery_method
)
values
('98','1','11','4',(convert(datetime,'1900-01-01T23:59:59 PM')),'sending','500','pickup'),
('88','2','22','5',(convert(datetime,'1900-01-01T20:59:59 PM')),'poluchin','459','courier'),
('87','3','33','6',(convert(datetime,'1900-01-01T21:59:59 PM')),'treatment','1000','mail')
create table Products1
(
ltem_number int primary key,
Category_id int not null,
Title nvarchar(50) not null,
Cost decimal(25,2) not null,
Description nvarchar(50) not null,
Article_number int not null,
Number_in_clade int not null
foreign key(Category_id) references Category(Category_id)
)

insert into Products1
(
ltem_number,
Category_id,
Title,
Cost,
Description,
Article_number,
Number_in_clade
)
values
('11','111','dry_food','1130','adult dog food','1234567','21'),
('22','222','dry_food','1733','cat food','1460123','22'),
('33','333','feed','233','for goldfish','1951699','23')

create table Basket_Buyer
(
id_user int,
ltem_number int,
Quantity int
primary key(id_user,ltem_number),
foreign key(id_user) references Customers(ClieNt_code),
foreign key(ltem_number) references Products1(ltem_number)
)
insert into Basket_Buyer
(
id_user,
ltem_number,
Quantity
)
values
('1','11','500'),
('2','22','459'),
('3','33','1000')
Create table Customers
(
ClieNt_code int primary key,
Nickname nvarchar(50) not null,
Password nvarchar(50) not null,
Surname nvarchar(50) not null,
Name nvarchar(50) not null,
Middle_name nvarchar(50) not null,
Mail nvarchar(50) not null,
Phone_number nvarchar(25) not null,
Birthdate date not null
)

insert into Customers
(
ClieNt_code,
Nickname,
Password,
Surname,
Name,
Middle_name,
Mail,
Phone_number,
Birthdate
)
values
('1','Sun','12345','Yakovleva','Olga','Petrovna','aquapark@mail.ru','78066133','2006-09-20'),
('2','Cat','54321','Zhuravleva','Evgeniya','Glebovna','dog@mail.ru','75003718','1990-05-23'),
('3','Fish','78945','Maximov','Timofey','Romanovich','car@mail.ru','76880794','1993-02-02')

Create table Staff
(
Employee_code int primary key,
Nickname nvarchar(50) not null,
Password nvarchar(50) not null,
Surname nvarchar(50) not null,
Namee nvarchar(50) not null,
Middle_name nvarchar(50) not null,
Mail nvarchar(50) not null,
Phone_number nvarchar(25) not null,
Birthdate date not null
)
insert into Staff
(
Employee_code,
Nickname,
Password,
Surname,
Namee,
Middle_name,
Mail,
Phone_number,
Birthdate
)
values
('4','bird','97145','Vavilova','Arina','Vladimirovna','ala@mail.ru','72563929','1978-01-11'),
('5','lion','11631','Latyshev','Grigory','Tikhonovich','mana@mail.ru','72921454','1979-05-12'),
('6','mouse','81010','Pavlova','Sofya','Mironovna','mime@mail.ru','74725939','1974-11-11')
create table filter
(
Category_id int primary key,
Feed nvarchar(50) not null,
toys nvarchar(50) not null,
Bowls nvarchar(50) not null,
aquariums nvarchar(50) not null,
foreign key(Category_id) references Category(Category_id)
)
insert into filter
(
Category_id,
Feed,
toys,
Bowls,
aquariums
)
values
('111','Royal_Canin','Tappi','Moderna','No'),
('222','Purina','Papillon','Yami','No'),
('333','Cliffi','No','Tetra','Benelux')

create table Category
(
Category_id int primary key,
Category_name nvarchar(50) not null
)
insert into Category
(
Category_id,
Category_name
)
values
('111','For_dogs'),
('222','For_cats'),
('333','For_fish')