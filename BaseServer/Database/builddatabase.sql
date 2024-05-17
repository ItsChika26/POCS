
DROP TABLE IF EXISTS User_Achievements;
DROP TABLE IF EXISTS Users_Games;
DROP TABLE IF EXISTS Achievements;
DROP TABLE IF EXISTS Games;
DROP TABLE IF EXISTS Relationships;
DROP TABLE IF EXISTS Users;

CREATE TABLE Users
(
  Username        VARCHAR(25) NOT NULL PRIMARY KEY,
  Password        VARCHAR(25) NOT NULL,
  Level           INT         NOT NULL,
  XP              INT         NOT NULL,
  Image           VARBINARY(MAX)        NULL    ,
  Date_Registered DATETIME    NOT NULL,
  Last_Login_Date DATETIME    NULL    ,
  Online          BIT     NOT NULL DEFAULT(0)   
);

CREATE TABLE Achievements
(
  Description VARCHAR(100) NULL    ,
  XP_Gain     INT          NULL    ,
  Name        VARCHAR(25)  NOT NULL PRIMARY KEY,
);

CREATE TABLE Games
(
  Name        VARCHAR(25)  NOT NULL PRIMARY KEY,
  Description VARCHAR(200) NULL    ,
  Icon        VARBINARY(MAX)         NULL    ,
);

CREATE TABLE Relationships
(
  User1   VARCHAR(25) NOT NULL,
  User2   VARCHAR(25) NOT NULL,
  Date    DATETIME    NULL    ,
  Pending BIT     NULL    ,
   FOREIGN KEY (User1)
   REFERENCES Users (Username),
   FOREIGN KEY (User2)
   REFERENCES Users (Username)

);

CREATE TABLE User_Achievements
(
  Username VARCHAR(25) NOT NULL,
  Name     VARCHAR(25) NOT NULL,
  Date     DATETIME    NULL    ,
  FOREIGN KEY (Username)
  REFERENCES Users (Username),
  FOREIGN KEY (Name)
  REFERENCES Achievements (Name)
);



CREATE TABLE Users_Games
(
  Name     VARCHAR(25) NOT NULL,
  Username VARCHAR(25) NOT NULL,
  FOREIGN KEY (Name)
  REFERENCES Games (Name),
  FOREIGN KEY (Username)
  REFERENCES Users (Username)
);

