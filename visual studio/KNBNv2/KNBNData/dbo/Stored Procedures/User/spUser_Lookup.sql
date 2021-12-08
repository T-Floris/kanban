CREATE PROCEDURE [dbo].[spUser_Lookup]
	@Id nvarchar(128)
AS
begin
	set nocount on;

	select [User].[Id], [User].[FirstName], [User].[LastName], [User].[EmailAddress], [User].[CreatedDate], [User].[UserName]
	from [dbo].[User]
	where Id = @Id;
end
