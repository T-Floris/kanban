CREATE PROCEDURE [dbo].[spGroup_Lookup]
	@groupName nvarchar(128)
AS
begin
	set nocount on;

	select [Id], [UserId], [Name], [Color]
	from [dbo].[Group]
	where [Name] LIKE '%' + @groupName + '%';
end
