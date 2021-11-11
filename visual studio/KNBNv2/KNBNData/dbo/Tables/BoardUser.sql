CREATE TABLE [dbo].[BoardUser]
(
	[BoardId] INT NOT NULL, 
	[UserId] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [PK_BoardUser-BoardId-UserId] PRIMARY KEY ([UserId], [BoardId]), 
    CONSTRAINT [FK_BoardUser-UserId_User-Id] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_BoardUser-BoardId_Board-Id] FOREIGN KEY ([BoardId]) REFERENCES [Board]([Id])

)
