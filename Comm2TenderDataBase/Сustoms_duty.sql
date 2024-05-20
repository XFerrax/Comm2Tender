CREATE TABLE [dbo].[Сustoms_duty]
(
	ID                   int                  identity,
   Min_Price            float                null,
   Max_Price            float                null,
   Sum_Сustoms_duty     float                null,
   constraint PK_СUSTOMS_DUTY primary key (ID)
)
