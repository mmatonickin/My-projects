use webshopDB

INSERT INTO UserRoles (RoleName)
VALUES ('Admin'),
	   ('User'),
	   ('Client')


INSERT INTO Category(CategoryName)
VALUES ('Gaming'),
	   ('Office'),
	   ('All-in-one'),
	   ('Multimedia')


INSERT INTO States(StateName)
VALUES ('Zagrebačka županija'),
	   ('Krapinsko-zagorska županija'),
	   ('Sisačko-moslavačka županija'),
	   ('Karlovačka županija'),
	   ('Varaždinska županija'),
	   ('Koprivničko-križevačka županija'),
	   ('Bjelovarsko-bilogorska županija'),
	   ('Primorsko-goranska županija'),
	   ('Ličko-senjska županija'),
	   ('Virovitičko-podravska županija'),
	   ('Požeško-slavonska županija'),
	   ('Brodsko-posavska županija'),
	   ('Zadarska županija'),
	   ('Osječko-baranjska županija'),
	   ('Šibensko-kninska županija'),
	   ('Vukovarsko-srijemska županija'),
	   ('Splitsko-dalmatinska županija'),
	   ('Istarska županija'),
	   ('Dubrovačko-neretvanska županija'),
	   ('Međimurska županija')

INSERT INTO OrderStatus(StatusName)
VALUES ('Avtive'),
	   ('Completed')


INSERT INTO CartStatus(CartStatusName)
VALUES ('Active'),
	   ('Inactive'),
	   ('Abandoned')


INSERT INTO Products(ProductName, Price, PremiumOffer, Stock)
VALUES ('Stolno računalo HGPC Multimedia R46G16S4NHW', 579.00, 1, 2),
	   ('Stolno računalo HGPC Office Prime 1218S5NW11P', 637.00, 1, 2),
	   ('Stolno računalo HGPC Multimedia 12416S2NH4D', 715.00, 0, 5),
	   ('Stolno računalo HGPC Gamer Incubus 452', 829.00, 0, 9),
	   ('Stolno računalo HGPC Home Office 12416S1TNW11P', 863.00, 1, 7),
	   ('Stolno računalo HGPC Gamer Battleship 562', 909.00, 0, 4),
	   ('Stolno računalo HGPC Gamer Battleship 552', 955.00, 0, 9),
	   ('Stolno računalo HGPC Gamer Battleship 124F6', 999.00, 1, 4),
	   ('Stolno računalo HGPC Gamer Battleship 127F2', 1115.00, 0, 10),	   
	   ('Stolno računalo HP AiO 24-cb1090ny', 789.00, 0, 3)

select * from Products



INSERT INTO CategoryProduct
VALUES (1, 4),
	   (2, 2),
	   (2, 4),
	   (3, 4),
	   (3, 2),
	   (4, 1),
	   (5, 2),
	   (6, 1),
	   (7, 1),
	   (8, 1),
	   (9, 1),
	   (10, 3),
	   (10, 4)

	   select * from CategoryProduct

	

	INSERT INTO Specifications (ProductID, CPU, CPU_GHz, CPU_Cores, GPU, GPU_VRAM, RAM, RAM_size, Storage_HDD, Storage_SSD)
	VALUES (1, 'AMD Ryzen 5 4600G', 3.7, 6, 'AMD Radeon Vega 7 Graphics', null, 'DDR4, 2666 MHz', 16, 1000, 480),
		   (2, 'Intel Core i3 12100', 3.3, 4, 'Intel UHD 730', null, 'DDR4, 2666 MHz', 8, null, 500),
		   (3, 'Intel Core i5 12400', 2.5, 6, 'Intel UHD 730', null, 'DDR4, 3200 MHz', 16, 4000, 250),
		   (4, 'AMD Ryzen 5 4500', 2.3, 6, 'RTX3060 12 GB GDDR6', 12, 'DDR4, 3200 MHz, DIMM', 16, null, 1000),
		   (5, 'Intel Core i5 12400', 2.5, 6, 'Intel UHD 730', null, 'DDR4, 3200 MHz', 16, null, 1000),
		   (6, 'AMD Ryzen 5 5600', 3.7, 6, 'AMD Radeon RX 7600', 8, 'DDR4, 3200 MHz, DIMM', 16, null, 1000),
		   (7, 'AMD Ryzen 5 5500', 3.6, 6, 'RTX3050 8 GB', 8, 'DDR4, 3200 MHz, DIMM', 16, null, 500),
		   (8, 'Intel Core i5 12400F', 2.5, 6, 'RTX4060 8 GB', 8, 'DDR4, 3200 MHz, DIMM', 16, null, 1000),
		   (9, 'Intel Core i7 12700F', 2.1, 12, 'RTX3050 8 GB', 8, 'DDR4, 3200 MHz', 16, null, 1000),
		   (10, 'Core i3 1215U', 4.4, 6, 'Intel UHD Graphics', null, 'DDR4-3200 MHz', 8, null, 1000)


	   select * from Specifications
