/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
INSERT INTO Product(Id,[Location], Price, RegionId, [Description], Image_1, Image_2, Image_3, WeatherLocaterId)
VALUES (1, 'Hawaii', 5000.00, 1, 'Visit Hawaii!', null, null, null, 'Honolul, HI'),
		(2, 'Maine', 800.00, 3, 'Visit Maine!', null, null, null, 'Portland,ME'),
		(3, 'Fiji', 10000.00, 1, 'Visit Fiji!', NULL, NULL, NULL, 'Suva,Fiji'),
		(4, 'Madagascar', 8000.00, 2, 'Visit Madagascar!', NULL, NULL, NULL, 'Antananarivo,Madagascar'),
		(5, 'Ivory Coast', 6000.00, 2, 'Visit Ivory Coast!', NULL, NULL, NULL, 'Abidjan, Ivory Coast')
