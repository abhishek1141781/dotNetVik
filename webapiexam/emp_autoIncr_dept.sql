CREATE TABLE [dbo].[Departments] (
    [DeptNo]   INT          NOT NULL,
    [DeptName] VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([DeptNo] ASC)
);

CREATE TABLE [dbo].[Employees] (
    [EmpNo]  INT IDENTITY(1,1) NOT NULL,
    [Name]   VARCHAR (50)    NOT NULL,
    [Basic]  DECIMAL (18, 2) NOT NULL,
    [DeptNo] INT             NULL,
    PRIMARY KEY CLUSTERED ([EmpNo] ASC),
    CONSTRAINT [FK_Employees_ToTable] FOREIGN KEY ([DeptNo]) REFERENCES [dbo].[Departments] ([DeptNo])
);