CREATE TABLE [dbo].[Countries]
(
	[CountryId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CountryCode] NVARCHAR(10) NOT NULL, 
    [CountryName] NVARCHAR(50) NOT NULL
)
