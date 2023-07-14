CREATE PROCEDURE [dbo].[spUser_GetUsersByName]
	@name varchar(50)
AS
BEGIN
	SELECT Id, FirstName, LastName 
	FROM dbo.[User]
	Where Firstname like @name or LastName Like @Name
END
