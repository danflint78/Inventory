CREATE TABLE [dbo].[OperatingSystem]
(
	[OperatingSystemID]	INT	IDENTITY(1, 1)	NOT NULL,
	[Name]	VARCHAR(25)	NOT NULL,
	[Version]	VARCHAR(50)	NOT NULL,
	[Architecture]	INT	NOT NULL,
	[ComputerID]	INT	NOT NULL
	PRIMARY KEY CLUSTERED ([OperatingSystemID] ASC)	
	CONSTRAINT [FK_OperatingSystem_Computer] FOREIGN KEY ([ComputerID])
		REFERENCES [Computer]([ComputerID])
)
