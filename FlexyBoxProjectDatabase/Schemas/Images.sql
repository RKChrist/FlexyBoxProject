CREATE TABLE [dbo].[Images]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Uid] UNIQUEIDENTIFIER NULL, 
    [AltText] VARCHAR(255) NULL, 
    [FileName] VARCHAR(255) NULL, 
    [FileType] NCHAR(10) NULL,
    [ResturantId] INT NOT NULL
    CONSTRAINT FK_ImagesResturant Foreign Key  ([ResturantId])  REFERENCES [Resturants](Id)
)
