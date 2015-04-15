CREATE TABLE [dbo].[Processor]
(
	[ProcessorID]	INT	IDENTITY (1, 1)	NOT NULL,
	[Make]			VARCHAR		(50)	NULL,
	[Model]			VARCHAR		(50)	NULL,
	[NumberOfCores]	INT					NULL,
	[Speed]			DECIMAL (3, 2)		NULL,
	PRIMARY KEY CLUSTERED ([ProcessorID] ASC)
)
