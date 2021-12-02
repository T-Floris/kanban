CREATE PROCEDURE[dbo].[spBoard_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

SELECT[Board].[Id], [Board].[Name], [Board].[UserId], [Board].[Color]
FROM[dbo].[Board]
END