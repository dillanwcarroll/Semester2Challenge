CREATE TABLE [dbo].[MacAddress]
(
	[Mac_Address] varchar(200) NOT NULL PRIMARY KEY,
	[UserID] nvarchar(200) Null,
	[Name] nvarchar(100) Null,
	[DateIssued] varchar(20),
	--Constraint FK_User Foreign Key(UserID) References AspNetUsers(ID)
)
