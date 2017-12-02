CREATE TABLE [dbo].[Reservations] (
    [ReservationId]          INT              IDENTITY (1, 1) NOT NULL,
    [Email]       VARCHAR (50)     NOT NULL,
    [Persons]        NUMERIC     NOT NULL,
    [Date]     Date     NOT NULL,
    [FromTime]        VARCHAR(50)             NOT NULL,
    [ToTime]           VARCHAR (50)     NOT NULL,
    [Menu1]        VARCHAR (50)     NULL,
    [Menu2]		   VARCHAR (50)     NULL, 
	[Menu3]		   VARCHAR (50)     NULL, 
	[Menu4]		   VARCHAR (50)     NULL, 
	[Menu5]		   VARCHAR (50)     NULL, 
    [Total] MONEY NOT NULL, 
    [Details] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Reservations] PRIMARY KEY ([ReservationId]),
);

