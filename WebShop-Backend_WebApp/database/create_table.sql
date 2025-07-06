use webshopDB


CREATE TABLE UserRoles(
	RoleID int primary key identity(1,1),
	RoleName varchar(50)
)

CREATE TABLE States(
	StateID int primary key identity(1,1),
	StateName varchar(50)
)

CREATE TABLE OrderStatus(
	StatusID int primary key identity(1,1),
	StatusName varchar(50)
)

CREATE TABLE Category(
	CategoryID int primary key identity(1,1),
	CategoryName varchar(50)
)

CREATE TABLE CartStatus(
	CartStatusID int primary key identity(1,1),
	CartStatusName varchar(50)
)


CREATE TABLE Users(
	UserID int primary key identity(1,1),
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	HouseNumber int NOT NULL,
	Street varchar(50) NOT NULL,
	StateID int foreign key references States(StateID) NOT NULL,
	Town varchar(50) NOT NULL,
	Email varchar(50) NOT NULL,
	Username varchar(50) NOT NULL,
	Pass varchar(50) NOT NULL,
	RoleID int foreign key references UserRoles(RoleID)
)

CREATE TABLE Orders(
	OrderID int primary key identity(1,1),
	UserID int foreign key references Users(UserID),
	TotalPrice float,
	OrderDate date,
	ShipmentDate date,
	ShipmentAdress varchar(100),
	OrderStatusID int foreign key references OrderStatus(StatusID)
)

CREATE TABLE Products(
	ProductID int primary key identity(1,1),
	CategoryID int,
	ProductName varchar(50),
	CPU varchar(50),
	GPU varchar(50),
	RAM varchar(50),
	Storage varchar(50),
	Price float
)

CREATE TABLE CategoryProduct(
	ProductID int foreign key references Products(ProductID),
	CategoryID int foreign key references Category(CategoryID)
)

CREATE TABLE OrderItem(
	ProductID int foreign key references Products(ProductID),
	OrderID int foreign key references Orders(OrderID),
	Amount int
)

CREATE TABLE Cart(
	CartID int primary key identity(1,1),
	UserID int foreign key references Users(UserID),
	CreatedDate date,
	UpdatedDate date,
	CartStarusID int foreign key references CartStatus(CartStatusID)
)

CREATE TABLE CartItem(
	ProductID int foreign key references Products(ProductID),
	CartID int foreign key references Cart(CartID),
	Amount int
)

   create table Specifications(
		ProductID int primary key foreign key references Products(ProductID),
		CPU varchar(50),
		CPU_GHz float,
		CPU_Cores int,
		GPU varchar(50),
		GPU_VRAM int,
		RAM varchar(50),
		RAM_size int,
		Storage_HDD int,
		Storage_SSD int
	   )
