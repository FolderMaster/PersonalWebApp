CREATE TABLE [dbo].[Users]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Password] NVARCHAR(MAX) NOT NULL, 
    [Phone] NVARCHAR(MAX) NULL, 
    [Email] NVARCHAR(MAX) NULL, 
    [Status] INT NOT NULL, 
    [Role] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL
)