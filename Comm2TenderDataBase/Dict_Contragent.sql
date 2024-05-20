create table dbo.Dict_Contragent (
   ID                   int              identity,
   Counterparty         Nvarchar(100)        null,
   System_Num           int                  null,
   Date_Contract        datetime             null,
   IsDirect_Counterparty bit                  null,
   Date_Reg_Contragent datetime not null,
   [Date_Partnership] DATE NOT NULL, 
    constraint PK_DICT_CONTRAGENT primary key (ID)
)