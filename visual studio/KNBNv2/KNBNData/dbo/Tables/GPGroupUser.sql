CREATE TABLE [dbo].[GPGroupUser]
(
	[GroupPermissonId] INT NOT NULL, 
    [GroupId] INT NOT NULL, 
    [UserId] NVARCHAR(128) NOT NULL,
    CONSTRAINT [PK_GPGroupUser-GroupPermissonId-GroupId-UserId] PRIMARY KEY ([GroupPermissonId],[GroupId],[UserId]), 
    CONSTRAINT [FK_GPGroupUser-GroupPermissonId_GroupPermisson-Id] FOREIGN KEY ([GroupPermissonId]) REFERENCES [GroupPermisson]([Id]), 
    CONSTRAINT [FK_GPGroupUser-GroupId_Group-Id] FOREIGN KEY ([GroupId]) REFERENCES [Group]([Id]),
    CONSTRAINT [FK_GPGroupUser-UserId_User-Id] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
