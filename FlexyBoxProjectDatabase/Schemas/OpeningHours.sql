CREATE TABLE [dbo].[Openings]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1),
	[Name] VARCHAR(50) NULL, 
    [Toggled] BIT NULL,
	[ResturantId] INT NULL

    CONSTRAINT FK_ResturantOpeningHours Foreign Key  ([ResturantId])  REFERENCES [Resturants](Id)
    
)
