CREATE TABLE [dbo].[Board]
(
	[Id] INT NOT NULL IDENTITY(1,1),
    [Name] NCHAR(10) NOT NULL, 
	[UserId] nvarchar(128) NOT NULL, 
    CONSTRAINT [PK_Board_Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Board_User-Id] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
