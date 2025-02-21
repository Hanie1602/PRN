CREATE DATABASE MyStoreDB;
GO

USE MyStoreDB;
GO

-- Tạo bảng AccountMember
CREATE TABLE AccountMember (
    MemberID NVARCHAR(20) PRIMARY KEY,
    MemberPassword NVARCHAR(80) NOT NULL,
    FullName NVARCHAR(100) NOT NULL,
    EmailAddress NVARCHAR(100) NOT NULL,
    MemberRole INT NOT NULL
);
GO

-- Tạo bảng Categories
CREATE TABLE Categories (
    CategoryID INT PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(15) NOT NULL
);
GO

-- Tạo bảng Products
CREATE TABLE Products (
    ProductID INT PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(40) NOT NULL,
    CategoryID INT NOT NULL,
    UnitsInStock SMALLINT,
    UnitPrice MONEY,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);
GO

-- Thêm dữ liệu vào bảng Categories
INSERT INTO Categories (CategoryName) VALUES
('Electronics'),
('Clothing'),
('Home Appliances'),
('Books');

-- Thêm dữ liệu vào bảng Products
INSERT INTO Products (ProductName, CategoryID, UnitsInStock, UnitPrice) VALUES
('Laptop', 1, 10, 1200.00),
('Smartphone', 1, 15, 800.00),
('T-shirt', 2, 50, 15.99),
('Jeans', 2, 30, 39.99),
('Microwave Oven', 3, 20, 150.00),
('Refrigerator', 3, 5, 500.00),
('Washing Machine', 3, 8, 700.00),
('Fiction Novel', 4, 40, 12.99),
('Science Book', 4, 25, 25.50),
('Cooking Recipe Book', 4, 18, 18.99);

-- Thêm dữ liệu vào bảng AccountMember
INSERT INTO AccountMember (MemberID, MemberPassword, FullName, EmailAddress, MemberRole) VALUES
('M001', '123', 'John Doe', 'mem1@example.com', 1),
('M002', '123', 'Jane Smith', 'mem2@example.com', 2),
('M003', '123', 'Admin User', 'mem3@example.com', 0);
