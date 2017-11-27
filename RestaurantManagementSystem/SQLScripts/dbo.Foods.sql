CREATE TABLE [dbo].[Foods] (
    [FoodId]           INT          IDENTITY (1, 1) NOT NULL,
    [Name]             VARCHAR (50) NOT NULL,
    [Amount]           NCHAR (10)   NOT NULL,
    [Price]            MONEY        NOT NULL,
    [FoodType]         VARCHAR (50) NOT NULL,
    [BoughtDate]       DATE         NOT NULL,
    [ExpirationDate]   DATE         NOT NULL,
    [ManufacturedDate] DATE         NOT NULL, 
    CONSTRAINT [PK_Foods] PRIMARY KEY ([FoodId])
);

