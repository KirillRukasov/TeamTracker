--CRUD operations on the Department table

CREATE PROCEDURE AddDepartment
    @Name NVARCHAR(50),
    @Floor INT
AS
BEGIN
    INSERT INTO Department (Name, Floor)
    VALUES (@Name, @Floor)
END
GO

CREATE PROCEDURE GetDepartments
AS
BEGIN
    SELECT * FROM Department
END
GO

CREATE PROCEDURE GetDepartmentByID
    @DepartmentID INT
AS
BEGIN
    SELECT * FROM Department WHERE DepartmentID = @DepartmentID
END
GO

CREATE PROCEDURE UpdateDepartment
    @DepartmentID INT,
    @Name NVARCHAR(50),
    @Floor INT
AS
BEGIN
    UPDATE Department
    SET Name = @Name,
        Floor = @Floor
    WHERE DepartmentID = @DepartmentID
END
GO

CREATE PROCEDURE DeleteDepartmentByID
    @DepartmentID INT
AS
BEGIN
    DELETE FROM Department WHERE DepartmentID = @DepartmentID
END