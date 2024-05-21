create table dbo.Dict_Claims (
   ID                   int                  identity,
   Name_Claim           nvarchar(100)        null,
   Weight_Claim         float                null,
   constraint PK_DICT_CLAIMS primary key (ID)
)