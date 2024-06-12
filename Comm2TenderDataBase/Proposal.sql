CREATE TABLE [dbo].[Proposal]
(
	[ProposalId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AgentId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [TenderId] INT NOT NULL, 
    [CountPos] INT NOT NULL, 
    [PositionPrice] DECIMAL(8, 3) NOT NULL, 
    [DeliveryCost] DECIMAL(8, 3) NOT NULL, 
    [DeliveryTime] INT NOT NULL, 
    [PrepaidExpense1] DECIMAL(8, 3) NOT NULL, 
    [PrepaidExpense2] DECIMAL(8, 3) NOT NULL, 
    [PrepaidExpense3] DECIMAL(8, 3) NOT NULL, 
    [PeriodOfExecution1] INT NOT NULL, 
    [PeriodOfExecution2] INT NOT NULL, 
    [PeriodOfExecution3] INT NOT NULL, 
    [PostPaymant1] DECIMAL(8, 3) NOT NULL, 
    [PostPaymant2] DECIMAL(8, 3) NOT NULL, 
    [PostPaymant3] DECIMAL(8, 3) NOT NULL, 
    [PostPaymantPeriod1] INT NOT NULL, 
    [PostPaymantPeriod2] INT NOT NULL, 
    [PostPaymantPeriod3] INT NOT NULL, 
    [Accreditive] BIT NOT NULL, 
    [BankGuarantee] BIT NOT NULL, 
    [CustomDuty] BIT NOT NULL, 
    [CustomFee] BIT NOT NULL, 
    [MissingDeadlines] BIT NOT NULL, 
    [PoorQuality] BIT NOT NULL, 
    [NormsViolated] BIT NOT NULL, 
    [ExperienceCooperation] BIT NOT NULL, 
    [ExperienceMarket] BIT NOT NULL, 
    [Fines] BIT NOT NULL, 
    [Intermediary] BIT NOT NULL, 
    [ProductionAndInventory] BIT NOT NULL, 
    [ModernEquipment] BIT NOT NULL, 
    [Georgraphy] BIT NOT NULL, 
    [Concessions] BIT NOT NULL, 
    [Complaints] BIT NOT NULL, 
    CONSTRAINT [FK_Proposal_ToAgent] FOREIGN KEY ([AgentId]) REFERENCES [Agent]([AgentId]), 
    CONSTRAINT [FK_Proposal_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([UserId]),
    CONSTRAINT [FK_Proposal_ToTender] FOREIGN KEY ([TenderId]) REFERENCES [Tender]([TenderId])
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Количество товара(услуг), ед',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'CountPos'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Стоимость 1 ед товара(услуги)',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'PositionPrice'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Стоимость доставки, руб.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'DeliveryCost'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Сроки поставки, дн',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'DeliveryTime'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Аванс 1',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'PrepaidExpense1'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Аванс 2',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'PrepaidExpense2'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Аванс 3',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'PrepaidExpense3'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Срок аванса 1, дн',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'PeriodOfExecution1'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Срок аванса 2, дн',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'PeriodOfExecution2'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Срок аванса 3, дн',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'PeriodOfExecution3'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Постоплата 1, %',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'PostPaymant1'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Постоплата 2, %',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'PostPaymant2'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Постоплата 3, %',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'PostPaymant3'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Срок постоплаты 1, дн',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'PostPaymantPeriod1'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Срок постоплаты 2, дн',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'PostPaymantPeriod2'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Срок постоплаты 3, дн',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'PostPaymantPeriod3'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Аккредитив',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'Accreditive'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Банковская гарантия',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'BankGuarantee'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Таможенная пошлина',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'CustomDuty'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Таможенный сбор',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'CustomFee'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Были нарушения сроков поставки',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'MissingDeadlines'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Были претензии к качеству товара/услуги',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'PoorQuality'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Были нарушения внутренних норм',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'NormsViolated'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Опыт работы с контр агентом',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'ExperienceCooperation'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Опыт работы на рынке',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'ExperienceMarket'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Штрафы и судебные издержки',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'Fines'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Посредник или производитель. True - посредник, False - производитель.',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'Intermediary'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Производство и складские запасы',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'ProductionAndInventory'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Наличие современного оборудования',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'ModernEquipment'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Географическая близость к заказчику',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'Georgraphy'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Лояльность в рамках тендера',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'Concessions'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Наличие рекламаций',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'Proposal',
    @level2type = N'COLUMN',
    @level2name = N'Complaints'