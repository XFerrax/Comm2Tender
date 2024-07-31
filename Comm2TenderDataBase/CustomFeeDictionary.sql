CREATE TABLE [dbo].[CustomFeeDictionary]
(
	[CustomFeeDictionaryId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MinAmount] DECIMAL(18, 3) NOT NULL, 
    [SummaryCustomFee] DECIMAL(18, 3) NOT NULL
)
