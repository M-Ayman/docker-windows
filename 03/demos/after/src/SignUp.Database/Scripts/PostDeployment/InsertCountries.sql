IF NOT EXISTS (SELECT TOP 1 1 FROM Countries)
BEGIN

	INSERT INTO [dbo].[Countries] (CountryCode, CountryName)
	VALUES ('-', '--Please select')

	INSERT INTO [dbo].[Countries] (CountryCode, CountryName)
	VALUES ('GBR', 'United Kingdom')

	INSERT INTO [dbo].[Countries] (CountryCode, CountryName)
	VALUES ('USA', 'United States')

	INSERT INTO [dbo].[Countries] (CountryCode, CountryName)
	VALUES ('PT', 'Portugal')

	INSERT INTO [dbo].[Countries] (CountryCode, CountryName)
	VALUES ('NOR', 'Norway')

	INSERT INTO [dbo].[Countries] (CountryCode, CountryName)
	VALUES ('SWE', 'Sweden')

	INSERT INTO [dbo].[Countries] (CountryCode, CountryName)
	VALUES ('IRE', 'Ireland')

END

GO