CREATE TABLE [dbo].[Permission]
(
	[Id] INT NOT NULL IDENTITY(1, 1), 
    [Title] NVARCHAR(20) NOT NULL, 
<<<<<<< HEAD
    [Description] NVARCHAR(200) NOT NULL, 
    CONSTRAINT [PK_Permission_Id] PRIMARY KEY ([Id]), 
    CONSTRAINT [UK_Permission_Title] UNIQUE ([Title])
=======
    [Description] NVARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Permission-Id] PRIMARY KEY ([Id]), 
>>>>>>> til_m
)
