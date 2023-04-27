--Create Database
CREATE DATABASE TeamTrackerDB;

USE TeamTrackerDB;

-- Create Department table
CREATE TABLE Department (
    DepartmentID INT PRIMARY KEY IDENTITY(1, 1),
    Name NVARCHAR(50) NOT NULL UNIQUE,
    Floor INT NOT NULL
);

-- Create ProgrammingLanguage table
CREATE TABLE ProgrammingLanguage (
    ProgrammingLanguageID INT PRIMARY KEY IDENTITY(1, 1),
    Name NVARCHAR(50) NOT NULL UNIQUE
);

-- Create Employee table
CREATE TABLE Employee (
    EmployeeID INT PRIMARY KEY IDENTITY(1, 1),
    Name NVARCHAR(50) NOT NULL,
    Surname NVARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    Gender CHAR(1) NOT NULL,
    DepartmentID INT FOREIGN KEY REFERENCES Department(DepartmentID) ON DELETE NO ACTION ON UPDATE CASCADE,
    ProgrammingLanguageID INT FOREIGN KEY REFERENCES ProgrammingLanguage(ProgrammingLanguageID) ON DELETE NO ACTION ON UPDATE CASCADE
);