CREATE PROCEDURE [dbo].[spBord_Delete]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE
	FROM [dbo].[Table]
	WHERE [BoardId] = @Id
	
	DELETE
	FROM [dbo].[Board]
	WHERE [Id] = @Id

END
