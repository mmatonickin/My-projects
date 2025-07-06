use webshopDB

	alter procedure spFilterByCategory
	@categoryID int
	as
	set nocount on
	if @categoryID is not null AND @categoryID in (select CategoryID from Category)
		begin
 			select p.*, c.CategoryID from Products p
			inner join CategoryProduct c
			on p.ProductID = c.ProductID
			where c.CategoryID = @categoryID
		end
	else
		begin
			print ('Nepostojeća kategorija')
		end

	EXECUTE spFilterByCategory 4

	alter procedure spFilterByPriceRange
	@minPrice float,
	@maxprice float
	as
	set nocount on
	if @minPrice is not null AND @maxprice is not null AND @minPrice <= @maxPrice
		begin
			select * from Products where Price between @minPrice and @maxPrice order by Price
		end
	else
		begin
			print ('Neispravan unos')
		end

	execute spFilterByPriceRange 700, 1000

	create procedure spUserOrders
	@userID int
	as
	set nocount on
	if @userID is not null AND @userID in (select UserID from Users)
		begin
			select u.UserID, u.FirstName, u.LastName, o.OrderID, o.TotalPrice, o.OrderDate, o.ShipmentDate, o.ShipmentAdress, o.OrderStatusID from Users u
			inner join Orders o
			on u.UserID = o.UserID
			where u.UserID = @userID
		end
	else
		begin
			print ('Kosisnik ne postoji')
		end

	execute spUserOrders 32
	

	create procedure spOrdersByYear
	@year int
	as
	set nocount on
	if @year is not null AND @year in (select distinct year(OrderDate) from Orders)
		begin
			select * from Orders where year(OrderDate) = @year
		end
	else
		begin
			print ('Krivi unos!')
		end

	execute spOrdersByYear 2025

	create procedure spSalesByYear
	@year int
	as
	set nocount on
	if @year is not null AND @year in (select distinct year(OrderDate) from Orders)
		begin
			select sum(TotalPrice) as TotalRevenue 
			from Orders
			where year(OrderDate) = @year
		end
	else
		begin
			print ('Krivi unos!')
		end

	execute spSalesByYear 2025