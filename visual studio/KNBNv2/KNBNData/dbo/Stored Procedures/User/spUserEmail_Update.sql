CREATE PROCEDURE [dbo].[spUserEmail_Update]
	@Id nvarchar(128),
	@NewEmail nvarchar(256)
AS
begin
	set nocount on;

	UPDATE [User]
	SET [EmailAddress] = @NewEmail
	WHERE [Id] = @Id;
end