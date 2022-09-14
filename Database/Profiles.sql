CREATE TABLE [dbo].[Profiles]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [Nick] NTEXT NOT NULL, 
    [Description] NTEXT NULL, 
    [Avatar] IMAGE NULL, 
    [CreatedDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_Profiles_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)