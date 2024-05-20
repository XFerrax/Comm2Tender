create table dbo.Log_Tender (
   ID                   int                  identity,
   ID_Counterparty      int                  null,
   Num_tender           nvarchar(20)         null,
   Rate_CB              float                null,
   Pers_TMK             float                null,
   Pers_Bank            float                null,
   Pers_Customs         float                null,
   Pers_Discount        float                null,
   constraint PK_LOG_TENDER primary key (ID)
)