CREATE TABLE [dbo].[Sales] (
    [SalesId]     INT   IDENTITY (1, 1) NOT NULL,
    [Date]        DATE  NOT NULL,
    [Income]      MONEY NOT NULL,
    [Expenditure] MONEY NOT NULL,
    [Profit]      MONEY NOT NULL, 
    CONSTRAINT [PK_Sales] PRIMARY KEY ([SalesId])
);

