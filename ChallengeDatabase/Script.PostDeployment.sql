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
BEGIN

DELETE FROM [MacAddress]


INSERT INTO [MacAddress]([Mac_Address], [UserID], [Name],[DateIssued]) VALUES
('4B-9C-6D-09-C0-C3', '6c5e8ac1-1331-4dc5-b431-7abc423a8407', 'Kandace WyettR', '11/01/2017'),
('76-37-47-F0-2D-98', '6c5e8ac1-1331-4dc5-b431-7abc423a8407', 'Kellby GrayshanR', '5/14/2018'),
('51-7E-BA-E5-15-F6',null,null,null);


END