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
	(1, 'Small PC', 'Ultra-Small Form Factor', '2015-02-16', '2015-04-12'),
	(2, 'Desktop PC', 'ATX', '2015-04-22', '2015-04-25'),
	(3, 'NUC PC', 'NUC', '2015-03-09', '2015-04-09')
	)
AS Source (ComputerID, Name, FormFactor, PurchaseDate, InstallDate)
ON Target.ComputerID = Source.ComputerID
WHEN NOT MATCHED BY TARGET THEN
INSERT (Name, FormFactor, PurchaseDate, InstallDate)
VALUES (Name, FormFactor, PurchaseDate, InstallDate);

MERGE INTO Harddrive AS Target
USING ( VALUES
	(1, 'Hard Disk Drive', 500, 1),
	(2, 'Hard Disk Drive', 500, 2),
	(3, 'Solid State Drive', 120, 3)
	)
AS Source (HarddriveID, Type, Capacity, ComputerID)
ON Target.HarddriveID = Source.HarddriveID
WHEN NOT MATCHED BY TARGET THEN
INSERT (Type, Capacity, ComputerID)
VALUES (Type, Capacity, ComputerID);

MERGE INTO Motherboard AS Target
USING ( VALUES
	(1, 'Asus', 'Z-87', 2, 4, 0, 1),
	(2, 'Asus', 'Z-97A', 2, 4, 1, 2),
	(3, 'Intel', 'D771-GYK', 1, 2, 0, 3)
	)
AS Source (MotherboardID, Make, Model, NumberOfDisplayPorts,
	NumberOfMemoryPorts, HasParallelPort, ComputerID)
ON Target.MotherboardID = Source.MotherboardID
WHEN NOT MATCHED BY TARGET THEN
INSERT(Make, Model, NumberOfDisplayPorts,
	NumberOfMemoryPorts, HasParallelPort, ComputerID)
VALUES (Make, Model, NumberOfDisplayPorts,
	NumberOfMemoryPorts, HasParallelPort, ComputerID);

MERGE INTO OperatingSystem AS Target
USING ( VALUES
	(1, 'Windows', 'Professional', 86, 1),
	(2, 'Windows', 'Professional', 64, 2),
	(3, 'Windows', 'Professional', 86, 3)
	)
AS Source (OperatingSystemID, Name, Version, Architecture, ComputerID)
ON Target.OperatingSystemID = Source.OperatingSystemID
WHEN NOT MATCHED BY TARGET THEN
INSERT(Name, Version, Architecture, ComputerID)
VALUES(Name, Version, Architecture, ComputerID);

MERGE INTO Processor AS Target
USING ( VALUES
	(1, 'Intel', 'i3-4130', 2, 3.4, 1),
	(2, 'Intel', 'i5-4460', 4, 3.2, 2),
	(3, 'Intel', 'i3-3217U', 2, 1.8, 3)
	)
AS Source (ProcessorID, Make, Model, NumberOfCores, Speed, ComputerID)
ON Target.ProcessorID = Source.ProcessorID
WHEN NOT MATCHED BY TARGET THEN
INSERT(Make, Model, NumberOfCores, Speed, ComputerID)
VALUES(Make, Model, NumberOfCores, Speed, ComputerID);

MERGE INTO Ram AS Target
USING ( VALUES
	(1, 'DDR2-SDRAM', 6400, 8, 1),
	(2, 'DDR2-SDRAM', 6400, 8, 2),
	(3, 'SO-DIMM', 1300, 8, 3)
	)
AS Source (RamID, Type, Speed, Amount, ComputerID)
ON Target.RamID = Source.RamID
WHEN NOT MATCHED BY TARGET THEN
INSERT(Type, Speed, Amount, ComputerID)
VALUES(Type, Speed, Amount, ComputerID);