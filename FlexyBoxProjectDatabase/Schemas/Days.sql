CREATE TABLE [dbo].[Days]
(
	[Id] INT NOT NULL PRIMARY KEY Identity(1,1), 
    [Days] INT NOT NULL, 
    [StartTimeSlot] TIME NULL, 
    [EndTimeSlot] TIME NULL,
    OpeningsId INT NOT NULL


    CONSTRAINT FK_DaysOpenOpenings Foreign Key  (OpeningsId)  REFERENCES Openings(Id)
)
