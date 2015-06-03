CREATE TABLE [dbo].[Harddrive]
(
	[HarddriveID] INT IDENTITY(1, 1)	NOT NULL,
	[Type]	VARCHAR(25)	NOT NULL,
	[Capacity]	INT	NOT NULL,
	[ComputerID]	INT	NOT NULL
	PRIMARY KEY CLUSTERED ([HarddriveID] ASC)
	CONSTRAINT [FK_Harddrive_Computer] FOREIGN KEY ([ComputerID])
		REFERENCES [Computer]([ComputerID])
)
