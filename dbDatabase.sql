CREATE DATABASE dbDatabase
USE dbDatabase

drop table tblUser
truncate table tblUser

CREATE TABLE tblUser
(
	[User_ID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	[Email] VARCHAR(30) UNIQUE NOT NULL,
	[Age] INT NOT NULL
)

ALTER TABLE tblUser
ADD Country INT NOT NULL,
State INT NOT NULL

SELECT * FROM tblUser

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

CREATE TABLE tblCountry
(
	CountryID  INT PRIMARY KEY IDENTITY,
	CountryName VARCHAR(30),
)

INSERT INTO tblCountry(CountryName)
VALUES('India'),('United States'),('Pakistan')

SELECT * FROM tblCountry

CREATE TABLE tblState
(
	StateID  INT PRIMARY KEY IDENTITY,
	StateName VARCHAR(30),
	CountryID INT,
	FOREIGN KEY (CountryID) REFERENCES tblCountry(CountryID)
)

SELECT * FROM tblState

INSERT INTO tblState(StateName,CountryID) VALUES('Delhi',1)
INSERT INTO tblState(StateName,CountryID) VALUES('Haryana',1)
INSERT INTO tblState(StateName,CountryID) VALUES('Karnataka',1)

INSERT INTO tblState(StateName,CountryID) VALUES('Texas',2)
INSERT INTO tblState(StateName,CountryID) VALUES('California',2)
INSERT INTO tblState(StateName,CountryID) VALUES('Florida',2)

INSERT INTO tblState(StateName,CountryID) VALUES('Sindh',3)
INSERT INTO tblState(StateName,CountryID) VALUES('Lahore',3)
INSERT INTO tblState(StateName,CountryID) VALUES('Karanchi',3)
