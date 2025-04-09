create database LibraryManagementSystem;
use LibraryManagementSystem;
 

create table BookCategories
(
CategoryID int Identity(1,1) not null Primary Key,
CategoryName nvarchar(200) not null unique,
ParentCategory int ,
foreign key(ParentCategory) references BookCategories(CategoryID)
);

create Table Authors(
AuthorID int identity(1,1) not null Primary key,
AuthorName nvarchar (200) not null unique,
IsDeleted bit default 0
);

create table PublishingHouses
(
PublisherID int identity(1,1) not null Primary Key,
PublisherName nvarchar(200) not null unique,
Address nvarchar (200),
Phone varchar(20),
Email varchar(100),
WebSite varchar(100)
);

create table Books
(
BookID int identity(1,1) not null Primary Key,
Title nvarchar(100) not null,
ISBN nvarchar(20) unique not null,
categoryID int not null,
PublisherID int not null,
PublicationYear int,
CopiesAvailable int Default 1,
Foreign Key (categoryID) references  BookCategories(CategoryID),
Foreign Key (PublisherID) references  PublishingHouses(PublisherID) 
)

create table People(
PersonID int not null identity(1,1) primary key,
FirstName nvarchar(100) not null,
LastName nvarchar(100) not null,
MiddleName nvarchar(100),
Email varchar(100) ,
Phone varchar(20),
Address nvarchar(200),
DateOfBirth Datetime,
Gender tinyint default 1 not null,
ImagePath nvarchar(250),
CreationDate DateTime,
ModificationDate datetime,
IsDeleted bit default 0
);

create table Librarians(
LibrarianID int identity(1,1) not null primary key,
PersonID int not null,
UserName nvarchar(100) not null,
PassWord nvarchar(100) not null,
unique(UserName,PassWord),
startDate DateTime Default getDate(),
EndDate DateTime 
foreign key (PersonID) references People(PersonID)
);

create table Members
(
MemberID int identity(1,1) not null Primary Key,
PersonID int not null,
RegistrationDate DateTime default GetDate(),
RegisteredBy int not null
foreign key (PersonID) references People(PersonID),
Foreign key (RegisteredBy) references Librarians(LibrarianID)
);

create table BookAuthors(
BookAuthorsID int identity(1,1) not null primary key,
BookID int not null,
AuthorID int not null
foreign key (BookID) references Books(BookID),
Foreign Key (AuthorID) references Authors(authorID)

);

create table Loans 
(LoanID int identity(1,1) not null primary key,
BookID int not null,
MemberID int not null,
LibrarianID int not null,
LoanDate DateTime default getdate(),
DueDate dateTime,
ReturnDate DateTime
foreign key (BookID) references Books(BookID),
foreign key(MemberID) references Members(MemberID),
foreign key(LibrarianID) references Librarians(LibrarianID)
);

create table Reservations
(
ReservationID int not null identity(1,1) Primary key,
BookID int not null,
MemberID int not null,
LibrarianID int not null,
ReservationDate DateTime default getdate(),
Status tinyint not null default 1,/** Pending , Completed , Canceled **/
foreign key (BookID) references Books(BookID),
foreign key(MemberID) references Members(MemberID),
foreign key(LibrarianID) references Librarians(LibrarianID)
);

create table Fines(
FineID int identity(1,1) not null Primary Key,
MemberID int not null,
LoanID int not null,
LibrarianID int not null,
FineFees smallmoney NOT NULL,
Status tinyint not null default 1,/** Unpaid , Paid  **/
foreign key (LoanID) references Loans(LoanID),
foreign key(MemberID) references Members(MemberID),
foreign key(LibrarianID) references Librarians(LibrarianID)
);
 
 Create table Configurations
 (
 ConfigID int not null identity(1,1) Primary key,
 ConfigKey nvarchar(100) not null unique,
 ConfigValue float not null,
 LastUpdate DateTime Default getdate()
 );

 /**
 
 exec sp_rename 'Authers.AutherID','Authors.AuthorID'

 EXEC sp_rename 'Authors.Authors.AuthorID',  'AuthorID', 'COLUMN';

 **/






 


CREATE TRIGGER Members_InsteadOfDelete
ON Members
INSTEAD OF DELETE
AS
BEGIN

    DECLARE @PersonID INT;
    DECLARE @MemberID INT;

    SELECT @PersonID = PersonID, @MemberID = MemberID
    FROM DELETED;

    UPDATE People
    SET IsDeleted = 1
    WHERE PersonID = @PersonID;

    
 /**   PRINT 'Member and associated person marked as deleted.';**/
END;






CREATE TRIGGER Librarians_InsteadOfDelete
ON Librarians
INSTEAD OF DELETE
AS
BEGIN
  
    DECLARE @PersonID INT;
    DECLARE @LibrariansID INT;

  
    SELECT @PersonID = PersonID, @LibrariansID = LibrarianID
    FROM DELETED;

  
    UPDATE People
    SET IsDeleted = 1
    WHERE PersonID = @PersonID;

    /**
    PRINT 'Member and associated person marked as deleted.';**/
END;





CREATE VIEW ActiveMembers AS
SELECT
    m.MemberID,
    p.FirstName,
    p.LastName,
    p.Email,
    p.Phone,
    m.RegistrationDate
FROM
    Members m
JOIN
    People p ON m.PersonID = p.PersonID
WHERE
    p.IsDeleted = 0;


	--select * from ActiveMembers
	--select * from Members

	USE LibraryManagementSystem;

CREATE VIEW ActiveLibrarians AS
SELECT
    l.LibrarianID,
    p.FirstName,
    p.LastName,
    p.Email,
    p.Phone,
    l.StartDate,
    l.EndDate
FROM
    Librarians l
JOIN
    People p ON l.PersonID = p.PersonID
WHERE
    p.IsDeleted = 0
    AND (l.EndDate IS NULL OR l.EndDate > GETDATE());


	--view to retutn all deleted people and group them by mmbers or librarians

	USE LibraryManagementSystem;

CREATE VIEW DeletedPeople AS
SELECT
    p.PersonID,
    p.FirstName,
    p.LastName,
    p.Email,
    p.Phone,
    CASE
        WHEN m.MemberID IS NOT NULL THEN 'Member'
        WHEN l.LibrarianID IS NOT NULL THEN 'Librarian'
        ELSE 'Other' -- In case there are deleted people not linked to members or librarians
    END AS PersonType
FROM
    People p
LEFT JOIN
    Members m ON p.PersonID = m.PersonID
LEFT JOIN
    Librarians l ON p.PersonID = l.PersonID
WHERE
    p.IsDeleted = 1;


	--This will return a table showing all deleted people, with an extra column (PersonType) indicating whether they were members, librarians, or other.



	-- view to returned deleted members
	USE LibraryManagementSystem;

CREATE VIEW DeletedMembers AS
SELECT
    m.MemberID,
    p.FirstName,
    p.LastName,
    p.Email,
    p.Phone,
    m.RegistrationDate
FROM
    Members m
JOIN
    People p ON m.PersonID = p.PersonID
WHERE
    p.IsDeleted = 1;
