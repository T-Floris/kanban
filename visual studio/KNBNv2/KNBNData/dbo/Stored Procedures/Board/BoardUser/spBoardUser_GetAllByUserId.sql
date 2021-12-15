CREATE PROCEDURE [dbo].[spBoardUser_GetAllByUserId]
	@UserId nvarchar(128)
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT *
	FROM [dbo].[BoardUser] bu 
	where bu.UserId = @UserId

END
