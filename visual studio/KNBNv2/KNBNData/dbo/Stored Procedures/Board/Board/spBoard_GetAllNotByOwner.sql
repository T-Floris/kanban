CREATE PROCEDURE [dbo].[spBoard_GetAllNotByOwner]
	@UserId nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON

	SELECT * 
	FROM [dbo].[Board] b
	where b.UserId != @UserId

END
