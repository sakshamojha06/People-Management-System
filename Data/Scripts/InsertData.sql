INSERT INTO EducationLevels (Name) VALUES ('Undergraducate'), ('Postgraduate'), ('Higher Secondary');

INSERT INTO Degrees (EducationLevelId, Name)
VALUES (1, 'B.Tech'), (1, 'B.Sc'), (2, 'MBA'), (2, 'M.Tech'), (3, 'Class 12');

INSERT INTO Specializations (DegreeId, Name)
VALUES 
(1, 'Computer Science'),
(1, 'Mechanical Engineering'),
(2, 'Mathematics'),
(2, 'Physics'),
(3, 'Finance'),
(3, 'Marketing'),
(4, 'Computer Science'),
(4, 'Electronics'),
(5, 'Science');

INSERT INTO People (Name, EducationLevelId, DegreeId, SpecializationId)
VALUES
('Raj Kumar', 1, 1, 1),
('Priya Sharma', 2, 3, 5),
('Amit Verma', 1, 2, 3),
('Sneha Iyer', 3, 5, 9);