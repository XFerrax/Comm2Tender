create table dbo.Economic_effect (
   ID                   int                  identity,
   Prepaid_expense      float                null,
   Period_of_execution  int                  null,
   Postpayment          int                  null,
   Postpayment_period   int                  null,
   ID_Tendes            int                  null,
   Prepaid_expense2     float                null,
   Period_of_execution2 int                  null,
   Postpayment2         int                  null,
   Postpayment_period2  int                  null,
   Prepaid_expense3     float                null,
   Period_of_execution3 int                  null,
   Postpayment3         int                  null,
   Postpayment_period3  int                  null,
   IsAccredetive        bit                  null,
   IsCustoms_duty       bit                  null,
   IsCustoms_fee        bit                  null,
   IsBank_guarantee     bit                  null
   constraint PK_ECONOMIC_EFFECT primary key (ID),
    CONSTRAINT [FK_ECONOMIC_REFERENCE_LOG_TEND] FOREIGN KEY (ID_Tendes) REFERENCES Log_Tender(Id)
)