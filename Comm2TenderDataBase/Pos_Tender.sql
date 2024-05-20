create table dbo.Pos_Tender (
   ID                   int                  not null,
   _Pos                 int                  null,
   Delivery_Cost        float                null,
   ID_Tender            int                  null,
   constraint PK_POS_TENDER primary key (ID)
)