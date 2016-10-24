CREATE TABLE [dbo].[User] (
    [Id]         INT            NOT NULL IDENTITY(1,1),
    [FirstName]  NVARCHAR (100) NOT NULL,
    [MiddleName] NVARCHAR (100) NULL,
    [LastName]   NVARCHAR (100) NOT NULL,    
    [Email]      NVARCHAR (100) NOT NULL,
	[Password] NVARCHAR (100) NOT NULL,
    [CreateDate] DATETIME       DEFAULT (getdate()) NOT NULL,
	[PhoneNumber] NVARCHAR (100) NOT NULL,
	[Address] NVARCHAR(50) NOT NULL,
	[Address2] NVARCHAR(50) NOT NULL,
    [City] NVARCHAR(50) NOT NULL, 
    [State] NVARCHAR(5) NOT NULL, 
    [ZipCode] NCHAR(10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


