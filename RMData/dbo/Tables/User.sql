CREATE TABLE [dbo].[User]
(
    [Id] NCHAR(128) NOT NULL PRIMARY KEY, 
    [Firstname] BINARY(50) NOT NULL, 
    [LastName] NCHAR(50) NOT NULL, 
    [EmailAddress] NCHAR(256) NOT NULL, 
    [CreateDate] DATETIME2 NULL DEFAULT getutcdate()
)
