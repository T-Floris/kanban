CREATE PROCEDURE [dbo].[spUser_Insert]
	@Id nvarchar(128),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@EmailAddress nvarchar(256),
	@UserName nvarchar(256)
AS
begin
	set nocount on;

	insert into dbo.[User] ([Id], [FirstName], [LastName], [EmailAddress], [UserName])
	values (@Id, @FirstName, @LastName, @EmailAddress, @UserName);
end
