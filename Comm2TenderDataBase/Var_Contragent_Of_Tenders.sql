create table dbo.Var_Contragent_Of_Tenders (
   ID_Contragent        int                  null,
   ID_Tenders           int                  null,
   IsTMK                bit                  null,
   IsContragent         bit                  null,
   ID_Interest_rate     int                  null,
   ID_Сustoms_duty      int                  null,
   ID_Economic_effect   int                  identity,
   Reliability_Assessment float                null,
   constraint PK_Var_Contragent_Of_Tenders primary key (ID_Economic_effect)
)