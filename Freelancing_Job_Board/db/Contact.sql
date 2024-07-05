Create Database Freelancing_Job_Board
use Freelancing_Job_Board
-- Contact
Create table Contact(

ContactId int primary key identity(1,1) not null,
Name varchar (50),

Email varchar (50),

Subject varchar(160),

Message varchar (Max)
)
