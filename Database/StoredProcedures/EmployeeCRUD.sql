--CRUD operations on the Employee table

CREATE PROCEDURE AddEmployee
    @Name NVARCHAR(50),
    @Surname NVARCHAR(50),
    @Age INT,
    @Gender CHAR(1),
    @DepartmentID INT,
    @ProgrammingLanguageID INT
AS
BEGIN
    INSERT INTO Employee (Name, Surname, Age, Gender, DepartmentID, ProgrammingLanguageID)
    VALUES (@Name, @Surname, @Age, @Gender, @DepartmentID, @ProgrammingLanguageID);
END;
GO

CREATE PROCEDURE GetEmployeeById
    @EmployeeID INT
AS
BEGIN
    SELECT e.*, 
		d.Name 'DepartmentName', d.Floor 'DepartmentFloor',
        p.Name AS 'ProgrammingLanguageName'
    FROM Employee e
    JOIN Department d ON e.DepartmentID = d.DepartmentID
    JOIN ProgrammingLanguage p ON e.ProgrammingLanguageID = p.ProgrammingLanguageID
    WHERE e.EmployeeID = @EmployeeID
END;
GO

CREATE PROCEDURE GetAllEmployees
AS
BEGIN
    SELECT e.*, 
		d.Name 'DepartmentName', d.Floor 'DepartmentFloor',
        p.Name AS 'ProgrammingLanguageName'
    JOIN Department d ON e.DepartmentID = d.DepartmentID
    JOIN ProgrammingLanguage p ON e.ProgrammingLanguageID = p.ProgrammingLanguageID
END;
GO

CREATE PROCEDURE UpdateEmployee
    @EmployeeID INT,
    @Name NVARCHAR(50),
    @Surname NVARCHAR(50),
    @Age INT,
    @Gender CHAR(1),
    @DepartmentID INT,
    @ProgrammingLanguageID INT
AS
BEGIN
    UPDATE Employee
    SET Name = @Name,
        Surname = @Surname,
        Age = @Age,
        Gender = @Gender,
        DepartmentID = @DepartmentID,
        ProgrammingLanguageID = @ProgrammingLanguageID
    WHERE EmployeeID = @EmployeeID;
END;
GO

CREATE PROCEDURE DeleteEmployee
    @EmployeeID INT
AS
BEGIN
    DELETE FROM Employee
    WHERE EmployeeID = @EmployeeID;
END;
GO
