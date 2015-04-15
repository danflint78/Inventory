CREATE TABLE [dbo].[Computer]
(
	[ComputerID]	INT		IDENTITY (1, 1) NOT NULL,
	[Name]			VARCHAR(75)	NOT NULL,
	[FormFactor]	VARCHAR(50)	NULL,
	[PurchaseDate]	DATETIME	NULL, 
	PRIMARY KEY CLUSTERED ([ComputerID] ASC), 
    CONSTRAINT [FK_Computer_Processor] FOREIGN KEY ([ComputerID])
		REFERENCES [Processor]([ProcessorID])
			ON DELETE CASCADE, 
    CONSTRAINT [FK_Computer_Motherboard] FOREIGN KEY ([ComputerID])
		REFERENCES [Motherboard]([MotherboardID])
			ON DELETE CASCADE,

)
