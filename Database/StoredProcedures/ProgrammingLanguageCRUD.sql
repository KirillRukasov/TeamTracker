--CRUD operations on the Department table

CREATE PROCEDURE AddProgrammingLanguage
    @Name NVARCHAR(50)
AS
BEGIN
    INSERT INTO ProgrammingLanguage (Name)
    VALUES (@Name)
END
GO

CREATE PROCEDURE GetProgrammingLanguages
AS
BEGIN
    SELECT * FROM ProgrammingLanguage
END
GO

CREATE PROCEDURE GetProgrammingLanguageByID
    @ProgrammingLanguageID INT
AS
BEGIN
    SELECT * FROM ProgrammingLanguage WHERE ProgrammingLanguageID = @ProgrammingLanguageID
END
GO

CREATE PROCEDURE UpdateProgrammingLanguage
    @ProgrammingLanguageID INT,
    @Name NVARCHAR(50)
AS
BEGIN
    UPDATE ProgrammingLanguage
    SET Name = @Name
    WHERE ProgrammingLanguageID = @ProgrammingLanguageID
END
GO

CREATE PROCEDURE DeleteProgrammingLanguageByID
    @ProgrammingLanguageID INT
AS
BEGIN
    DELETE FROM ProgrammingLanguage WHERE ProgrammingLanguageID = @ProgrammingLanguageID
END