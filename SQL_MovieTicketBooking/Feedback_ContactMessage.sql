Use [MovieBookingDB];
CREATE TABLE ContactMessages (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Email NVARCHAR(100),
    Phone NVARCHAR(100),
    Subject NVARCHAR(200),
    Message NVARCHAR(MAX),
    CreatedAt DATETIME DEFAULT GETDATE()
);
Exec [dbo].[GetAllDetails]
Alter PROCEDURE InsertContactMessage
    @Name NVARCHAR(100),
    @Email NVARCHAR(100),
    @Phone NVARCHAR(100),
    @Subject NVARCHAR(200),
    @Message NVARCHAR(MAX),
    @CreatedAt DATETIME
AS
BEGIN
    INSERT INTO ContactMessages (Name, Email, Phone, Subject, Message, CreatedAt)
    VALUES (@Name, @Email, @Phone, @Subject, @Message, @CreatedAt);
END;
EXEC InsertContactMessage
    @Name = 'Sana Malik',
    @Email = 'sana@gmail.com',
    @Phone = '9123456789',
    @Subject = 'Movie Experience',
    @Message = 'Had a great time watching the latest thriller!',
    @CreatedAt = '2025-06-10 11:30:00';
	create procedure GetAllCustomerMessage
	As
	Begin
	Select * From ContactMessages;
	End;




