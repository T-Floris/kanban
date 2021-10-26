CREATE PROCEDURE [dbo].[spPermission_Delete]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DELETE
	FROM [dbo].[PermissionUserBoard]
	WHERE [PermissionId] = @Id
	
	DELETE
	FROM [dbo].[Permission]
	where Id = @Id;
END
