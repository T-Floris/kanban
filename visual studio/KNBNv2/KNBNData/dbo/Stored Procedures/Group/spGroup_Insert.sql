CREATE PROCEDURE [dbo].[spGroup_Insert]
	@UserId int = 0,
	@Name NVARCHAR,
	@Color NVARCHAR(7)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO [dbo].[Group]
	VALUES (@UserId, @Name, @Color)
END