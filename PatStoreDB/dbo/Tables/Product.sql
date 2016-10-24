CREATE TABLE [dbo].[Product] (
    [Id]       INT           NOT NULL IDENTITY(1,1),
    [Location] NVARCHAR (50) NOT NULL,
    [Price]    MONEY         NOT NULL,
    [RegionId] INT           NOT NULL,
	[Description] NVARCHAR (1000) NOT NULL,
	[Image_1] NVARCHAR (1000)  NULL,
	[Image_2] NVARCHAR (1000) NULL,
	[Image_3] NVARCHAR (1000) NULL,
	[WeatherLocaterId] NVARCHAR (1000) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [fk_region_product] FOREIGN KEY ([RegionId]) REFERENCES [dbo].[RegionInfo] ([Id])
);

