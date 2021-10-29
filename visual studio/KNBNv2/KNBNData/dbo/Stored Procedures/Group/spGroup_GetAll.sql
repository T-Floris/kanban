CREATE PROCEDURE [dbo].[spGroup_GetAll]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT [dbo].[Group].[Name]
	FROM [dbo].[Group]
END