CREATE TABLE [dbo].[User] (
    [Id]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [Email]    VARCHAR (250) NOT NULL,
    [UserName] VARCHAR (250) NOT NULL,
    [Password] VARCHAR (250) NOT NULL,
    [Status]   BIT           NOT NULL,
    [Sex]      VARCHAR (4)   NOT NULL,
    [Creation] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

