CREATE TABLE [dbo].[Agent]
(
	[AgentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] VARCHAR(100) NOT NULL,
    [AgentRegistrationDate] DATETIME NOT NULL, 
    [AgentSystemRegistrationDate] DATETIME NOT NULL, 
    [OGRN] DECIMAL(15) NOT NULL, 
    [INN] DECIMAL(12) NOT NULL, 
    [KPP] DECIMAL(9) NOT NULL
)
