use C3218124C3198416;

drop table tblUser;
drop table tblTitan;
drop table tblBattle;
drop table tblElementType;
drop table tblLookupExp;

CREATE TABLE tblUser
(
    username varchar(255) not null PRIMARY KEY,
	password varchar(255) not null,
	parentsEmail varchar(255) not null,
	exercisePoints int not null,
	tempExercisePoints int not null,
	activateStatus varchar(255) not null,
	activateCode int not null,
	profilePictureLocation varchar(255),
	screenName varchar(255) not null,
	anonymous varchar(255) not null,
	firstName varchar (255),
	OneDayExercisePoints int,
	OneDayStartTime varchar(255),
	uid int,
);

INSERT INTO tblUser values ('admin1@better.com', '12345678', 'parentadmin@better.com', 100000, 0, 
'true', 0, null, 'Admin 1', 'false', null, null, null, null);
INSERT INTO tblUser values ('admin2@better.com', '12345678', 'parentadmin@better.com', 100000, 0, 
'true', 0, null, 'Admin 2', 'false', null, null, null, null);


CREATE TABLE tblTitan
(
    username varchar(255)  not null,
    titanName varchar(255) not null PRIMARY KEY (username,titanName),
	element varchar(255) not null,
	level int not null,
	step int not null,
	experiencePoints int not null,
	battles int not null,
	wins int not null,
	loses int not null,
	dateCreated varchar(255) not null,
	HOF varchar(255) not null default 'false',
	pictureLocation varchar (255),
	FOREIGN KEY (username) references tblUser (username)
)
INSERT INTO tblTitan values ('admin1@better.com', 'Fireballs Knight', 'Fire', 1, 1, 0, 0, 0, 0, '6/3/2016 8:00:00 AM', 'false', '/images/character/fire1.jpg');
INSERT INTO tblTitan values ('admin1@better.com', '8-Tail Beast', 'Water', 1, 1, 0, 0, 0, 0, '6/3/2016 8:00:00 AM', 'false', '/images/character/water1.jpg');
INSERT INTO tblTitan values ('admin1@better.com', 'Moving Mountains', 'Earth', 1, 1, 0, 0, 0, 0, '6/3/2016 8:00:00 AM', 'false', '/images/character/earth1.jpg');
INSERT INTO tblTitan values ('admin1@better.com', 'Thunder Striker', 'Air', 1, 1, 0, 0, 0, 0, '6/3/2016 8:00:00 AM', 'false', '/images/character/air1.jpg');

INSERT INTO tblTitan values ('admin2@better.com', 'Lava Destoryer', 'Fire', 1, 2, 0, 0, 0, 0, '6/3/2016 8:00:00 AM', 'false', '/images/character/fire2.jpg');
INSERT INTO tblTitan values ('admin2@better.com', 'Tsunami Monster', 'Water', 1, 2, 0, 0, 0, 0, '6/3/2016 8:00:00 AM', 'false', '/images/character/water2.jpg');
INSERT INTO tblTitan values ('admin2@better.com', 'God of Trees', 'Earth', 1, 2, 0, 0, 0, 0, '6/3/2016 8:00:00 AM', 'false', '/images/character/earth2.jpg');
INSERT INTO tblTitan values ('admin2@better.com', 'Wind Cutter', 'Air', 1, 2, 0, 0, 0, 0, '6/3/2016 8:00:00 AM', 'false', '/images/character/air2.jpg');


CREATE TABLE tblBattle 
(
    battleID int IDENTITY(1,1) PRIMARY KEY,
    username varchar(255) not null,
	enemyUsername varchar(255)  not null,
	titanName varchar(255)  not null,
	enemyTitanName varchar(255)  not null,
	date varchar(255) not null,
	result varchar(255) not null,
	expObtained int not null,
	element varchar(255),
	enemyElement varchar(255),
	isChallenger varchar(255),
);

CREATE TABLE tblElementType
(
    element varchar(255) PRIMARY KEY not null,
);
INSERT INTO tblElementType values ('fire');
INSERT INTO tblElementType values ('water');
INSERT INTO tblElementType values ('earth');
INSERT INTO tblElementType values ('air');

CREATE TABLE tblLookupExp
(
    level int not null,
	step int not null PRIMARY KEY (level, step),
	experiencePoint int not null
);
INSERT INTO tblLookupExp values (1,1,0);
INSERT INTO tblLookupExp values (1,2,201);
INSERT INTO tblLookupExp values (1,3,426);
INSERT INTO tblLookupExp values (1,4,675);
INSERT INTO tblLookupExp values (2,1,1001);
INSERT INTO tblLookupExp values (2,2,1401);
INSERT INTO tblLookupExp values (2,3,1901);
INSERT INTO tblLookupExp values (2,4,2401);
INSERT INTO tblLookupExp values (3,1,3001);
INSERT INTO tblLookupExp values (3,2,3701);
INSERT INTO tblLookupExp values (3,3,4501);
INSERT INTO tblLookupExp values (3,4,5401);
INSERT INTO tblLookupExp values (4,1,6401);
INSERT INTO tblLookupExp values (4,2,7501);
INSERT INTO tblLookupExp values (4,3,8701);
INSERT INTO tblLookupExp values (4,4,10001);