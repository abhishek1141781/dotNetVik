﻿CREATE TABLE [dbo].[Departments] (
    [DeptNo] INT          NOT NULL,
    [Name]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([DeptNo] ASC)
);

CREATE TABLE [dbo].[Students] (
    [Id]       INT          NOT NULL,
    [Name]     VARCHAR (50) NOT NULL,
    [DeptNo]   INT          NOT NULL,
    [Password] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Students_ToTable] FOREIGN KEY ([DeptNo]) REFERENCES [dbo].[Departments] ([DeptNo])
);