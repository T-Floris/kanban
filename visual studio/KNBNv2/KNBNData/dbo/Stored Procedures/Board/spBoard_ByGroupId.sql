CREATE PROCEDURE [dbo].[spBoard_ByGroupId]
	@groupId int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [dbo].[Board]
	INNER JOIN [dbo].[BoardGroup]
	ON [BoardGroup].[BoardId] = @groupId

END