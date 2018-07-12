IF NOT EXISTS (SELECT TOP 1 1 FROM Roles)
BEGIN

	INSERT INTO [dbo].[Roles] (RoleCode, RoleName) 
	VALUES ('-', '--Please select')

	INSERT INTO [dbo].[Roles] (RoleCode, RoleName)
	VALUES ('IT', 'IT Pro')

	INSERT INTO [dbo].[Roles] (RoleCode, RoleName)
	VALUES ('AC', 'Architect')

	INSERT INTO [dbo].[Roles] (RoleCode, RoleName)
	VALUES ('DV', 'Developer')

	INSERT INTO [dbo].[Roles] (RoleCode, RoleName)
	VALUES ('DB', 'Database Administrator')

END

GO