CREATE TABLE [dbo].[CustomFeeDictionary]
(
	[CustomFeeDictionaryId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MinAmount] DECIMAL(13, 3) NOT NULL, 
    [SummaryCustomFee] DECIMAL(11, 3) NOT NULL
)
