CREATE PROCEDURE [dbo].[spTable_Delete]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;
	
	DELETE
	FROM [dbo].[Table]
	WHERE [Id] = @Id

END
