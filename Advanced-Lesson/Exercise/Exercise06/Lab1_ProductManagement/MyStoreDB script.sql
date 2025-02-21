CREATE DATABASE MyStoreDB;
GO

USE MyStoreDB;
GO

-- Tạo bảng AccountMember
CREATE TABLE AccountMember (
    MemberID NVARCHAR(20) PRIMARY KEY,
    MemberPassword NVARCHAR(80) NOT NULL,
    FullName NVARCHAR(80) NOT NULL,
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
('Health'),
('Beauty'),
('Sports'),
('Outdoors'),
('Clothing'),
('Electronics'),
('Books');

-- Thêm dữ liệu vào bảng Products
INSERT INTO Products (ProductName, CategoryID, UnitsInStock, UnitPrice) VALUES
('Smartphone', 9, 50, 699.99),
('Laptop', 9, 30, 1299.99),
('T-Shirt', 8, 100, 19.99),
('Jeans', 8, 60, 49.99),
('Blender', 11, 40, 89.99),
('Yoga Mat', 11, 80, 29.99),
('Dumbbells Set', 6, 20, 99.99),
('Skincare Set', 5, 70, 39.99),
('Fiction Book', 10, 200, 14.99),
('Cookbook', 10, 120, 24.99);

-- Thêm dữ liệu vào bảng AccountMember
INSERT INTO AccountMember (MemberID, MemberPassword, FullName, EmailAddress, MemberRole) VALUES
('M001', 'hashed_password_1', 'Nguyễn Văn A', 'nguyenvana@example.com', 1),
('M002', 'hashed_password_2', 'Trần Thị B', 'tranthib@example.com', 2),
('M003', 'hashed_password_3', 'Lê Văn C', 'levanc@example.com', 0),
('M004', 'hashed_password_4', 'Phạm Thị D', 'phamthid@example.com', 0),
('M005', 'hashed_password_5', 'Hoàng Văn E', 'hoangvane@example.com', 2);
