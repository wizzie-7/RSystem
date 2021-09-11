use RSystem
create table Restaurant
(
RestId int Primary key,
RestName varchar(100) not null,
RestPhoneNo bigint unique not null,
RestAdreess varchar(100) not null,
RestOpeningTime time not null,
RestClosingTime time not null,
RestCuisine varchar(100) not null,
RestStatus varchar(10) not null
)
 select * from Restaurant

 insert into Restaurant VALUES (1001,'Suruchi Restaurant',1234567891,'MCCH,Panvel','08:00:00','20:00:00','Indian','Active')
 insert into Restaurant VALUES (1002,'Krunal Chinese',1536247896,'Market Yard,Panvel','12:00:00','23:00:00','Chinese','Active')
 insert into Restaurant VALUES (1003,'Pancharatn Restaurant',1236547891,'Panchratn Naka,Panvel','08:00:00','22:00:00','Indian','Active')
 insert into Restaurant VALUES (1004,'Welcome Restaurant',1589631477,'Panchratn Naka,Panvel','19:00:00','08:00:00','Indian','Deactive')
 insert into Restaurant VALUES (1005,'Peace Park Restaurant',1593574862,'New Panvel,Panvel','08:00:00','22:00:00','Italian','Active')
 insert into Restaurant VALUES (1006,'McDonalds Restaurant',1517532684,'Kalamboli,Panvel','00:01:01','23:59:59','Maxican','Active')
 insert into Restaurant VALUES (1007,'Kokan Kinara Restaurant',1452789362,'Panchratn Naka,Panvel','08:00:00','22:00:00','Indian','Active')
 insert into Restaurant VALUES (1008,'Sai Deep Restaurant',1753852891,'Palaspe Gaon,Panvel','22:00:00','06:00:00','Indian','Deactive')
 insert into Restaurant VALUES (1009,'Garden Restaurant',1753486891,'Garden Hotel,Panvel','21:00:00','08:00:00','Indian','Deactive')
 insert into Restaurant VALUES (1010,'Malvan Tadka Restaurant',1759511891,'Kamothe,Panvel','08:00:00','22:00:00','Indian','Active')

  select * from Restaurant

  DROP table Restaurant