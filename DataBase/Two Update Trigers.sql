CREATE TRIGGER trg_People_Update
ON People
FOR UPDATE
AS
BEGIN
    -- Declare variables to capture the old and new values of the columns
    DECLARE @OldFirstName nvarchar(100), @OldLastName nvarchar(100), @OldMiddleName nvarchar(100), @OldEmail varchar(100),
            @OldPhone varchar(20), @OldAddress nvarchar(200), @OldDateOfBirth Datetime, @OldGender tinyint, 
            @OldImagePath nvarchar(250), @OldCreationDate DateTime, @OldModificationDate datetime, @OldIsDeleted bit;

    DECLARE @NewFirstName nvarchar(100), @NewLastName nvarchar(100), @NewMiddleName nvarchar(100), @NewEmail varchar(100),
            @NewPhone varchar(20), @NewAddress nvarchar(200), @NewDateOfBirth Datetime, @NewGender tinyint, 
            @NewImagePath nvarchar(250), @NewCreationDate DateTime, @NewModificationDate datetime, @NewIsDeleted bit;

    -- Get the old values (before update)
    SELECT @OldFirstName = FirstName, @OldLastName = LastName, @OldMiddleName = MiddleName, @OldEmail = Email,
           @OldPhone = Phone, @OldAddress = Address, @OldDateOfBirth = DateOfBirth, @OldGender = Gender,
           @OldImagePath = ImagePath, @OldCreationDate = CreationDate, @OldModificationDate = ModificationDate,
           @OldIsDeleted = IsDeleted
    FROM deleted;

    -- Get the new values (after update)
    SELECT @NewFirstName = FirstName, @NewLastName = LastName, @NewMiddleName = MiddleName, @NewEmail = Email,
           @NewPhone = Phone, @NewAddress = Address, @NewDateOfBirth = DateOfBirth, @NewGender = Gender,
           @NewImagePath = ImagePath, @NewCreationDate = CreationDate, @NewModificationDate = ModificationDate,
           @NewIsDeleted = IsDeleted
    FROM inserted;

    -- Example: You could add logic here, like logging the update or auditing changes.
    -- For example, if you want to log the changes into an audit table:
    -- INSERT INTO PeopleAudit (PersonID, OldFirstName, NewFirstName, OldLastName, NewLastName, OldEmail, NewEmail, UpdateDate)
    -- SELECT i.PersonID, d.FirstName, i.FirstName, d.LastName, i.LastName, d.Email, i.Email, GETDATE()
    -- FROM inserted i
    -- JOIN deleted d ON i.PersonID = d.PersonID;

    -- You can also update the `ModificationDate` field
    UPDATE People
    SET ModificationDate = GETDATE()
    WHERE PersonID IN (SELECT PersonID FROM inserted);
    
END;



CREATE TRIGGER trg_People_OnUpdate
ON People
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Update ModificationDate only if meaningful fields were changed
    IF EXISTS (
        SELECT 1
        FROM inserted i
        JOIN deleted d ON i.PersonID = d.PersonID
        WHERE 
            ISNULL(i.FirstName, '') <> ISNULL(d.FirstName, '') OR
            ISNULL(i.LastName, '') <> ISNULL(d.LastName, '') OR
            ISNULL(i.MiddleName, '') <> ISNULL(d.MiddleName, '') OR
            ISNULL(i.Email, '') <> ISNULL(d.Email, '') OR
            ISNULL(i.Phone, '') <> ISNULL(d.Phone, '') OR
            ISNULL(i.Address, '') <> ISNULL(d.Address, '') OR
            ISNULL(i.DateOfBirth, '') <> ISNULL(d.DateOfBirth, '') OR
            ISNULL(i.Gender, '') <> ISNULL(d.Gender, '') OR
            ISNULL(i.ImagePath, '') <> ISNULL(d.ImagePath, '')
    )
    BEGIN
        UPDATE P
        SET P.ModificationDate = GETDATE()
        FROM People P
        INNER JOIN inserted i ON P.PersonID = i.PersonID;
    END
END;
