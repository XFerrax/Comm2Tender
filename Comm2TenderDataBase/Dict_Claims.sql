create table dbo.Dict_Claims (
   ID                   int                  not null,
   Name_Claim           nvarchar(100)        null,
   Group_Claim          int                  null,
   Weight_Claim         float                null,
   constraint PK_DICT_CLAIMS primary key (ID)
)