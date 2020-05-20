CREATE TABLE Users (
    ID int IDENTITY(1,1) PRIMARY KEY,
    [Name] varchar(255) NOT NULL,
    Highscore int,
    AnsweredQuestions int,
    CorrectAnswers int,
    WonMatches int,
    [IP] varchar(255)
);

CREATE TABLE UserMatch (
    MatchID int IDENTITY(1,1) PRIMARY KEY,
    IP1 varchar(255) NOT NULL,
    IP2 varchar(255) NOT NULL,
    Score1 int NOT NULL,
    Score2 int NOT NULL,
    Status1 BIT default 0,
    Status2 BIT default 0,
    MatchType varchar(225)
);

SELECT * FROM Users;