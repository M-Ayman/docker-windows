CREATE TABLE [dbo].[Interests]
(
	[InterestId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [InterestCode] NVARCHAR(10) NOT NULL, 
    [InterestName] NVARCHAR(50) NOT NULL, 
    [IsActive] BIT NOT NULL
)
