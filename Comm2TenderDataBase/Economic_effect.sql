create table dbo.Economic_effect (
   ID                   int                  null,
   Prepaid_expense      float                null,
   Period_of_execution  int                  null,
   Postpayment_period   int                  null,
   ID_Tendes            int                  null, 
    CONSTRAINT [FK_ECONOMIC_REFERENCE_LOG_TEND] FOREIGN KEY (ID_Tendes) REFERENCES Log_Tender(Id)
)