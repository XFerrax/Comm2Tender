begin transaction

delete from [dbo].[CustomFeeDictionary];

DBCC CHECKIDENT ('[dbo].[CustomFeeDictionary]', RESEED, 0);

insert into [dbo].[CustomFeeDictionary] ([MinAmount], [SummaryCustomFee])
values (       0.0,   775.0),
       (  200000.0,  1550.0),
       (  450000.0,  3100.0),
       ( 1200000.0,  8530.0),
       ( 2700000.0, 12000.0),
       ( 4200000.0, 15500.0),
       ( 5500000.0, 20000.0),
       ( 7000000.0, 23000.0),
       ( 8000000.0, 25000.0),
       ( 9000000.0, 27000.0),
       (10000000.0, 30000.0);

if (select count(*) from [dbo].[Role] r where r.[Name] = 'Администратор') = 0
begin
insert into [dbo].[Role] ([Name])
values ('Администратор')
end;

if (select count(*) from [dbo].[Role] r where r.[Name] = 'Экономист') = 0
begin
insert into [dbo].[Role] ([Name])
values ('Экономист')
end;

if (select count(*) from [dbo].[Role] r where r.[Name] = 'Специалист') = 0
begin
insert into [dbo].[Role] ([Name])
values ('Специалист')
end;

if(select count(*) from [dbo].[User] u where u.[Email] = 'testadmin@tmk-group.com') = 0
insert into [dbo].[User] ([Email], [Name], [Password], [RoleId], [IsActive])
values (
    'testadmin@tmk-group.com', 
    'testadministrator', 
    'FiRK2M%7Q$cqgMz@', 
    (select top(1) r.[RoleId] from [dbo].[Role] r where r.[Name] = 'Администратор'),
    1
)


       
commit