CREATE TABLE [dbo].[GroupUser]
(
	[GroupId] INT NOT NULL, 
    [UserId] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [PK_GroupUser-GroupId-UserId] PRIMARY KEY ([GroupId], [UserId]), 
    CONSTRAINT [FK_GroupUser-UserId_User-Id] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_GroupUser-GroupId_Group-Id] FOREIGN KEY ([GroupId]) REFERENCES [Group]([Id])
)
