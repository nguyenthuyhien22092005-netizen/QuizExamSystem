CREATE DATABASE QuizExamDB;
GO

USE QuizExamDB;
GO

CREATE TABLE Users (
    UserId INT IDENTITY PRIMARY KEY,
    Username NVARCHAR(50),
    Password NVARCHAR(50),
    Role NVARCHAR(20)
);

CREATE TABLE Subjects (
    SubjectId INT IDENTITY PRIMARY KEY,
    SubjectName NVARCHAR(100)
);

CREATE TABLE Questions (
    QuestionId INT IDENTITY PRIMARY KEY,
    SubjectId INT,
    Content NVARCHAR(MAX),
    CorrectAnswer NVARCHAR(10),
    FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId)
);

CREATE TABLE Exams (
    ExamId INT IDENTITY PRIMARY KEY,
    SubjectId INT,
    ExamDate DATETIME,
    FOREIGN KEY (SubjectId) REFERENCES Subjects(SubjectId)
);

CREATE TABLE Results (
    ResultId INT IDENTITY PRIMARY KEY,
    UserId INT,
    ExamId INT,
    Score FLOAT,
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (ExamId) REFERENCES Exams(ExamId)
);
