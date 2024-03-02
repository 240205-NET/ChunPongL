/*
multi-line comments
*/
-- double-hyphen to inline/end of line comment

-- SQL Sub-Languages

/*
DDL -- Data Definition Language - manipulates the state/ (tables) of the database.
CREATE
ALTER
DROP 
*/

/*
-- DQL - Data Query Language - used to filter, structure, phrasing a query on the database.
SELECT
FROM
WHERE
ORDERBY
GROUPBY
AS
IF
JOIN
*/

/*
-- DML - Data Manipulation Language - used to modify and manipulate the content of the database/tables.
UPDATE
INSERT
TRUNCATE
DELETE
*/

/*
-- DCL - Data Control Language - used to administrate who can access the database.
GRANT
REVOKE
USER
LOGIN
*/

-- SQL - the language
-- Server - the physical device (cpu/memory)
-- database - the applicaton running on the server
-- schema - the design of the tables

/* Create Schema //////////////////////////////////
//////////////////////////////////////////////// */
CREATE SCHEMA [School];
GO

/* DROP STATEMENTS ////////////////////////////////////////////
//////////////////////////////////////////////////////////// */
-- DROP TABLE [School].[PokemonType];
-- DROP TABLE [School].[Pokemon];
-- DROP TABLE [School].[Type];
-- DROP SCHEMA [School];
-- GO



/* Create Tables ////////////////////////////////////////////
//////////////////////////////////////////////////////////// */
CREATE TABLE [School].[Pokemon]
(
    -- Data Types
    -- relationships
    Name VARCHAR(255) NOT NULL UNIQUE,
    Weight INT NOT NULL,
    Height INT NOT NULL,
    Id INT PRIMARY KEY IDENTITY -- PK gets UNIQUE AND NOT NULL by default!, IDENTITY == INDEX
);
GO


-- why the commas and semi-colons? we have to send this command to a server. that communication should be as short and sweet as we can get it!
-- CREATE TABLE [School].[Pokemon](Name VARCHAR(255) NOT NULL UNIQUE,Weight INT NOT NULL,Height INT NOT NULL,Id INT NOT NULL UNIQUE);


CREATE TABLE [School].[Type]
(
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(64) NOT NULL UNIQUE
);
GO

/*
Mulitplicity - the relationships between the tables/entries in the database
1 - 1 - for each entry in table a, there is one and only one related entry in table b
1 - m - for each entry in table a, there are many related entries in table b
m - m - for many entries in table a, there are many related entries in table b
    to create a m - m relationship in SQL, we need to use a linking-table, to establish two 1 - m relationships.

Normalizations - organizing our tables to separate concerns
"The Key, The Whole Key, And Nothing But The Key"
1NF - The Key
2NF - The Whole Key
3NF - Nothing But The Key
atomicity - every entry must be atomic - one field, one entry
*/

CREATE TABLE [School].[PokemonType]
(
    Id INT PRIMARY KEY IDENTITY,
    PokemonId INT NOT NULL FOREIGN KEY REFERENCES [School].[Pokemon] (Id) ON DELETE CASCADE,
    TypeId INT NOT NULL FOREIGN KEY REFERENCES [School].[Type] (Id) ON DELETE CASCADE
    -- CASCADE triggers the specific column to also delete/update when the FK entry is modified
);
GO

INSERT INTO [School].[Pokemon]
(Name, Height, Weight) 
VALUES
('Charizard', 67, 215), -- string entries in SQL ONLY USE A SINGLE QUOTE!!!!!!
('Mudkip', 24, 45);
GO

INSERT INTO [School].[Type]
(Name)
VALUES
('Fire'),
('Water'),
('Dragon'),
('Grass'),
('Flying');
GO

INSERT INTO [School].[PokemonType]
(PokemonId, TypeId)
VALUES
(1, 1),
(1, 5),
(2, 2);
GO


-- JOINS
SELECT NAME
    FROM [School].[Pokemon];

SELECT *
    FROM [School].[PokemonType];

SELECT *
    FROM [School].[Type];

SELECT *
    FROM [School].[Pokemon]
    WHERE Name = 'Charizard';

SELECT pt.Id, p.Name AS 'Pokemon Name', t.Name AS 'Pokemon Type'
    FROM [School].[PokemonType] AS pt 
    JOIN [School].[Pokemon] AS p
        ON pt.PokemonId = p.Id
    JOIN [School].[Type] AS t
        ON pt.TypeId = t.Id
    WHERE p.Name = 'Charizard';

-- CHINOOK