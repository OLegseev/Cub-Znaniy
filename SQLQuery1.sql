create database BotKZ
use BotKZ
drop database BotKZ
create table Autorize
(
id int identity primary key,
login_a nvarchar(100),
password_a nvarchar(100),
fio nvarchar(200),
stat nvarchar(200),
)

insert into Autorize(login_a,password_a,fio,stat)
values('Ludmila','1','Людмила','Admin'),
('Admin','1','Асеев Денис Валерьевич','Admin'),
('Gukov','Furry','Жуков Алексей Витальевич','Prepod')
select * from Autorize
create table saved
(
id int identity primary key,
login_a nvarchar(100),
)
insert into saved(id_user)
values(1)



create table groupp
(
id int identity primary key,
connecting nvarchar(200),
tipe nvarchar(100),
Callback_id nvarchar(100),
name_group nvarchar(100)
)
create table texts_ras
(
id int identity primary key,
date_inc datetime,
text_ras nvarchar(1000)
)

create table texts_avt
(
id int identity primary key,
date_inc datetime,
text_avt nvarchar(1000),
tipe nvarchar(100),
groupName nvarchar(1000),
stat nvarchar(1000),
socset nvarchar(1000)
)

create table users_track
(
id int identity primary key,
date_user datetime,
text_user nvarchar(1000),
code_user nvarchar(1000),
text_adm nvarchar(1000)
)
create table ban_list
(
id int identity primary key,
code_user nvarchar(1000)
)



drop table ban_list
Select * from texts_avt where code_user = '123'
Select * from ban_list



create table lesson
(
id_les int identity primary key,
homework nvarchar(1000),
les_group int foreign key references groupp_les(num_group),
date_para date,
time_para time,
les_prep int foreign key references Autorize(id)
)
update lesson set homework = 'df' where id_les =2 
DELETE FROM lesson WHERE id_les = 1
insert into lesson(les_group,date_para,time_para,les_prep) values(1292,'12.03.2023','12:12:12',1)
select * from lesson


create table student
(
id_stud int identity primary key,
group_id int foreign key references groupp_les(num_group),
fio nvarchar(1000),
fio_par nvarchar(1000),
num_par nvarchar(20)
)


insert into student(group_id,fio,fio_par,num_par) values(1,'','','')
Select * from student

create table groupp_les
(
num_group int primary key,
group_theme nvarchar(1000),
)
insert into groupp_les(num_group,group_theme)
values(1,'')

select * from groupp_les

drop table lesson
