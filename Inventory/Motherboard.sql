CREATE TABLE [dbo].[Motherboard]
(
	[MotherboardID]	INT	IDENTITY (1, 1)	NOT NULL,
	[Make]	VARCHAR (50)	NULL,
	[Model] VARCHAR (50)	NULL,
	[NumberOfDisplayPorts]	INT		NULL,
	[NumberOfMemoryPorts]	INT		NULL,
	[HasParallelPort]		BIT		NOT NULL,
	PRIMARY KEY CLUSTERED ([MotherboardID] ASC)
)
