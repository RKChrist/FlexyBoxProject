CREATE TABLE [dbo].[Resturants]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Name] VARCHAR(255) NULL, 
    [Description] VARCHAR(255) NULL, 
    [Type] VARCHAR(255) NULL, 
    [Email] VARCHAR(255) NULL, 
    [PostCode] VarChar(255) NULL,
    [Open] VARCHAR(255) NULL, 
    [Address] VARCHAR(255) NULL, 
    [City] VARCHAR(255) NULL, 
    [TelefonNumber] VARCHAR(255) NULL, 
    [Country] VARCHAR(255) NULL,
)
