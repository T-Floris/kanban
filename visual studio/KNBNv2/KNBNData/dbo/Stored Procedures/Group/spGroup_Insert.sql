CREATE PROCEDURE [dbo].[spGroup_Insert]
	@UserId nvarchar(128),
	@Name nvarchar(50),
	@Color NVARCHAR(7),
	@GroupId int = 0
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO [dbo].[Group] ([UserId], [Name], [Color])
	VALUES (@UserId, @Name, @Color)

	SELECT @GroupId = scope_identity();

	INSERT INTO [dbo].[GroupUser] ([GroupId], [UserId])
	VALUES (@GroupId, @UserId)


END