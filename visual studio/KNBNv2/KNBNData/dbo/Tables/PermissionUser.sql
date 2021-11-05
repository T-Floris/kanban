CREATE TABLE [dbo].[PermissionUser]
(
	[PermissionId] INT NOT NULL IDENTITY, 
    [UserId] NVARCHAR(128) NOT NULL, 
    CONSTRAINT [PK_PermissionUser-PermissionId-UserId] PRIMARY KEY ([PermissionId],[UserId]), 
    CONSTRAINT [FK_PermissionUser-PermissionId_Permission-Id] FOREIGN KEY ([PermissionId]) REFERENCES [Permission]([Id]), 
    CONSTRAINT [FK_PermissionUser-UserId_User-Id] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
