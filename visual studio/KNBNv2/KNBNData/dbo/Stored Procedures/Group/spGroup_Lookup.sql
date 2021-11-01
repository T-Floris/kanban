CREATE PROCEDURE [dbo].[spGroup_Lookup]
	@Name nvarchar(128)
AS
begin
	set nocount on;

	select [Id], [UserId], [Name], [Color]
	from [dbo].[Group]
	where [Name] = @Name;
end
