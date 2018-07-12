CREATE TABLE [dbo].[ViewerInterests]
(
	[ViewerInterestId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ViewerId] INT NOT NULL, 
    [InterestId] INT NOT NULL, 
    CONSTRAINT [FK_ViewerInterests_ToViewers] FOREIGN KEY (ViewerId) REFERENCES Viewers(ViewerId), 
    CONSTRAINT [FK_ViewerInterests_ToInterests] FOREIGN KEY (InterestId) REFERENCES Interests(InterestId)
)
