CREATE VIEW [dbo].[viewGroupMembers]
	AS SELECT [dbo].[Group].[Name] FROM [Group], [User], [GroupUser]
	
