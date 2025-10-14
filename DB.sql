CREATE DATABASE TEST_CRUD
GO
USE TEST_CRUD
GO

CREATE TABLE USERS(
	id INT IDENTITY(100,1),
	firstname VARCHAR(50),
	lastname VARCHAR(50),
	document VARCHAR(10) UNIQUE,
	telephone VARCHAR(15),
	email VARCHAR(100),
	u_address VARCHAR (100),
	city VARCHAR(100),
	province VARCHAR(100),
	zip INT,
	u_status BIT DEFAULT 1,

	PRIMARY KEY(id)
)
GO

INSERT USERS (firstname,lastname,document,telephone,email,u_address,city,province,zip)
VALUEs ('Brian','Barrera','42832425','1167624662','brian@gmail.com','Martin Rodriguez 2061','Villa adelina','Buenos Aires','1607'),
	   ('Marcos','Gomez','94256338','1559381788','marcos@gmail.com','Martin Rodriguez 2061','Villa adelina','Buenos Aires','1607'),
	   ('Ariel','Barrera','24724787','1138833931','ariel@gmail.com','Entre Rios 4089','Munro','Buenos Aires','1605')


SELECT * FROM USERS


