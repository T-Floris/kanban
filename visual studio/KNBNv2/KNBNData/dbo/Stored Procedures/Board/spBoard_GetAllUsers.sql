CREATE PROCEDURE [dbo].[spBoard_GetAllUsers]
	@UserId nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT [Board].[Id], [Board].[Name], [User].[UserName], [Board].[Color]
	FROM [dbo].[Board], [dbo].[User]
	WHERE [Board].[UserId] = @UserId AND [User].[Id] = @UserId
END