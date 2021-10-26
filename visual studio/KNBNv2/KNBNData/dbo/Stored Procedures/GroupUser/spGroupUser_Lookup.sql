CREATE PROCEDURE [dbo].[spGroupUser_Lookup]
	@UserId nvarchar(128),
	@BoardId int
AS
BEGIN
	SET NOCOUNT ON

	SELECT [Board].[Id], [Board].[Name], [User].[UserName]
	FROM [dbo].[Board], [dbo].[User], [dbo].[GroupUser]
	WHERE [Board].[Id] = @BoardId OR [User].[Id] = @UserId
END