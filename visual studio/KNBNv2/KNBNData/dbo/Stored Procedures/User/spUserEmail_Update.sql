CREATE PROCEDURE [dbo].[spUserEmail_Update]
	@Id nvarchar(128),
	@NewEmail nvarchar(256)
AS
begin
	set nocount on;

	UPDATE [User]
	SET [Id] = [Id], [FirstName] = [FirstName], [LastName] = [LastName], [EmailAddress] = @NewEmail, [UserName] = [UserName], [CreatedDate] = [CreatedDate]
	WHERE [Id] = @Id;
end