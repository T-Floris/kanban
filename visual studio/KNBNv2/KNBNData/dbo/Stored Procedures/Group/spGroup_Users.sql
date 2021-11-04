CREATE PROCEDURE [dbo].[spGroup_Users]
@GroupId int
AS
begin
	set nocount on;
/*
	SELECT [User].[UserName]
	FROM [dbo].[User]
	Inner join [GroupUser] 
	ON [GroupUser].[GroupId] = @GroupId
	where [GroupUser].[UserId] != [User].[Id]
--	select [User].[UserName]
*/


	SELECT [User].[Id], [User].[FirstName],[User].[LastName], [User].[UserName], [User].[EmailAddress] 
	from [dbo].[User]
	where [User].[Id]  IN (SELECT [GroupUser].[UserId] FROM [GroupUser] WHERE [GroupUser].[GroupId] = @GroupId ) 
	/*
	left JOIN [GroupUser] ON [GroupUser].[UserId] = [User].[Id]
	where [GroupUser].[GroupId] = @GroupId 
	*/
	--where [GroupUser].[GroupId] = @GroupId 
end
