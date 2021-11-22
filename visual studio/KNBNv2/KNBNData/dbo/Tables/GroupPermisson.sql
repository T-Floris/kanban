CREATE TABLE [dbo].[GroupPermisson]
(
	[Id] INT NOT NULL IDENTITY(1, 1), 
    [Title] NVARCHAR(20) NOT NULL, 
    [Description] NVARCHAR(500) NOT NULL, 
    CONSTRAINT [PK_GroupPermission-Id] PRIMARY KEY ([Id]), 
)
