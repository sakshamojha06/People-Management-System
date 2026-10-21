PRAGMA foreign_keys = ON;

CREATE TABLE IF NOT EXISTS EducationLevels (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL UNIQUE
);

CREATE TABLE IF NOT EXISTS Degrees (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    EducationLevelId INTEGER NOT NULL,
    Name TEXT NOT NULL,

    FOREIGN KEY (EducationLevelId)
        REFERENCES EducationLevels(Id),

    UNIQUE (EducationLevelId, Name)
);

CREATE TABLE IF NOT EXISTS Specializations (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    DegreeId INTEGER NOT NULL,
    Name TEXT NOT NULL,

    FOREIGN KEY (DegreeId)
        REFERENCES Degrees(Id),

    UNIQUE (DegreeId, Name)
);

CREATE TABLE IF NOT EXISTS People (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    EducationLevelId INTEGER NOT NULL,
    DegreeId INTEGER NOT NULL,
    SpecializationId INTEGER NOT NULL,

    FOREIGN KEY (EducationLevelId)
        REFERENCES EducationLevels(Id),

    FOREIGN KEY (DegreeId)
        REFERENCES Degrees(Id),

    FOREIGN KEY (SpecializationId)
        REFERENCES Specializations(Id)
);
