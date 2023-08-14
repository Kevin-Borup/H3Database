CREATE TABLE LibraryCards (
	UserID uniqueidentifier,
	RentedBooks int,
	CreationDate datetime,
	CONSTRAINT fk_libraryCards_userID FOREIGN KEY (UserID) REFERENCES Persons(ID)
);