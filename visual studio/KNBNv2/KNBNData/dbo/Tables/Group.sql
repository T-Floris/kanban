﻿CREATE TABLE [dbo].[Group]
(
	[Id] INT NOT NULL IDENTITY(1, 1), 
    [UserId] NVARCHAR(128) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL, 
    [Color] NVARCHAR(7) NOT NULL, 
    CONSTRAINT [PK_Group-Id] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Group-UserId_User-Id] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)