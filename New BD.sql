CREATE database ClubOfKnowlage
use ClubOfKnowlage
drop database ClubOfKnowlage
drop database BotKZ
Create table [Student]
(
[id_student] Integer NOT NULL,
[id_parents] Integer NOT NULL,
[Fio] Nvarchar(100) NOT NULL,
[Birthday] Datetime NOT NULL,
[Phone] Nvarchar(1000) NULL,
[Mail] Nvarchar(1000) NULL,
[Code] Nvarchar(1000) NULL,
[id_gender] Integer NULL,
[id_treaty] Nvarchar(1000) NULL,
[Traty_date] Datetime NULL,
[id_Photo] Integer NULL,
Primary Key ([id_student])
)
go


Create table [Group]
(
[id_Group] Integer Identity NOT NULL, UNIQUE ([id_Group]),
[id_direction] Integer NOT NULL,
[Num_group] Nvarchar(200) NOT NULL,
Primary Key ([id_Group])
)
go

Create table [Lesson]
(
[id_employee] Integer NOT NULL,
[Lesson_date] Date NOT NULL,
[Lesson_time] time NOT NULL,
[Id_homework] Integer NULL,
[id_lesson] Integer Identity NOT NULL,
Primary Key ([Lesson_date],[Lesson_time],[id_lesson])
)
go

Create table [Employee]
(
[id_employee] Integer Identity NOT NULL, UNIQUE ([id_employee]),
[Fio] Nvarchar(1000) NOT NULL,
[id_accaunt] Integer NOT NULL,
[id_Photo] Integer NULL,
Primary Key ([id_employee])
)
go

Create table [Role]
(
[id_Role] Integer Identity NOT NULL, UNIQUE ([id_Role]),
[Role_name] Nvarchar(100) NOT NULL,
Primary Key ([id_Role])
)
go

Create table [Bot]
(
[Id_bot] Integer Identity NOT NULL,
[Connecting] Nvarchar(4000) NOT NULL,
[Type] Nvarchar(4000) NOT NULL,
[CallBack_id] Nvarchar(4000) NOT NULL,
Primary Key ([Id_bot])
)
go

Create table [Homework]
(
[id_employee] Integer NOT NULL,
[Homework_text] Nvarchar(1000) NOT NULL,
[Id_homework] Integer Identity NOT NULL, UNIQUE ([Id_homework]),
Primary Key ([Id_homework])
)
go






Create table [Accaunt]
(
[id_accaunt] Integer Identity NOT NULL, UNIQUE ([id_accaunt]),
[Login] Nvarchar(1000) NOT NULL, UNIQUE ([Login]),
[Password] Nvarchar(100) NOT NULL,
[id_Role] Integer NOT NULL,
Primary Key ([id_accaunt])
)
go

Create table [Saved_acc]
(
[id_saved_acc] Integer Identity NOT NULL,
[id_pc] Nvarchar(1000) NOT NULL,
[id_accaunt] Integer NOT NULL,
Primary Key ([id_saved_acc])
)
go

Create table [Parents]
(
[id_parents] Integer NOT NULL,
[id_gender] Integer NOT NULL,
[Fio_parents] Nvarchar(1000) NOT NULL,
[Parents_phone] Nvarchar(1000) NULL,
[Birthday_parants] Datetime NULL,
[Mail] Nvarchar(1000) NULL,
Primary Key ([id_parents])
)
go


Create table [Gender]
(
[id_gender] Integer Identity NOT NULL,
[Gender_name] Nvarchar(100) NOT NULL,
Primary Key ([id_gender])
)
go

Create table [Treaty]
(
[id_treaty] Nvarchar(1000) NOT NULL,
[Traty_date] Datetime NOT NULL,
[Traty_date_of_end] Datetime NOT NULL,
Primary Key ([id_treaty],[Traty_date])
)
go

Create table [Visit]
(
[Lesson_date] Date NOT NULL,
[Lesson_time] time NOT NULL,
[id_lesson] Integer NOT NULL,
[id_student] Integer NOT NULL,
[Visit_stud] Nvarchar(1000) NULL,
[Mark] Nvarchar(1000) NULL
)
go

Create table [Student_group]
(
[id_student] Integer NOT NULL,
[id_Group] Integer NOT NULL,
Primary Key ([id_student],[id_Group])
)
go

Create table [Ras]
(
[id_ras] Integer Identity NOT NULL,
[Id_bot] Integer NOT NULL,
[Date_include] Datetime NOT NULL,
[Ras_text] Nvarchar(4000) NOT NULL,
Primary Key ([id_ras])
)
go

Create table [Avt]
(
[id_avt] Integer Identity NOT NULL,
[Id_bot] Integer NOT NULL,
[Date_include] Datetime NOT NULL,
[Avt_text] Nvarchar(4000) NOT NULL,
[Type] Nvarchar(100) NOT NULL,
[Stat] Nvarchar(4000) NOT NULL,
Primary Key ([id_avt])
)
go

