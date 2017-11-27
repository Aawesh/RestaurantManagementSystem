CREATE TABLE [dbo].[Users] (
    [UserId]          INT              IDENTITY (1, 1) NOT NULL,
    [FirstName]       VARCHAR (50)     NOT NULL,
    [LastName]        VARCHAR (50)     NOT NULL,
    [PhoneNumber]     NUMERIC (10)     NOT NULL,
    [Email]           VARCHAR (50)     NOT NULL,
    [Password]        VARCHAR (50)     NOT NULL,
    [IsEmailVerified] BIT              NOT NULL,
    [ActivationCode]  UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [PK_Users] PRIMARY KEY ([UserId])
);

