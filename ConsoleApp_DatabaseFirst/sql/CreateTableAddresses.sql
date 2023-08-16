CREATE TABLE Addresses (
	ID uniqueidentifier PRIMARY KEY not null,
	Street varchar(255),
	City varchar(255),
	State varchar(255) NULL,
	PostalCode int,
	Country varchar(255)
);