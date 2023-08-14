DROP TABLE Persons

CREATE TABLE Persons (
	ID uniqueidentifier not null,
	Name varchar(255) not null,
	PhoneNumber varchar(255),
	EmailAddress varchar(255),
	AddressID uniqueidentifier,
	PRIMARY KEY(ID),
	CONSTRAINT fk_Persons_addressID FOREIGN KEY (AddressID) REFERENCES Addresses(ID)
);