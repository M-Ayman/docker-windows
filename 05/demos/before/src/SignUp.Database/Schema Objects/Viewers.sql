CREATE TABLE [dbo].[Viewers]
(
	[ViewerId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(200) NOT NULL, 
    [RoleId] INT NULL, 
    [CountryId] INT NULL, 
    [AuditTimestamp] DATETIME2 NULL, 
    [AuditProcess] NVARCHAR(50) NULL, 
    CONSTRAINT [FK_Viewers_ToRoles] FOREIGN KEY (RoleId) REFERENCES Roles(RoleId), 
    CONSTRAINT [FK_Viewers_ToCountries] FOREIGN KEY (CountryId) REFERENCES Countries(CountryId)
)
