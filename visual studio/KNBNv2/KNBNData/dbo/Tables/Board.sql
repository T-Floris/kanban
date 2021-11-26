CREATE TABLE [dbo].[Board]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[UserId] nvarchar(128) NULL, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_Board-Id] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_Board-UserId_User-Id] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
