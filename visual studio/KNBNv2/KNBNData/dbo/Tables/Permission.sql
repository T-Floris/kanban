CREATE TABLE [dbo].[Permission]
(
	[Id] INT NOT NULL IDENTITY(1, 1), 
    [Title] NVARCHAR(20) NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Permission-Id] PRIMARY KEY ([Id]), 
)
