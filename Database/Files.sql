CREATE TABLE [dbo].[Files]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Path] NVARCHAR(MAX) NOT NULL, 
    [Date] DATETIME NOT NULL
)
