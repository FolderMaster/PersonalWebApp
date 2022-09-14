CREATE TABLE [dbo].[Profiles]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [Nick] NVARCHAR(MAX) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [Avatar] INT NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_Profiles_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id]), 
    CONSTRAINT [FK_Profiles_Files] FOREIGN KEY ([Avatar]) REFERENCES [Files]([Id])
)