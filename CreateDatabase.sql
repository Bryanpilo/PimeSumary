USE PimeSumary
GO
CREATE TABLE SumaryPime (
    Id int NOT NULL IDENTITY,
	Name varchar(255),
    Email varchar(255),
    Phone varchar(255),
    Address varchar(255),
	PRIMARY KEY (Id)
);
GO
CREATE TABLE Product (
	Id int NOT NULL IDENTITY,
	IdSumaryPime INT NOT NULL,
	NameProduct VARCHAR(50),
	UnitPrice decimal,
	PRIMARY KEY (Id),
	FOREIGN KEY (IdSumaryPime) REFERENCES SumaryPime(Id)
);
GO
CREATE TABLE BillingType(
	Id INT NOT NULL IDENTITY,
	TYPE VARCHAR(100),
	PRIMARY KEY (Id)
);
GO
CREATE TABLE BillingTypeUser(
	Id INT NOT NULL IDENTITY,
	IdSumaryPime INT NOT NULL,
	IdBillingType INT NOT NULL,
	PRIMARY KEY (Id),
	FOREIGN KEY (IdSumaryPime) REFERENCES SumaryPime(Id),
	FOREIGN KEY (IdBillingType) REFERENCES BillingType(Id)
);