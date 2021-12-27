create database QLBH
go 
use QLBH
 
create table CongNo(
makhachhang nvarchar(30), 
tenkhachhang nvarchar(255), 
sodienthoai nvarchar(50), 
sotienno decimal(19,4))

insert into CongNo values (1, 'A','123', 111.1)
insert into CongNo values (2, 'B','234', 222.2)
insert into CongNo values (3, 'C','345', 333.3)
insert into CongNo values (4, 'D','567', 444.4)
insert into CongNo values (5, 'E','789', 555.5)

select* from CongNo