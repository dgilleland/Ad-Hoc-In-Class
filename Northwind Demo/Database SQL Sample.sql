-- Sample SQL for creating the Orders table in Northwind (without check/default contrataints)

CREATE TABLE Orders(
	OrderID         int IDENTITY(1,1)
        CONSTRAINT PK_Orders
            PRIMARY KEY             NOT NULL,
	CustomerID      nchar(5) 
        CONSTRAINT FK_Orders_Customers 
            FOREIGN KEY REFERENCES Customers(CustomerID)
                                        NULL,
	EmployeeID      int 
        CONSTRAINT FK_Orders_Employees 
            FOREIGN KEY REFERENCES Employees(EmployeeID)
                                        NULL,
	OrderDate       datetime            NULL,
	RequiredDate    datetime            NULL,
	ShippedDate     datetime            NULL,
	ShipVia         int 
        CONSTRAINT FK_Orders_Employees 
            FOREIGN KEY REFERENCES Shippers(ShipperID)
                                        NULL,
	Freight         money               NULL,
	ShipName        nvarchar(40)        NULL,
	ShipAddress     nvarchar(60)        NULL,
	ShipCity        nvarchar(15)        NULL,
	ShipRegion      nvarchar(15)        NULL,
	ShipPostalCode  nvarchar(10)        NULL,
	ShipCountry     nvarchar(15)        NULL,
	LastModified    datetime        NOT NULL,
)