CREATE PROCEDURE [dbo].[spGroup_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT [Group].[Id], [User].[UserName], [Group].[Name]
	FROM [dbo].[Group], [dbo].[User]
	WHERE [User].[Id] = [Group].[UserId]
END