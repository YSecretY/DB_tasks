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

INSERT INTO Lessons (LessonName, Date)
VALUES ('Introduction to SQL', '2023-10-14');

INSERT INTO Lessons (LessonName, Date)
VALUES ('Database Design Basics', '2023-10-13');

INSERT INTO TimeCodes (Time, LessonId)
VALUES ('10:00:00', 1);

INSERT INTO TimeCodes (Time, LessonId)
VALUES ('11:30:00', 2);

INSERT INTO TimeCodes (Time, LessonId)
VALUES ('11:31:00', 2);

INSERT INTO Members (Name, Email)
VALUES ('Alice', 'alice@example.com');

INSERT INTO Members (Name, Email)
VALUES ('Bob', 'bob@example.com');


INSERT INTO MemberLessons (MemberId, LessonId)
VALUES (2, 1);

INSERT INTO MemberLessons (MemberId, LessonId)
VALUES (1, 2);

INSERT INTO MemberLessons (MemberId, LessonId)
VALUES (2, 2);


INSERT INTO Questions (Question, LessonId, MemberId, TimeCodeId)
VALUES ('What is a database?', 1, 1, 1);

INSERT INTO Questions (Question, LessonId, MemberId, TimeCodeId)
VALUES ('How to create ER diagrams?', 2, 2, 2);

INSERT INTO Questions(Question, LessonId, MemberId, TimeCodeId)
VALUES ('How to use sql?', 1, 1, 1);

UPDATE Questions
SET LessonId = 2
WHERE Id = 1;

SELECT TC.Time AS "Time of TimeCode"
FROM TimeCodes TC
WHERE TC.LessonId = 2;

SELECT Member.Name                           AS "Member name",
       Lesson.LessonName                     AS "Lesson name",
       COUNT(DISTINCT Question.Id)           AS "Number of questions",
       COUNT(DISTINCT Timecode.Id)           AS "Number of timecodes",
       COUNT(DISTINCT MemberLesson.LessonId) AS "Number of Attended Lessons"
FROM Members Member
         INNER JOIN MemberLessons MemberLesson ON Member.Id = MemberLesson.MemberId
         INNER JOIN Lessons Lesson ON MemberLesson.LessonId = Lesson.Id
         LEFT JOIN Questions Question ON MemberLesson.MemberId = Question.MemberId
         LEFT JOIN TimeCodes TimeCode ON Question.TimeCodeId = TimeCode.Id
GROUP BY Member.Id, Lesson.Id, Lesson.Date
ORDER BY Lesson.Date;

SELECT *
FROM Lessons Lesson
WHERE Lesson.Id IN (SELECT DISTINCT TimeCode.LessonId
                    FROM TimeCodes TimeCode);
