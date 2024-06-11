CREATE TABLE [dbo].[Tender]
(
	[TenderId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Number] NVARCHAR(50) NOT NULL, 
    [Discription] NVARCHAR(50) NOT NULL, 
    [PercentsDictionaryId] INT NOT NULL, 
    [WinnerProposalId] INT NULL, 
    CONSTRAINT [FK_Tender_ToProposal] FOREIGN KEY ([WinnerProposalId]) REFERENCES [Proposal]([ProposalId]), 
    CONSTRAINT [FK_Tender_ToPercentsDictionary] FOREIGN KEY ([PercentsDictionaryId]) REFERENCES [PercentsDictionary]([PercentsDictionaryId])
)
