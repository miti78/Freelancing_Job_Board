Create Table [User](
UserId int primary key identity(1,1),
Username varchar(50),
Password varchar(50),
Name varchar (50),
Email varchar(50),
Mobile varchar(50),
SSC_Result varchar(50),
HSC_Result varchar (50),
GraduationGrade varchar(50),
WorksOn varchar (50),
Experience varchar(50),
Resume varchar (50),
Address varchar(max),
Country varchar(50)
)

Alter table [User]
add unique (Username)
select *from [User];

ALTER TABLE [User]
ALTER COLUMN Resume VARCHAR(MAX);
