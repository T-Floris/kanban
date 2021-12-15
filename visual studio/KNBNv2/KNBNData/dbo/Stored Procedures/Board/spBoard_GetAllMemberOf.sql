CREATE PROCEDURE [dbo].[spBoard_GetAllMemberOf]
	@UserId nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [dbo].[Board] b 
	where b.UserId != @UserId
	--inner JOIN [dbo].[GroupUser] gu ON gu.UserId = b.UserId
	--WHERE [gu].[UserId] = @UserId and [b].[UserId] != @UserId

	--INNER JOIN [dbo].[BoardGroup]
	--ON [Board].[
	--WHERE [Group].[UserId] = @UserId

END