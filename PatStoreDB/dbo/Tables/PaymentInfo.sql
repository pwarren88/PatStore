CREATE TABLE [dbo].[PaymentInfo]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
	[UserId] INT NOT NULL, 	
    [CreditCardNumber] NVARCHAR(16) NOT NULL, 
	[CreditCardExpiration] DATETIME NOT NULL, 
	[CreditCardVerificationValue] INT NOT NULL, 
	[CreditCardName] NVARCHAR(22) NOT NULL, 
	[CreditCardAddress1] NVARCHAR(100) NOT NULL, 
	[CreditCardAddress2] NVARCHAR(100) NOT NULL, 
	[CreditCardCity] NVARCHAR(100) NOT NULL, 
	[CreditCardState] NVARCHAR(2) NOT NULL, 
	[CreditCardPostal] NVARCHAR(11) NOT NULL, 
    CONSTRAINT fk_payinfo_order FOREIGN KEY (UserId) REFERENCES [User](Id),
)
