CREATE TABLE [dbo].[Employees] (
    [EmployeeID] INT             IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50)   NOT NULL,
    [Capacity]   NVARCHAR (100)  NOT NULL,
    [Status]     BIT             NOT NULL,
    [Salary]     DECIMAL (10, 2) NOT NULL,
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);

SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT INTO [dbo].[Employees] ([EmployeeID], [Name], [Capacity], [Status], [Salary]) VALUES (1, N'Иванов', N'Мененджер', 1, CAST(5000.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[Employees] ([EmployeeID], [Name], [Capacity], [Status], [Salary]) VALUES (2, N'Петров', N'Инженер', 1, CAST(12000.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[Employees] ([EmployeeID], [Name], [Capacity], [Status], [Salary]) VALUES (3, N'Сидоров', N'Инженер', 1, CAST(9000.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[Employees] ([EmployeeID], [Name], [Capacity], [Status], [Salary]) VALUES (4, N'Остапенко', N'Бухгалтер', 1, CAST(21000.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[Employees] ([EmployeeID], [Name], [Capacity], [Status], [Salary]) VALUES (5, N'Микитенко', N'Экономист', 1, CAST(27000.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[Employees] ([EmployeeID], [Name], [Capacity], [Status], [Salary]) VALUES (6, N'Криворучко', N'Программист', 0, CAST(22000.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[Employees] ([EmployeeID], [Name], [Capacity], [Status], [Salary]) VALUES (7, N'Кобец', N'Программист', 1, CAST(35000.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[Employees] ([EmployeeID], [Name], [Capacity], [Status], [Salary]) VALUES (8, N'Ребров', N'Администратор', 1, CAST(15000.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[Employees] ([EmployeeID], [Name], [Capacity], [Status], [Salary]) VALUES (9, N'Сердюк', N'Лаборант', 0, CAST(7000.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[Employees] ([EmployeeID], [Name], [Capacity], [Status], [Salary]) VALUES (10, N'Квитка', N'Экономист', 1, CAST(27000.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[Employees] ([EmployeeID], [Name], [Capacity], [Status], [Salary]) VALUES (11, N'Гавриш', N'Инженер', 1, CAST(13000.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[Employees] ([EmployeeID], [Name], [Capacity], [Status], [Salary]) VALUES (12, N'Карагод', N'Бухгалтер', 0, CAST(22000.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[Employees] ([EmployeeID], [Name], [Capacity], [Status], [Salary]) VALUES (13, N'Беланович', N'Инженер', 0, CAST(14000.00 AS Decimal(10, 2)))
INSERT INTO [dbo].[Employees] ([EmployeeID], [Name], [Capacity], [Status], [Salary]) VALUES (14, N'Пахоменко', N'Программист', 1, CAST(15000.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Employees] OFF


