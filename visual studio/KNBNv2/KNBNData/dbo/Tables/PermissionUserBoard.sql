CREATE TABLE [dbo].[PermissionUserBoard]
(
	[PermissionId] INT NOT NULL,
    [UserId] NVARCHAR(128) NOT NULL,
    [BoardId] INT NOT NULL,
    CONSTRAINT [PK_Permi ssionUserBoard_PermissionId_UserId_BoardId] PRIMARY KEY ([PermissionId],[UserId],[BoardId]),
    CONSTRAINT [FK_PermissionUserBoard_Permission-Id] FOREIGN KEY ([PermissionId]) REFERENCES [Permission]([Id]),
    CONSTRAINT [FK_PermissionUserBoard_User-Id] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]),
    CONSTRAINT [FK_PermissionUserBoard_Board-Id] FOREIGN KEY ([BoardId]) REFERENCES [Board]([Id])
)
