-- DROPS ????????????????????????????????????????????????
-- DROP TABLE [School].[StudentClasses];
-- DROP TABLE [School].[Classes];
-- DROP TABLE [School].[Courses];
-- DROP TABLE [School].[Teachers];
-- DROP TABLE [School].[Students];
-- GO
--????????????????????????????????????????????????????????

CREATE SCHEMA [School];
GO

CREATE TABLE [School].[Students]
(
    Id INT PRIMARY KEY, -- UNIQUE and NOT NULL
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Address1 VARCHAR(255) NOT NULL,
    Address2 VARCHAR(255) NOT NULL,
    City VARCHAR(255) NOT NULL,
    State VARCHAR(255) NOT NULL,
    Zip INT NOT NULL,
    GPA DECIMAL NOT NULL,
);
GO

CREATE TABLE [School].[Teachers]
(
    Id INT PRIMARY KEY, -- UNIQUE and NOT NULL
    Name VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    Address1 VARCHAR(255) NOT NULL,
    Address2 VARCHAR(255) NOT NULL,
    City VARCHAR(255) NOT NULL,
    State VARCHAR(255) NOT NULL,
    Zip INT NOT NULL,
    Office INT NOT NULL,
    Salary DECIMAL NOT NULL,
    Subject VARCHAR(255) NOT NULL
);
GO

CREATE TABLE [School].[Courses]
(
    Id VARCHAR(255) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Department VARCHAR(255) NOT NULL,
    CreditHours INT NOT NULL,
    RequirementId VARCHAR(255) FOREIGN KEY REFERENCES [School].[Courses](Id)
)
GO

CREATE TABLE[School].[Classes]
(
    Id INT PRIMARY KEY,
    StartDate DATETIME NOT NULL,
    InstructorID INT NOT NULL FOREIGN KEY REFERENCES [School].[Teachers](Id), --FK reference
    CourseID  VARCHAR(255) NOT NULL FOREIGN KEY REFERENCES [School].[Courses](Id),
    Capacity INT NOT NULL,
    RoomNum INT NOT NULL 
)
GO

-- Linking table between students and classes (Class roster/ Students schedule)
CREATE TABLE [School].[StudentsClasses]
(
    Id INT PRIMARY KEY IDENTITY,
    StudentId INT NOT NULL FOREIGN KEY REFERENCES [School].[Students](Id),
    ClassId INT NOT NULL FOREIGN KEY REFERENCES [School].[Classes](Id)
)
GO



-- students    classes
--    1    ->    M
--    M    ->    1
--    M    ->    M

INSERT INTO [School].[Students]
(
    Id, -- UNIQUE and NOT NULL
    Name,
    Email,
    Address1,
    Address2,
    City,
    State,
    Zip,
    GPA 
) 
VALUES
(1, 'Lawrence', 'lawrence@gmail.com', 'address1', 'address2', 'city1', 'CA', '09876', 4.0),
(2, 'Meryem', 'Meryem@gmail.com', 'address3', 'address4', 'city2', 'MI', '34567', 4.1);


SELECT * FROM [dbo].[Customers];