CREATE TABLE [dbo].[OrderInfo] (
    [Id]     INT     IDENTITY(1,1)   NOT NULL, 
	[ProdId] INT NOT NULL, 
    [UserId] INT        NOT NULL, 
	[PaymentId] INT NOT NULL, 
	[Total]  SMALLMONEY NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC),
	CONSTRAINT fk_id_prod FOREIGN KEY (ProdId) REFERENCES [Product](Id),
	CONSTRAINT fk_id_user FOREIGN KEY (UserId) REFERENCES [User](Id), 
);


