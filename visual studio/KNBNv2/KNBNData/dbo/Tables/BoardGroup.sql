CREATE TABLE [dbo].[BoardGroup]
(
	[GroupId] INT NOT NULL, 
    [BoardId] INT NOT NULL, 
    CONSTRAINT [PK_BoardGroup_Group-Id_Board-Id] PRIMARY KEY ([GroupId], [BoardId]), 
    CONSTRAINT [FK_BoardGroup_Group_Id] FOREIGN KEY ([GroupId]) REFERENCES [Group]([Id]),
    CONSTRAINT [FK_BoardGroup_Board_Id] FOREIGN KEY ([BoardId]) REFERENCES [Board]([Id])
)
