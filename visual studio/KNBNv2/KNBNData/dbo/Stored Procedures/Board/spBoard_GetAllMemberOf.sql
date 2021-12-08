CREATE PROCEDURE [dbo].[spBoard_GetAllMemberOf]
	@UserId nvarchar(128)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [dbo].[BoardGroup]
	--INNER JOIN [dbo].[BoardGroup]
	--ON [Board].[
	--WHERE [Group].[UserId] = @UserId

END