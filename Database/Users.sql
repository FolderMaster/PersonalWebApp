CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nick] NCHAR(10) NOT NULL, 
    [Name] NCHAR(10) NOT NULL, 
    [Password] NCHAR(10) NOT NULL, 
    [Phone] NCHAR(10) NULL, 
    [Email] NCHAR(10) NULL, 
    [Status] INT NOT NULL, 
    [Rights] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL
)