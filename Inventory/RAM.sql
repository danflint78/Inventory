﻿CREATE TABLE [dbo].[RAM]
(
	[RamID]	INT	IDENTITY(1, 1)	NOT NULL,
	[Type]	VARCHAR(50)	NULL,
	[Speed]	INT	NOT NULL,
	[Amount] INT NOT NULL,
	[ComputerID] INT	NOT NULL,
	PRIMARY KEY CLUSTERED ([RamID] ASC), 
    CONSTRAINT [FK_RAM_Computer] FOREIGN KEY ([ComputerID])
		REFERENCES [Computer]([ComputerID])
	
)
