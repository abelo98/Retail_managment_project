CREATE TABLE [dbo].[Sale]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CashierId] NCHAR(128) NOT NULL, 
    [SaleDate] DATETIME2 NOT NULL, 
    [Subtotal] MONEY NOT NULL, 
    [Tax] MONEY NOT NULL, 
    [Total] MONEY NOT NULL
)
