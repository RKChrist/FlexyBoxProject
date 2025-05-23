CREATE TABLE [dbo].[Resturants] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [Name]          NVARCHAR (MAX) NOT NULL,
    [Description]   NVARCHAR (MAX) NOT NULL,
    [Type]          NVARCHAR (MAX) NOT NULL,
    [Email]         NVARCHAR (MAX) NOT NULL,
    [Open]          BIT            NOT NULL,
    [Address]       NVARCHAR (MAX) NOT NULL,
    [PostCode]      NVARCHAR (MAX) NOT NULL,
    [City]          NVARCHAR (MAX) NOT NULL,
    [TelefonNumber] NVARCHAR (MAX) NOT NULL,
    [Country]       NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Resturants] PRIMARY KEY CLUSTERED ([Id] ASC)
);

