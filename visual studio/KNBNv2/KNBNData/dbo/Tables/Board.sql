CREATE TABLE [dbo].[Board]
(
	[Id] INT NOT NULL,
	[UserId] nvarchar(128) NOT NULL, 
    [Name] NCHAR(10) NOT NULL, 
    CONSTRAINT [PK_Board_Id] PRIMARY KEY ([Id])
)
