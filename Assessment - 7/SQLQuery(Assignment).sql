create database LibraryDB
use LibraryDB

create table Books
(BookId int primary key,
Title nvarchar(100)not null,
Author nvarchar(50)not null,
Genre nvarchar(20)not null,
Quantity int)

insert into Books values (1,'Hear Yourself','Prem Rawat','Self-Help',5),
(2,'Queen of Fire','Devika Rangachari','Fantasy',2),
(5,'Monsoon','Sahitya Akademi','Fiction',4),
(7,'Home in the World','Amartya Sen','Biography',6)


select * from Books