﻿CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id nvarchar(128)
AS
begin
	set nocount on;

	DELETE
	FROM [dbo].[User]
	where Id = @Id;
end
