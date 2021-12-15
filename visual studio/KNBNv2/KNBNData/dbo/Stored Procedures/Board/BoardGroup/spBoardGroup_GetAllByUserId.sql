CREATE PROCEDURE [dbo].[spBoardGroup_GetAllByUserId]
	@UserId nvarchar(128)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT *
	FROM [dbo].[BoardUser] bu 
	where bu.UserId = @UserId

END
