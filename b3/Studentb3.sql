CREATE TABLE [dbo].[Students] (
    [StudentNo] INT IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (100) NOT NULL,
    [Section]   VARCHAR (100) NOT NULL,
    [Branch]    VARCHAR (100) NOT NULL,
    [EmailId]   VARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([StudentNo] ASC)
);