Create table [Direction]
(
[id_direction] Integer NOT NULL,
[Name_group] Nvarchar(1000) NOT NULL,
[Lessons_long] Integer NULL,
[Lessons_count] Integer NULL,
Primary Key ([id_direction])
)
go




Create table [Photo]
(
[id_Photo] Integer Identity NOT NULL,
[Image] Varbinary(max) NOT NULL,
Primary Key ([id_Photo])
)
go



Alter table
[Student_group] add foreign key([id_student]) references [Student] ([id_student]) on update no action on delete no action
go
Alter table [Student_group] add foreign key([id_Group]) references [Group] ([id_Group]) on update no action on delete no action
go
Alter table [Visit] add foreign key([Lesson_date],[Lesson_time],[id_lesson]) references [Lesson] ([Lesson_date],[Lesson_time],[id_lesson]) on update no action on delete no action
go
Alter table [Lesson] add foreign key([id_employee]) references [Employee] ([id_employee]) on update no action on delete no action
go
Alter table [Homework] add foreign key([id_employee]) references [Employee] ([id_employee]) on update no action on delete no action
go
Alter table [Accaunt] add foreign key([id_Role]) references [Role] ([id_Role]) on update no action on delete no action
go
Alter table [Avt] add foreign key([Id_bot]) references [Bot] ([Id_bot]) on update no action on delete no action
go
Alter table [Ras] add foreign key([Id_bot]) references [Bot] ([Id_bot]) on update no action on delete no action
go
Alter table [Lesson] add foreign key([Id_homework]) references [Homework] ([Id_homework]) on update no action on delete no action
go
Alter table [Employee] add foreign key([id_accaunt]) references [Accaunt] ([id_accaunt]) on update no action on delete no action
go
Alter table [Saved_acc] add foreign key([id_accaunt]) references [Accaunt] ([id_accaunt]) on update no action on delete no action
go
Alter table [Student] add foreign key([id_parents]) references [Parents] ([id_parents]) on update no action on delete no action
go
Alter table [Student] add foreign key([id_gender]) references [Gender] ([id_gender]) on update no action on delete no action
go
Alter table [Parents] add foreign key([id_gender]) references [Gender] ([id_gender]) on update no action on delete no action
go
Alter table [Student] add foreign key([id_treaty],[Traty_date]) references [Treaty] ([id_treaty],[Traty_date]) on update no action on delete no action
go
Alter table [Group] add foreign key([id_direction]) references [Direction] ([id_direction]) on update no action on delete no action
go
Alter table [Employee] add foreign key([id_Photo]) references [Photo] ([id_Photo]) on update no action on delete no action
go
Alter table [Student] add foreign key([id_Photo]) references [Photo] ([id_Photo]) on update no action on delete no action
go


Set quoted_identifier on
go


Set quoted_identifier off
go
select * from visit
select * from lesson
Select * from employee
select * from student
select * from accaunt
delete from lesson
select * from [role]
select employee.id_employee,lesson.Lesson_date,lesson.Lesson_time,Lesson.Id_homework,Visit.id_student, Num_group,Name_group,employee.Fio from lesson join visit on lesson.id_lesson = visit.id_lesson join student on visit.id_student=Student.id_student join Student_group on Student_group.id_student=Student.id_student join [group] on [group].id_Group = Student_group.id_Group join Direction on [group].id_direction = Direction.id_direction join employee on employee.id_employee = lesson.id_employee 



go
CREATE VIEW studwithout AS
SELECT Student.id_student,Fio,Birthday,Phone FROM student WHERE NOT EXISTS (SELECT * FROM Student_group WHERE student.id_student = Student_group.id_student)
go
CREATE VIEW students AS
SELECT Fio,[Group].id_Group,Birthday,Phone,Parents_phone,Student.id_student FROM Student join Parents on Student.id_parents=Parents.id_parents join Student_group on Student.id_student = Student_group.id_student join [Group] on [Group].id_Group=Student_group.id_Group
go
insert into [Role] ([Role_name])
values('Admin'),('MSP'),('Teacher')

insert into [Accaunt] ([Login],[Password] ,[id_Role])
values('Admin','1',1),('AseevD','159632',3),('BelovaE','1111',2),('ZgukovA','1ewrwer',3)
select * from [Accaunt]
insert into [Employee] ([Fio],[id_accaunt])
values('Асеев Денис Валерьевич',1),('Белолва Екастерина',2),('Жуков Алексей Михайлович',3),('Администратор',4)
insert into [Gender] ([Gender_name])
values('Муж.'),('Жен.')
insert into [Lesson] ([id_employee],[Lesson_date],[Lesson_time],[Id_homework])
values(1,'12.07.2023','11:00:00',1)
insert into [Group](id_direction,Num_group) values(1,'1292')
insert into [Visit] ([Lesson_date],[Lesson_time],[id_lesson],[id_student],[Visit_stud],[Mark])
values('12.07.2023','11:00:00',1,1,'Да','12')







go
 CREATE MASTER KEY ENCRYPTION BY
    PASSWORD= 'Cript_R
