CREATE TABLE [dbo].[BoardGroup]
(
	[GroupId] INT NOT NULL, 
    [BoardId] INT NOT NULL, 
    CONSTRAINT [PK_BoardGroup-GroupId-BoardId] PRIMARY KEY ([GroupId], [BoardId]), 
    CONSTRAINT [FK_BoardGroup-GroupId_Group-Id] FOREIGN KEY ([GroupId]) REFERENCES [Group]([Id]),
    CONSTRAINT [FK_BoardGroup-BoardId_Board_Id] FOREIGN KEY ([BoardId]) REFERENCES [Board]([Id])
)
