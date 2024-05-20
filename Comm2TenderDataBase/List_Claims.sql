create table dbo.List_Claims (
   ID                   int                  not null,
   ID_Pos_Tender        int                  null,
   ID_Claim             int                  null,
   Is_F_Maejuere        bit                  null,
   constraint PK_LIST_CLAIMS primary key (ID), 
    CONSTRAINT [FK_LIST_CLA_REFERENCE_POS_TEND] FOREIGN KEY (ID_Pos_Tender) REFERENCES Pos_Tender(Id), 
    CONSTRAINT [FK_LIST_CLA_REFERENCE_DICT_CLA] FOREIGN KEY (ID_Claim) REFERENCES Dict_Claims(Id)
)