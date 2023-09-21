CREATE DATABASE dbDatabase
USE dbDatabase

drop table tblUser

CREATE TABLE tblUser
(
	[User_ID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	[Email] VARCHAR(30) UNIQUE NOT NULL,
	[Age] INT NOT NULL
)
 -- Inserting
CREATE PROC InsertUser
(
	@name VARCHAR(30),
	@email VARCHAR(30),
	@age INT
)
AS
BEGIN
	INSERT INTO tblUser([Name],[Email],[Age])
	VALUES(@name,@email,@age)
END;

-- Deleting
CREATE PROC DeleteUser
(
	@user_id INT
)
AS
BEGIN
	DELETE FROM tblUser WHERE [User_ID] = @user_id
END;

-- Fetching one user
CREATE PROC GetOneUser
(
	@user_id INT
)
AS
BEGIN
	SELECT * FROM tblUser WHERE [User_ID] = @user_id
END;

-- Fetching All user
CREATE PROC GetAllUser
AS
BEGIN
	SELECT * FROM tblUser
END;

-- Updating user
CREATE PROC UpdateUser
(
	@user_id INT,
	@name VARCHAR(30),
	@email VARCHAR(30),
	@age INT
)
AS
BEGIN
	UPDATE tblUser 
	SET 
	[Name] = @name, 
	[Email] = @email,
	[Age] = @age
	WHERE [User_ID] = @user_id
END;

