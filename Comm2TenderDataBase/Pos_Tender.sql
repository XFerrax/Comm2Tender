create table dbo.Pos_Tender (
   ID                   int                  identity,
   Count_Pos            int                  null,
   Position_Price       float                null,
   Delivery_Cost        float                null,
   ID_Tender            int                  null,
   Date_Delivery        date                 null,
   Date_Plan_Delivery   date                 null,
   Count_Day_Delivery      int                  null,
   constraint PK_POS_TENDER primary key (ID), 
    CONSTRAINT [FK_POS_TEND_REFERENCE_LOG_TEND] FOREIGN KEY (ID_Tender) REFERENCES Log_Tender(Id)
)