CREATE TABLE [dbo].[Openings] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NOT NULL,
    [Toggled]     BIT            NOT NULL,
    [ResturantId] INT            NOT NULL,
    CONSTRAINT [PK_Openings] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Openings_Resturants_ResturantId] FOREIGN KEY ([ResturantId]) REFERENCES [dbo].[Resturants] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Openings_ResturantId]
    ON [dbo].[Openings]([ResturantId] ASC);

