CREATE PROCEDURE [dbo].[spGroupUserPermission_Get]
	@groupId int,
	@userId NVARCHAR(128)
AS
begin
	set nocount on;

	SELECT *
	FROM [GPGroupUser], [GroupPermisson]
	WHERE [GPGroupUser].[GroupId] = @groupId AND [GPGroupUser].[UserId] = @userId
END
