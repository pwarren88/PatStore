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
INSERT INTO Product(Id,[Location], Price, RegionId, [Description])
VALUES (1, 'Hawaii', 5000.00, 1, 'Visit Hawaii!'),
		(2, 'Maine', 800.00, 3, 'Visit Maine!'),
		(3, 'Fiji', 10000.00, 1, 'Visit Fiji!'),
		(4, 'Madagascar', 8000.00, 2, 'Visit Madagascar!'),
		(5, 'Ivory Coast', 6000.00, 2, 'Visit Ivory Coast!')
