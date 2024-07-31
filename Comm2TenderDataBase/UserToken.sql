CREATE TABLE [dbo].[UserToken]
(
	[UserTokenId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [DateTime] DATETIME NOT NULL, 
    [Data] NVARCHAR(MAX) NOT NULL, 
    [ExpiresAccessDateTime] DATETIME NOT NULL, 
    [ExpiresRefreshDateTime] DATETIME NOT NULL, 
    CONSTRAINT [FK_UserToken_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId])
)
