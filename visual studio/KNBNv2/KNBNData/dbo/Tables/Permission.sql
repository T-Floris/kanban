CREATE TABLE [dbo].[Permission]
(
	[Id] INT NOT NULL IDENTITY, 
    [Title] NCHAR(20) NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Permission_Id] PRIMARY KEY ([Id]), 
)
