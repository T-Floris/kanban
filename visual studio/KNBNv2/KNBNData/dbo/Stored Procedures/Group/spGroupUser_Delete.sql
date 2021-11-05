CREATE PROCEDURE [dbo].[spGroupUser_Delete]
	@UserId NVARCHAR(128),
	@GroupId INT
AS
BEGIN
	SET NOCOUNT ON

	DELETE 
	FROM [dbo].[GroupUser]
	WHERE [GroupUser].[GroupId] = @GroupId AND [GroupUser].[UserId] = @UserId
	

END
