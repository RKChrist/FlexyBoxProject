CREATE TABLE [dbo].[Days] (
    [Id]            INT      IDENTITY (1, 1) NOT NULL,
    [OpeningsId]    INT      NOT NULL,
    [Days]          INT      NOT NULL,
    [StartTimeSlot] TIME (7) NOT NULL,
    [EndTimeSlot]   TIME (7) NOT NULL,
    CONSTRAINT [PK_Days] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Days_Openings_OpeningsId] FOREIGN KEY ([OpeningsId]) REFERENCES [dbo].[Openings] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Days_OpeningsId]
    ON [dbo].[Days]([OpeningsId] ASC);

