begin transaction
delete from dbo.[Dict_Claims]

INSERT INTO dbo.[Dict_Claims]
           ([Name_Claim]
           ,[Weight_Claim])
     VALUES
           ('были нарушения сроков поставки' ,0.0233),
      ('были нарушения внутренних норм' ,0.025),
      ('были претензии к качеству товара/услуги' ,0.05583)

delete from dbo.[Сustoms_duty]

INSERT INTO dbo.[Сustoms_duty]
           ([Min_Price]
           ,[Max_Price]
           ,[Sum_Сustoms_duty])
     VALUES
           (0.00,199999.99,775.00),
       (200000.00,449999.99,1550.00),
       (450000.00,1199999.99,3100.00),
(1200000.00,2699999.99,8530.00),
(2700000.00,4199999.99,12000.00),
(4200000.00,5499999.99,15500.00),
(5500000.00,6999999.99,20000.00),
(7000000.00,7999999.99,23000.00),
(8000000.00,8999999.99,25000.00),
(9000000.00,9999999.99,27000.00),
(10000000.00,null,30000.00)
    
delete from dbo.[Interest_rate]

INSERT INTO dbo.[Interest_rate]
           ([Rate_CB]
           ,[Pers_TMK]
           ,[Pers_Bank]
           ,[Pers_Customs]
           ,[Pers_Discount]
           ,[Pers_Bill_of_Creadit])
     VALUES
           (0.12,0.02,0.02,0.01,0.12,0.01)

commit