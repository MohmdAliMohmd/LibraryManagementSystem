USE LibraryManagementSystem;

-- Book Categories

-- Book categories with all posible values

INSERT INTO BookCategories (CategoryName, ParentCategory) VALUES
('Fiction', NULL), -- 1
('Science Fiction', 1), -- 2
('Fantasy', 1), -- 3
('Mystery', 1), -- 4
('Thriller', 1), -- 5
('Romance', 1), -- 6
('Historical Fiction', 1), -- 7
('Non-Fiction', NULL), -- 8
('Biography', 8), -- 9
('Autobiography', 9), -- 10
('History', 8), -- 11
('Science', 8), -- 12
('Technology', 8), -- 13
('Programming', 13), -- 14
('Self-Help', 8), -- 15
('Travel', 8), -- 16
('Childrens', NULL), -- 17
('Picture Books', 17), -- 18
('Middle Grade', 17), -- 19
('Young Adult (YA)', 17), -- 20
('Poetry', NULL), -- 21
('Drama', NULL), -- 22
('Comics/Graphic Novels', NULL), -- 23
('Cookbooks', NULL), -- 24
('Art', NULL), -- 25
('Religion', NULL), -- 26
('Philosophy', NULL), -- 27
('Business', NULL), -- 28
('Economics', 28), -- 29
('Personal Finance', 28), -- 30
('Health & Fitness', NULL), -- 31
('Home & Garden', NULL), -- 32
('Crafts & Hobbies', NULL), -- 33
('Sports', NULL), -- 34
('Education', NULL), -- 35
('Reference', NULL), -- 36
('Dictionaries', 36), -- 37
('Encyclopedias', 36), -- 38
('Law', NULL), -- 39
('Politics', NULL), -- 40
('Psychology', NULL), -- 41
('Sociology', NULL), -- 42
('True Crime', 1), -- 43
('Adventure', 1), -- 44
('Horror', 1); --45



-- Authors
INSERT INTO Authors (AuthorName) VALUES
('Isaac Asimov'),
('J.R.R. Tolkien'),
('Agatha Christie'),
('Stephen Hawking'),
('Walter Isaacson'),
('Jane Austen'),
('Brandon Sanderson'),
('Neil Gaiman'),
('Robert C. Martin'),
('Roald Dahl');

-- Publishing Houses
INSERT INTO PublishingHouses (PublisherName, Address, Phone, Email, WebSite) VALUES
('Penguin Books', '123 Main St, New York', '123-456-7890', 'info@penguin.com', 'www.penguin.com'),
('HarperCollins', '456 Oak Ave, London', '987-654-3210', 'contact@harpercollins.com', 'www.harpercollins.com'),
('Simon & Schuster', '789 Pine Ln, Sydney', '111-222-3333', 'hello@simonandschuster.com', 'www.simonandschuster.com'),
('Tor Books', '101 Elm Rd, Toronto', '444-555-6666', 'support@torbooks.com', 'www.tor-books.com');

-- Books
INSERT INTO Books (Title, ISBN, CategoryID, PublisherID, PublicationYear, CopiesAvailable) VALUES
('Foundation', '978-0553293357', 2, 1, 1951, 5),
('The Hobbit', '978-0618260300', 3, 2, 1937, 3),
('Murder on the Orient Express', '978-0062073484', 4, 3, 1934, 2),
('A Brief History of Time', '978-0553380163', 7, 1, 1988, 4),
('Steve Jobs', '978-1451648539', 6, 3, 2011, 1),
('Pride and Prejudice', '978-0141439518',1,1,1813,6),
('The Way of Kings', '978-0765326355', 3, 4, 2010, 3),
('American Gods', '978-0380973655', 3, 2, 2001, 2),
('Clean Code', '978-0132350884', 9, 1, 2008, 5),
('Matilda', '978-0141301075', 10, 1, 1988, 7);

-- People
INSERT INTO People (FirstName, LastName, MiddleName, Email, Phone, Address, DateOfBirth, Gender, CreationDate, ModificationDate) VALUES
('John', 'Doe', 'A', 'john.doe@example.com', '123-456-7891', '1 Main St', '1990-01-01', 1, GETDATE(), GETDATE()),
('Jane', 'Smith', 'B', 'jane.smith@example.com', '987-654-3211', '2 Oak Ave', '1985-05-15', 0, GETDATE(), GETDATE()),
('Alice', 'Johnson', 'C', 'alice.johnson@example.com', '111-222-3334', '3 Pine Ln', '2000-12-10', 0, GETDATE(), GETDATE()),
('Bob', 'Williams', 'D', 'bob.williams@example.com', '444-555-6667', '4 Elm Rd', '1978-08-22', 1, GETDATE(), GETDATE()),
('Sarah', 'Brown', null, 'sarah.brown@example.com', '222-333-4444', '5 Maple Dr', '1995-03-08', 0, GETDATE(), GETDATE()),
('Michael', 'Davis', null, 'michael.davis@example.com', '555-666-7777', '6 Cedar Ct', '1982-11-25', 1, GETDATE(), GETDATE()),
('Emily', 'Wilson', null, 'emily.wilson@example.com', '666-777-8888', '7 Birch St', '2003-07-03', 0, GETDATE(), GETDATE()),
('David', 'Garcia', null, 'david.garcia@example.com', '777-888-9999', '8 Willow Ln', '1970-04-18', 1, GETDATE(), GETDATE()),
('Olivia', 'Rodriguez', null, 'olivia.rodriguez@example.com', '888-999-0000', '9 Pine Rd', '1998-09-30', 0, GETDATE(), GETDATE()),
('Kevin', 'Martinez', null, 'kevin.martinez@example.com', '999-000-1111', '10 Oak Ct', '1989-06-12', 1, GETDATE(), GETDATE());

-- Librarians
INSERT INTO Librarians (PersonID, UserName, PassWord) VALUES
(1, 'john_librarian', 'password123'),
(2, 'jane_librarian', 'securepass');

-- Members
INSERT INTO Members (PersonID, RegisteredBy) VALUES
(3, 1),
(4, 2),
(5,1),
(6,2),
(7,1),
(8,2),
(9,1),
(10,2);

-- Book Authors
INSERT INTO BookAuthors (BookID, AuthorID) VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 6),
(7, 7),
(8, 8),
(9, 9),
(10, 10);

-- Loans
INSERT INTO Loans (BookID, MemberID, LibrarianID, DueDate) VALUES
(1, 1, 1, DATEADD(day, 14, GETDATE())),
(2, 2, 2, DATEADD(day, 7, GETDATE())),
(3, 3, 1, DATEADD(day, 21, GETDATE()));

-- Reservations
INSERT INTO Reservations (BookID, MemberID, LibrarianID) VALUES
(4, 4, 1),
(5, 5, 2),
(6,6,1);

-- Fines
INSERT INTO Fines (MemberID, LoanID, LibrarianID, FineFees, Status) VALUES
(1, 1, 1, 5.00, 1),
(2, 2, 2, 2.50, 1);

-- Configurations
INSERT INTO Configurations (ConfigKey, ConfigValue) VALUES
('LoanDuration', 14.0),
('FinePerDay', 1.0);