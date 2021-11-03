CREATE PROCEDURE [dbo].[spGroup_UserToAdd]
@GroupId int
AS
begin
	set nocount on;

	SELECT [User].[UserName]
	from [dbo].[User]
	where [User].[Id] NOT IN (SELECT [GroupUser].[UserId] FROM [GroupUser] WHERE [GroupUser].[GroupId] = @GroupId ) 

end
