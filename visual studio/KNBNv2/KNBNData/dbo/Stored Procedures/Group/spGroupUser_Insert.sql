CREATE PROCEDURE [dbo].[spGroupUser_Insert]
	@UserId NVARCHAR(128),
	@GroupId INT
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO [dbo].[GroupUser] ([GroupId], [UserId])
	VALUES (@GroupId, @UserId)
END
