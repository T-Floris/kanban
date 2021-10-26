CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON

	DELETE
	FROM [dbo].[PermissionUserBoard]
	WHERE [UserId] = @Id;

	DELETE
	FROM [dbo].[GroupUser]
	WHERE [UserId] = @Id;

	DELETE
	FROM [dbo].[BoardUser]
	WHERE [UserId] = @Id;

	UPDATE [dbo].[Board]
	SET [UserId] = NULL
	WHERE [UserId] = @Id

	DELETE
	FROM [dbo].[User]
	WHERE [Id] = @Id;
END
