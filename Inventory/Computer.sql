CREATE TABLE [dbo].[Computer]
(
	[ComputerID]	INT	IDENTITY(1, 1)	NOT NULL,
	[Name]	VARCHAR(75)	NOT NULL,
	[FormFactor]	VARCHAR(50)	NULL,
	[InstallDate]	DATETIME	NULL,
	[PurchaseDate]	DATETIME	NULL, 
	PRIMARY KEY CLUSTERED ([ComputerID] ASC), 

)
