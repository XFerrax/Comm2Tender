create table dbo.Pos_Tender (
   ID                   int                  not null,
   _Pos                 int                  null,
   Delivery_Cost        float                null,
   ID_Tender            int                  null,
   Position_Price       decimal              not null,
   Date_Delivery        date                 not null,
   Date_Plan_Delivery   date                 not null
   constraint PK_POS_TENDER primary key (ID), 
    CONSTRAINT [FK_POS_TEND_REFERENCE_LOG_TEND] FOREIGN KEY (ID_Tender) REFERENCES Log_Tender(Id)
)