CREATE PROCEDURE [dbo].[spGroup_Delete]
	@Id INT
AS
BEGIN
	DELETE
	FROM [dbo].[GroupUser]
	WHERE [GroupId] = @Id

	DELETE
	FROM [dbo].[BoardGroup]
	WHERE [GroupId] = @Id

	DELETE
	FROM [dbo].[Group]
	WHERE [Id] = @Id
END
