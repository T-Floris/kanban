CREATE PROCEDURE [dbo].[spGroupPermisson_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT [GroupPermisson].[Id], [GroupPermisson].[Title], [GroupPermisson].[Description]
	FROM [dbo].[GroupPermisson]
END