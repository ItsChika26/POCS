
CREATE TABLE Achievements
(
  Description VARCHAR(100) NULL    ,
  XP_Gain     INT          NULL    ,
  Name        VARCHAR(25)  NOT NULL,
  PRIMARY KEY (Name)
);

CREATE TABLE Games
(
  Name        VARCHAR(25)  NOT NULL,
  Description VARCHAR(200) NULL    ,
  Icon        VARBINARY(MAX)         NULL    ,
  PRIMARY KEY (Name)
);

CREATE TABLE Relationships
(
  User1   VARCHAR(25) NOT NULL,
  User2   VARCHAR(25) NOT NULL,
  Date    DATETIME    NULL    ,
  Pending BIT     NULL    
);

CREATE TABLE User_Achievements
(
  Username VARCHAR(25) NOT NULL,
  Name     VARCHAR(25) NOT NULL
);

CREATE TABLE Users
(
  Username        VARCHAR(25) NOT NULL,
  Password        VARCHAR(25) NOT NULL,
  Level           INT         NOT NULL,
  XP              INT         NOT NULL,
  Image           VARBINARY(MAX)        NULL    ,
  Date_Registered DATETIME    NOT NULL,
  Last_Login_Date DATETIME    NULL    ,
  Online          BIT     NULL    ,
  PRIMARY KEY (Username)
);

CREATE TABLE Users_Games
(
  Name     VARCHAR(25) NOT NULL,
  Username VARCHAR(25) NOT NULL
);

ALTER TABLE Relationships
  ADD CONSTRAINT FK_Users_TO_Relationships
    FOREIGN KEY (User1)
    REFERENCES Users (Username);

ALTER TABLE Relationships
  ADD CONSTRAINT FK_Users_TO_Relationships1
    FOREIGN KEY (User2)
    REFERENCES Users (Username);

ALTER TABLE Users_Games
  ADD CONSTRAINT FK_Games_TO_Users_Games
    FOREIGN KEY (Name)
    REFERENCES Games (Name);

ALTER TABLE Users_Games
  ADD CONSTRAINT FK_Users_TO_Users_Games
    FOREIGN KEY (Username)
    REFERENCES Users (Username);

ALTER TABLE User_Achievements
  ADD CONSTRAINT FK_Users_TO_User_Achievements
    FOREIGN KEY (Username)
    REFERENCES Users (Username);

ALTER TABLE User_Achievements
  ADD CONSTRAINT FK_Achievements_TO_User_Achievements
    FOREIGN KEY (Name)
    REFERENCES Achievements (Name);
