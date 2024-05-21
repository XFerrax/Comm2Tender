CREATE TABLE [dbo].[Interest_rate]
(
	ID                   int                  identity,
   Rate_CB              float                null,
   Pers_TMK             float                null,
   Pers_Bank            float                null,
   Pers_Customs         float                null,
   Pers_Discount        float                null,
   Pers_Bill_of_Creadit float                null,
   constraint PK_INTEREST_RATE primary key (ID)
)
