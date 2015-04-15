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

MERGE INTO Computer AS Target
USING ( VALUES
	(1, 'Small PC', 'Ultra-Small Form Factor', '2015-02-16'),
	(2, 'Desktop PC', 'ATX', '2015-04-22'),
	(3, 'NUC PC', 'NUC', '2015-03-09')
