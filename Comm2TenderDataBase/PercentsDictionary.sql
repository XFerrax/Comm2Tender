CREATE TABLE [dbo].[PercentsDictionary]
(
	[PercentsDictionaryId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DateEnter] DATETIME NOT NULL, 
    [RefinancingRate] DECIMAL(9, 3) NOT NULL, 
    [Tmk] DECIMAL(9, 3) NOT NULL, 
    [BankGuarantee] DECIMAL(9, 3) NOT NULL, 
    [Credit] DECIMAL(9, 3) NOT NULL, 
    [CustomDuty] DECIMAL(9, 3) NOT NULL, 
    [Discount] DECIMAL(9, 3) NOT NULL, 
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Ставка ЦБ РФ',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PercentsDictionary',
    @level2type = N'COLUMN',
    @level2name = N'RefinancingRate'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Банковская гарантия',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PercentsDictionary',
    @level2type = N'COLUMN',
    @level2name = N'BankGuarantee'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'% ТМК',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PercentsDictionary',
    @level2type = N'COLUMN',
    @level2name = N'Tmk'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Таможенная пошлина',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PercentsDictionary',
    @level2type = N'COLUMN',
    @level2name = N'CustomDuty'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'% Аккредитива',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PercentsDictionary',
    @level2type = N'COLUMN',
    @level2name = N'Credit'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Ставка дисконтирования',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'PercentsDictionary',
    @level2type = N'COLUMN',
    @level2name = N'Discount'