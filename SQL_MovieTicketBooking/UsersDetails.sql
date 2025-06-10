Use [MovieBookingDB];
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(100),
    Email NVARCHAR(100),
    Password NVARCHAR(100),
    CreatedAt DATETIME DEFAULT GETDATE()
);
Create procedure GetAllUsers
As
Begin
Select * from Users;
End;
CREATE PROCEDURE InsertUser
    @Username NVARCHAR(100),
    @Email NVARCHAR(100),
    @Password NVARCHAR(100),
	@CreatedAt DATETIME
AS
BEGIN
    INSERT INTO Users (Username, Email, Password, CreatedAt)
    VALUES (@Username, @Email, @Password, @CreatedAt);
END;
EXEC InsertUser
@Username = 'Sana Shaikh',
@Email = 'sana@gmail.com',
@Password = 'sana123',
@CreatedAt = '2025-06-10 11:30:00';
Create procedure CheckUser
@Username NVARCHAR(100),
@Password NVARCHAR(100)
As
Begin
Select * from Users 
Where Username = @Username And
Password = @Password
End;
Exec CheckUser 
@Username = 'Neha Pandey',
@Password = 'neha123';

Create procedure GetDetailsWithEmailId
@Email NVARCHAR(100)
As
Begin
Select * From Users
Where Email = @Email
End;
Execute GetDetailsWithEmailId @Email = 'neha@gmail.com';