create table dbo.List_Claims (
   ID                   int                  not null,
   ID_Pos_Tender        int                  null,
   ID_Claim             int                  null,
   Is_F_Maejuere        bit                  null,
   constraint PK_LIST_CLAIMS primary key (ID)
)