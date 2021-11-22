CREATE PROCEDURE [dbo].[spGroupUserNotIn_Lookup]
	@groupId INT,
	@username NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON

	SELECT [User].[Id], [User].[FirstName],[User].[LastName], [User].[UserName], [User].[EmailAddress] 
	from [dbo].[User]
	where [User].[Id] NOT IN (SELECT [GroupUser].[UserId] FROM [GroupUser] WHERE [GroupUser].[GroupId] = @groupId ) AND [User].[UserName] like '%' + @username + '%'
END