go

go
	 CREATE CERTIFICATE Cripti
   WITH SUBJECT = 'Certificate for Encrypt Data';
go

go
 CREATE SYMMETRIC KEY KZ_Key_01
    WITH ALGORITHM = AES_256
    ENCRYPTION BY CERTIFICATE cert123;
GO


Select fio,Num_group, Birthday,Phone,Parents_phone,id_student    from students join [group] on students.id_group = [group].id_group

select Homework_text from Student join Visit on visit.id_student = Student.id_student join Lesson on lesson.id_lesson = Visit.id_lesson join homework on Homework.Id_homework = Lesson.id_lesson where Code = ''


select * from student

insert into [Group](id_direction,Num_group) values(1,'1292')

select * from direction
select*from [group] join direction on [group].id_direction = Direction.id_direction

insert into Student_group(id_student,id_Group) values(1,1)


select Lesson.Lesson_date,Lesson.Lesson_time,Num_group from lesson join visit on Lesson.id_lesson = visit.id_lesson join student on student.id_student = visit.id_student
join Student_group on student.id_student = Student_group.id_student join [Group] on [group].id_Group = Student_group.id_Group   where Lesson.Lesson_date>='13.06.2023'

update lesson set Id_homework = 1 where Lesson_date = and Lesson_time =  

insert into [Homework] ([id_employee],[Homework_text]) values(1,'Сделать дз')
select * from homework
select * from Student join Visit on visit.id_student = Student.id_student join Lesson on lesson.id_lesson = Visit.id_lesson join homework on Homework.Id_homework = Lesson.id_lesson where Code = '111'





select * from homework where id_employee =1 
go
CREATE PROCEDURE OpenKeys
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        OPEN SYMMETRIC KEY KZ_Key_01
        DECRYPTION BY CERTIFICATE cert123
    END TRY
    BEGIN CATCH
        -- Handle non-existant key here
    END CATCH
END
go

go
CREATE PROCEDURE CloseKeys
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        CLOSE SYMMETRIC KEY KZ_Key_01
    END TRY
    BEGIN CATCH
        -- Handle non-existant key here
    END CATCH
END
go
go
create function Login_UserByLP(
@Login Nvarchar(20),
@Password Nvarchar(20)
)
returns int
as
begin
declare @temp Nvarchar(20),
@tempint int
select @temp = isnull(ID_User, 0) from [User] where [Login] = @Login and convert(nvarchar(50),DecryptByKey([Password])) = @Password;
return isnull(@temp, 0)
end
go

--Получение ID должности--
go
create function GetPost(
@ID_User int
)
returns int
as
begin
declare @temp Nvarchar(20),
@tempint int
select @temp = isnull(ID_Post, 0) from [User] where [ID_User] = @ID_User;
return isnull(@temp, 0)
end
go


CREATE PROCEDURE Add_User
	@id_Post INT = NULL,
    @login NVARCHAR(50) = NULL,
    @password NVARCHAR(50) = NULL,
    @last_name NVARCHAR(100) = NULL,
    @first_name NVARCHAR(100) = NULL,
    @email NVARCHAR(100) = NULL
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION

        OPEN SYMMETRIC KEY KZ_Key_01
        DECRYPTION BY CERTIFICATE cert123;

        INSERT INTO [User] ([Login], [Password], User_Photo, ID_Post, [Last_Name], [First_Name], [Email])
        VALUES (@login, EncryptByKey(Key_GUID('KZ_Key_01'), @password), NULL, @id_Post, @last_name, @first_name, @email)

        CLOSE SYMMETRIC KEY KZ_Key_01

        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION
        PRINT 'This is the error: ' + ERROR_MESSAGE()
        RETURN
    END CATCH
END
GO





insert into [Bot] ([Connecting],[Type],[CallBack_id])
values('Test','Test','Test')

select * from [group]
insert into Student_group(id_student,id_Group)
values(2,1)




go

go
Select * from students
go
drop view students


select COUNT(*) from Visit where id_student = 1




go
drop view studwithout

drop database ClubOfKnowlage
go







SELECT Student.id_student, Fio,Student.Birthday,Student.Phone,Student.Mail,Student.[id_gender],Code,Parents.Fio_parents,Parents.Parents_phone,Parents.id_gender,Parents.Mail FROM Student join Parents on Student.id_parents=Parents.id_parents  where Student.id_student = 1
go




SELECT [Group].id_Group,[Group].Group_name,[Group].Lesson_long,[Group].Lesson_count_per_mounth,Treaty.id_treaty FROM Student join Student_group on Student.id_student = Student_group.id_student join [Group] on [Group].id_Group=Student_group.id_Group join Treaty on Treaty.id_treaty = Student_group.id_treaty where Student.id_student = 1




select [Visit_stud],[Mark] from Visit where id_student = 1


go
create view vis as
select * from Visit where id_student = 1 
go


select Homework.Homework_text from Lesson join Homework on Homework.Id_homework = Lesson.Id_homework
where id_lesson = 1
select * from [Group]