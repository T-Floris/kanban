﻿CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL IDENTITY(1, 1),
	[BoardId] INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Table_Id] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Table_Board_Id] FOREIGN KEY ([Id]) REFERENCES [Board]([Id])
)
