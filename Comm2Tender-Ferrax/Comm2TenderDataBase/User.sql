CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [RoleId] INT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [IsActive] BIT NOT NULL, 
    CONSTRAINT [FK_User_ToRole] FOREIGN KEY ([RoleId]) REFERENCES [Role]([RoleId])
)
