USE master
GO

--drop database if it exists
IF DB_ID('final_capstone') IS NOT NULL
BEGIN
	ALTER DATABASE final_capstone SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE final_capstone;
END

CREATE DATABASE final_capstone
GO

USE final_capstone
GO

--create tables
CREATE TABLE users (
	user_id int IDENTITY(1,1) NOT NULL,
	username varchar(50) NOT NULL,
	password_hash varchar(200) NOT NULL,
	salt varchar(200) NOT NULL,
	user_role varchar(50) NOT NULL,
	email varchar(50),
	CONSTRAINT PK_user PRIMARY KEY (user_id),
)

CREATE TABLE location (
	course_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	course_name varchar(250) NOT NULL, 
	holes int DEFAULT 18,
	address varchar(250) NOT NULL,
	city varchar (25),
	state varchar(2),
	zip int
)

CREATE TABLE league (
	league_id int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	league_name varchar(50) NOT NULL,
	league_admin varchar(20) NOT NULL,
	course_id int FOREIGN KEY REFERENCES location(course_id) NOT NULL,
	league_start date NOT NULL,
	league_end date NOT NULL,
	score_league bit,
	decription varchar(250)
)

CREATE TABLE leaderboard(
	week int NOT NULL,
	total_score int DEFAULT 0,
	league_id int FOREIGN KEY REFERENCES league(league_id),
	user_id int FOREIGN KEY REFERENCES users(user_id)
)
CREATE TABLE league_users(
	league_id int FOREIGN KEY REFERENCES league(league_id),
	user_id int FOREIGN KEY REFERENCES users(user_id)
	)


--populate default data
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('user','Jg45HuwT7PZkfuKTz6IB90CtWY4=','LHxP4Xh7bN0=','user');
INSERT INTO users (username, password_hash, salt, user_role) VALUES ('admin','YhyGVQ+Ch69n4JMBncM4lNF/i9s=', 'Ar/aB2thQTI=','admin');

GO