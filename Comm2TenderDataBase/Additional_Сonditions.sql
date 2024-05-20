CREATE TABLE [dbo].[Additional_Сonditions]
(
	ID                   int                  identity,
   Expireence           float                null,
   Market               float                null,
   Fines                float                null,
   IsDirect_Counterparty bit                  null,
   Inventory_Count      float                null,
   Equipment            float                null,
   Geografy             float                null,
   Loyality             float                null,
   Complaint            float                null,
   Date_Insert          date                 null,
   constraint PK_ADDITIONAL_СONDITIONS primary key (ID)
)
