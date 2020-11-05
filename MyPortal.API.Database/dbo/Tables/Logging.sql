CREATE TABLE [dbo].[Logging] (
    [Id]              INT                IDENTITY (1, 1) NOT NULL,
    [Message]         NVARCHAR (MAX)     NULL,
    [MessageTemplate] NVARCHAR (MAX)     NULL,
    [Level]           NVARCHAR (MAX)     NULL,
    [TimeStamp]       DATETIMEOFFSET (7) NOT NULL,
    [Exception]       NVARCHAR (MAX)     NULL,
    [Properties]      NVARCHAR (MAX)     NULL,
    CONSTRAINT [PK_Logging] PRIMARY KEY CLUSTERED ([Id] ASC)
);

