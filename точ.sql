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
create table Basket_Buyer
(
id_user int,
ltem_number int,
Quantity int
primary key(id_user,ltem_number),
foreign key(id_user) references Customers(ClieNt_code),
foreign key(ltem_number) references Products1(ltem_number)
)
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
create table filter
(
Category_id int primary key,
Feed nvarchar(50) not null,
toys nvarchar(50) not null,
Bowls nvarchar(50) not null,
aquariums nvarchar(50) not null,
foreign key(Category_id) references Category(Category_id)

)
create table Category
(
Category_id int primary key,
For_dogs nvarchar(50) not null,
For_cats nvarchar(50) not null,
Aquariums nvarchar(50) not null,
For_birds nvarchar(50) not null
) 