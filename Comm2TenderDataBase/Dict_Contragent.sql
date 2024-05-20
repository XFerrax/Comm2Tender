create table dbo.Dict_Contragent (
   ID                   int              identity,
   Counterparty         Nvarchar(100)        null,
   System_Num           int                  null,
   Date_Contract        datetime             null,
   IsDirect_Counterparty bit                  null,
   constraint PK_DICT_CONTRAGENT primary key (ID)
)