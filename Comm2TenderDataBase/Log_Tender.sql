create table dbo.Log_Tender (
  ID                   int                  identity,
   ID_Counterparty      int                  null,
   Num_tender           nvarchar(100)        null,
   ID_Interest_rate     int                  null,
   ID_Сustoms_duty      int                  null,
   Reliability_Assessment float                null,
   Date_Tender          date                 null,
   constraint PK_LOG_TENDER primary key (ID), 
    constraint FK_LOG_TEND_REFERENCE_DICT_CON foreign key (ID_Counterparty) references Dict_Contragent (ID),
    constraint FK_LOG_TEND_REFERENCE_INTEREST foreign key (ID_Interest_rate) references Interest_rate (ID),
    constraint FK_LOG_TEND_REFERENCE_СUSTOMS_ foreign key (ID_Сustoms_duty) references Сustoms_duty (ID)
)