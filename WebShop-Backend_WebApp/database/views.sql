use webshopDB

	CREATE VIEW vwProductsInCategory
	AS
	SELECT c1.CategoryID, c1.CategoryName, COUNT(c1.CategoryID) AS ProductsInCategory FROM Category c1
	INNER JOIN CategoryProduct c2
	ON c1.CategoryID = c2.CategoryID
	GROUP BY c1.CategoryID, c1.CategoryName

	SELECT * FROM vwProductsInCategory

	-- kupac ulogiran u sustav

	CREATE VIEW vwLoggedinUserOffer
	AS
	SELECT p.*, c2.CategoryID, c2.CategoryName FROM Products p
	INNER JOIN CategoryProduct c1
	ON p.ProductID = c1.ProductID
	INNER JOIN Category c2
	ON c1.CategoryID = c2.CategoryID

	SELECT * FROM vwLoggedinUserOffer


	-- kupac nije ulogieran u sustav

	CREATE VIEW vwLoggedoutUserOffer
	AS
	SELECT p.*, c2.CategoryID, c2.CategoryName FROM Products p
	INNER JOIN CategoryProduct c1
	ON p.ProductID = c1.ProductID
	INNER JOIN Category c2
	ON c1.CategoryID = c2.CategoryID
	WHERE p.PremiumOffer = 0

	SELECT * FROM vwLoggedoutUserOffer


	CREATE VIEW vwAllOrders
	AS
	select o.OrderID, o.TotalPrice, o.OrderDate, o.ShipmentDate, o.ShipmentAdress, o.OrderStatusID, u.UserID, u.FirstName, u.LastName from Orders o
	inner join Users u
	on u.UserID = o.UserID

	select * from vwAllOrders


	CREATE VIEW vwProductsWithSpecs
	AS
	select p.*, s.CPU, s.CPU_GHz, s.CPU_Cores, s.GPU, s.GPU_VRAM, s.RAM, s.RAM_size, s.Storage_HDD, s.Storage_SSD from Products p
	inner join Specifications s
	on p.ProductID = s.ProductID
	
	select * from vwProductsWithSpecs

	select * from Products
	select * from CategoryProduct
	select * from Specifications

	delete from Products where ProductID = 10

	select * from CartItem
	select * from Cart
	select * from Users
	select * from Orders