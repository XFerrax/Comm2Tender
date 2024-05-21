﻿CREATE TABLE [dbo].[Economic_effect_Var]
(
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
   IsBank_guarantee     bit                  null,
   constraint PK_Economic_effect_Var primary key (ID),
   constraint FK_ECONOMIC_REFERENCE_VAR_CONT foreign key (ID) references Var_Contragent_Of_Tenders (ID_Economic_effect)
)
