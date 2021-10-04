CREATE TABLE [dbo].[GroupUser]
(
	[GroupId] INT NOT NULL IDENTITY, 
    [UserId] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [PK_GroupUser_G-Id_U-Id] PRIMARY KEY ([GroupId], [UserId]), 
    CONSTRAINT [FK_GroupUser_User-Id] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_GroupUser_Group-Id] FOREIGN KEY ([GroupId]) REFERENCES [Group]([Id])
)
