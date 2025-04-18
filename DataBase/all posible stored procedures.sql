-- create all posible stored procedures
USE LibraryManagementSystem;

-- 1. Add a New Book
CREATE PROCEDURE AddNewBook
    @Title NVARCHAR(100),
    @ISBN NVARCHAR(20),
    @CategoryID INT,
    @PublisherID INT,
    @PublicationYear INT,
    @CopiesAvailable INT
AS
BEGIN
    INSERT INTO Books (Title, ISBN, CategoryID, PublisherID, PublicationYear, CopiesAvailable)
    VALUES (@Title, @ISBN, @CategoryID, @PublisherID, @PublicationYear, @CopiesAvailable);
END;

-- 2. Add a New Author
CREATE PROCEDURE AddNewAuthor
    @AuthorName NVARCHAR(200)
AS
BEGIN
    INSERT INTO Authors (AuthorName) VALUES (@AuthorName);
END;

-- 3. Add a New Member
CREATE PROCEDURE AddNewMember
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @MiddleName NVARCHAR(100),
    @Email VARCHAR(100),
    @Phone VARCHAR(20),
    @Address NVARCHAR(200),
    @DateOfBirth DATETIME,
    @Gender TINYINT,
    @RegisteredBy INT
AS
BEGIN
    DECLARE @PersonID INT;

    INSERT INTO People (FirstName, LastName, MiddleName, Email, Phone, Address, DateOfBirth, Gender, CreationDate, ModificationDate)
    VALUES (@FirstName, @LastName, @MiddleName, @Email, @Phone, @Address, @DateOfBirth, @Gender, GETDATE(), GETDATE());

    SET @PersonID = SCOPE_IDENTITY();

    INSERT INTO Members (PersonID, RegisteredBy) VALUES (@PersonID, @RegisteredBy);
END;

-- 4. Loan a Book
CREATE PROCEDURE LoanBook
    @BookID INT,
    @MemberID INT,
    @LibrarianID INT,
    @DueDate DATETIME
AS
BEGIN
    INSERT INTO Loans (BookID, MemberID, LibrarianID, LoanDate, DueDate)
    VALUES (@BookID, @MemberID, @LibrarianID, GETDATE(), @DueDate);

    UPDATE Books SET CopiesAvailable = CopiesAvailable - 1 WHERE BookID = @BookID;
END;

-- 5. Return a Book
CREATE PROCEDURE ReturnBook
    @LoanID INT
AS
BEGIN
    UPDATE Loans SET ReturnDate = GETDATE() WHERE LoanID = @LoanID;

    DECLARE @BookID INT;
    SELECT @BookID = BookID FROM Loans WHERE LoanID = @LoanID;

    UPDATE Books SET CopiesAvailable = CopiesAvailable + 1 WHERE BookID = @BookID;
END;

-- 6. Add a Fine
CREATE PROCEDURE AddFine
    @MemberID INT,
    @LoanID INT,
    @LibrarianID INT,
    @FineFees SMALLMONEY
AS
BEGIN
    INSERT INTO Fines (MemberID, LoanID, LibrarianID, FineFees)
    VALUES (@MemberID, @LoanID, @LibrarianID, @FineFees);
END;

-- 7. Pay Fine
CREATE PROCEDURE PayFine
    @FineID INT
AS
BEGIN
    UPDATE Fines SET Status = 2 WHERE FineID = @FineID; -- 2 means paid
END;

-- 8. Reserve a Book
CREATE PROCEDURE ReserveBook
    @BookID INT,
    @MemberID INT,
    @LibrarianID INT
AS
BEGIN
    INSERT INTO Reservations (BookID, MemberID, LibrarianID, ReservationDate)
    VALUES (@BookID, @MemberID, @LibrarianID, GETDATE());
END;

-- 9. Complete Reservation
CREATE PROCEDURE CompleteReservation
    @ReservationID INT
AS
BEGIN
    UPDATE Reservations SET Status = 2 WHERE ReservationID = @ReservationID; -- 2 means completed
END;

-- 10. Cancel Reservation
CREATE PROCEDURE CancelReservation
    @ReservationID INT
AS
BEGIN
    UPDATE Reservations SET Status = 3 WHERE ReservationID = @ReservationID; -- 3 means canceled
END;

-- 11. Get Books by Category
CREATE PROCEDURE GetBooksByCategory
    @CategoryID INT
AS
BEGIN
    SELECT * FROM Books WHERE CategoryID = @CategoryID;
END;

-- 12. Get Books by Author
CREATE PROCEDURE GetBooksByAuthor
    @AuthorName NVARCHAR(200)
AS
BEGIN
    SELECT b.* FROM Books b JOIN BookAuthors ba ON b.BookID = ba.BookID JOIN Authors a ON ba.AuthorID = a.AuthorID WHERE a.AuthorName = @AuthorName;
END;

-- 13. Get Loans by Member
CREATE PROCEDURE GetLoansByMember
    @MemberID INT
AS
BEGIN
    SELECT * FROM Loans WHERE MemberID = @MemberID;
END;

-- 14. Get Overdue Loans
CREATE PROCEDURE GetOverdueLoans
AS
BEGIN
    SELECT * FROM Loans WHERE DueDate < GETDATE() AND ReturnDate IS NULL;
END;

-- 15. Update Book Copies Available
CREATE PROCEDURE UpdateBookCopiesAvailable
    @BookID INT,
    @CopiesAvailable INT
AS
BEGIN
    UPDATE Books SET CopiesAvailable = @CopiesAvailable WHERE BookID = @BookID;
END;

-- 16. Update Member Information
CREATE PROCEDURE UpdateMemberInfo
    @PersonID INT,
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @Email VARCHAR(100),
    @Phone VARCHAR(20),
    @Address NVARCHAR(200)
AS
BEGIN
    UPDATE People SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Address = @Address , ModificationDate = GETDATE() WHERE PersonID = @PersonID;
END;

-- 17. Add Librarian
CREATE PROCEDURE AddLibrarian
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @UserName NVARCHAR(100),
    @Password NVARCHAR(100)
AS
BEGIN
    DECLARE @PersonID INT;

    INSERT INTO People (FirstName, LastName, CreationDate, ModificationDate)
    VALUES (@FirstName, @LastName, GETDATE(), GETDATE());

    SET @PersonID = SCOPE_IDENTITY();

    INSERT INTO Librarians (PersonID, UserName, PassWord) VALUES (@PersonID, @UserName, @Password);
END;

--18. Get fines by member
CREATE PROCEDURE GetFinesByMember
    @MemberID int
AS
BEGIN
    Select * from Fines where MemberID = @MemberID;
END;

--19. Get Reservations by member
CREATE PROCEDURE GetReservationsByMember
    @MemberID int
AS
BEGIN
    Select * from Reservations where MemberID = @MemberID;
END;