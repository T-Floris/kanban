CREATE TABLE [dbo].[BoardUser]
(
	[BoardId] INT NOT NULL, 
	[UserId] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [PK_BoardUser_Board-Id_User-Id] PRIMARY KEY ([UserId], [BoardId]), 
    CONSTRAINT [FK_BoardUser_User-Id] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
	CONSTRAINT [FK_BoardUser_Board-Id] FOREIGN KEY ([BoardId]) REFERENCES [Board]([Id])

)
