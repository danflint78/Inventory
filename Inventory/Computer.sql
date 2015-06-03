CREATE TABLE [dbo].[Computer]
(
	[ComputerID]	INT	IDENTITY(1, 1)	NOT NULL,
	[Name]	VARCHAR(75)	NOT NULL,
	[FormFactor]	VARCHAR(50)	NULL,
	[PrimaryMac]	VARCHAR(50) NULL,
	[PurchaseDate]	DATETIME	NULL,
	[InstallDate]	DATETIME	NULL,
	PRIMARY KEY CLUSTERED ([ComputerID] ASC), 

)
