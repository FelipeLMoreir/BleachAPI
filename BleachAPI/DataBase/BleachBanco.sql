CREATE DATABASE BleachAPIDB

USE BleachAPIDB


CREATE TABLE BleachCharacter (
    Id                UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    ExternalId        NVARCHAR(100)    NOT NULL UNIQUE,  
    Slug              NVARCHAR(200)    NOT NULL,
    NameEnglish       NVARCHAR(200)    NOT NULL,
    NameKanji         NVARCHAR(200)    NULL,
    NameRomaji        NVARCHAR(200)    NULL,
    Description       NVARCHAR(MAX)    NULL,
    Race              NVARCHAR(50)     NOT NULL,         
    Gender            NVARCHAR(50)     NULL,
    Birthday          NVARCHAR(100)    NULL,
    Age               NVARCHAR(100)    NULL,
    Occupation        NVARCHAR(500)    NULL,
    Education         NVARCHAR(500)    NULL,
    Shikai            NVARCHAR(200)    NULL,
    Bankai            NVARCHAR(200)    NULL,
    CreatedAt         DATETIME2        DEFAULT GETUTCDATE(),
    UpdatedAt         DATETIME2        DEFAULT GETUTCDATE()
);

CREATE TABLE CharacterAffiliation (
    Id              UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    CharacterId     UNIQUEIDENTIFIER NOT NULL,
    AffiliationName NVARCHAR(200)    NOT NULL,
    IsPrevious      BIT              NOT NULL DEFAULT 0,  
    CONSTRAINT FK_CharacterAffiliation_Character 
        FOREIGN KEY (CharacterId) REFERENCES BleachCharacter(Id) ON DELETE CASCADE
);

CREATE TABLE CharacterBaseOps (
    Id              UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    CharacterId     UNIQUEIDENTIFIER NOT NULL,
    BaseOpName      NVARCHAR(200)    NOT NULL,
    CONSTRAINT FK_CharacterBaseOps_Character 
        FOREIGN KEY (CharacterId) REFERENCES BleachCharacter(Id) ON DELETE CASCADE
);

CREATE TABLE CharacterRelative (
    Id              UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    CharacterId     UNIQUEIDENTIFIER NOT NULL,
    RelativeName    NVARCHAR(200)    NOT NULL,
    CONSTRAINT FK_CharacterRelative_Character 
        FOREIGN KEY (CharacterId) REFERENCES BleachCharacter(Id) ON DELETE CASCADE
);

CREATE INDEX IX_BleachCharacter_ExternalId ON BleachCharacter(ExternalId);
CREATE INDEX IX_BleachCharacter_Race ON BleachCharacter(Race);
CREATE INDEX IX_CharacterAffiliation_CharacterId ON CharacterAffiliation(CharacterId);

ALTER TABLE BleachCharacter
ALTER COLUMN NameEnglish  NVARCHAR(255) NULL

ALTER TABLE BleachCharacter
ALTER COLUMN Race NVARCHAR(50) Null

SELECT * FROM BleachCharacter
SELECT * FROM CharacterAffiliation
SELECT * FROM CharacterBaseOps
SELECT * FROM CharacterRelative

