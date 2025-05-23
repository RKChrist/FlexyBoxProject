CREATE TABLE [dbo].[Images] (
    [Id]          INT              IDENTITY (1, 1) NOT NULL,
    [Uid]         UNIQUEIDENTIFIER NOT NULL,
    [AltText]     NVARCHAR (MAX)   NOT NULL,
    [FileName]    NVARCHAR (MAX)   NOT NULL,
    [FileType]    NVARCHAR (MAX)   NOT NULL,
    [ResturantId] INT              NOT NULL,
    CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Images_Resturants_ResturantId] FOREIGN KEY ([ResturantId]) REFERENCES [dbo].[Resturants] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Images_ResturantId]
    ON [dbo].[Images]([ResturantId] ASC);

