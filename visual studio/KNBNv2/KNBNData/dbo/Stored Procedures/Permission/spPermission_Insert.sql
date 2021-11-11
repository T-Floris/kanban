CREATE PROCEDURE [dbo].[spPermission_Insert]
	@Title NVARCHAR(20),
	@Description NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON
	
	INSERT INTO [dbo].[Permission] ([Title], [Description])
	VALUES (@Title, @Description)
END
