CREATE TABLE Lessons
(
    Id         SERIAL NOT NULL PRIMARY KEY,
    LessonName VARCHAR(50),
    Date       DATE   NOT NULL DEFAULT CURRENT_DATE
);

CREATE TABLE TimeCodes
(
    Id       SERIAL NOT NULL PRIMARY KEY,
    Time     TIME   NOT NULL DEFAULT CURRENT_TIME,
    LessonId SERIAL NOT NULL REFERENCES Lessons (Id),
    FOREIGN KEY (LessonId) REFERENCES Lessons (Id)
);

CREATE TABLE Members
(
    Id    SERIAL       NOT NULL PRIMARY KEY,
    Name  VARCHAR(50),
    Email VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE MemberLessons
(
    MemberId SERIAL NOT NULL REFERENCES Members (Id),
    LessonId SERIAL NOT NULL REFERENCES Lessons (Id),
    PRIMARY KEY (MemberId, LessonId)
);

CREATE TABLE Questions
(
    Id         SERIAL NOT NULL PRIMARY KEY,
    Question   TEXT   NOT NULL,
    LessonId   SERIAL NOT NULL REFERENCES Lessons (Id),
    MemberId   SERIAL NOT NULL REFERENCES Members (Id),
    TimeCodeId SERIAL NOT NULL REFERENCES TimeCodes (Id),
    FOREIGN KEY (LessonId) REFERENCES Lessons (Id),
    FOREIGN KEY (MemberId) REFERENCES Members (Id),
    FOREIGN KEY (TimeCodeId) REFERENCES TimeCodes (Id)
);
