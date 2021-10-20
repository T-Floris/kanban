CREATE PROCEDURE [dbo].[spUser_Update]
	@Id nvarchar(128),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@EmailAddress nvarchar(256),
	@UserName nvarchar(256)
AS
begin
	set nocount on;

	UPDATE [User]
	SET Id = Id, FirstName = @FirstName, LastName = @LastName, EmailAddress = @EmailAddress, UserName = @UserName, CreatedDate = CreatedDate
	WHERE Id = @Id;
end