//creates

CREATE TABLE Users(
	UserId INT PRIMARY KEY IDENTITY(1,1),
	FirstName VARCHAR(50),
	LastName VARCHAR(50),
	Username VARCHAR(50),
	Property VARCHAR(50),
);

CREATE TABLE Programs(
	ProgramName VARCHAR(50) PRIMARY KEY,
	Benefits TEXT,
	Charge DECIMAL(5,2)
);

CREATE TABLE Phones(
	PhoneNumber VARCHAR(15) PRIMARY KEY NOT NULL,
	ProgramName VARCHAR(50)
);

CREATE TABLE Sellers(
	SellerId INT PRIMARY KEY IDENTITY(1,1),
	UserId INT,
	CONSTRAINT FK_Sellers_Users FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Admins(
	AdminId INT PRIMARY KEY IDENTITY (1,1),
	UserId INT,
	CONSTRAINT FK_Admins_Users FOREIGN KEY (UserId) REFERENCES Users(UserId)
); 

CREATE TABLE Clients(
	ClientId INT PRIMARY KEY IDENTITY(1,1),
	AFM VARCHAR(50),
	PhoneNumber VARCHAR(15),
	UserId INT,
	CONSTRAINT FK_Clients_Users FOREIGN KEY (UserId) REFERENCES Users(UserId),
	CONSTRAINT FK_Clients_Phones FOREIGN KEY (PhoneNumber) REFERENCES Phones(PhoneNumber)
);

CREATE TABLE Calls(
	CallId INT PRIMARY KEY IDENTITY(1,1),
	Description TEXT
);

CREATE TABLE Bills(
	BillId INT PRIMARY KEY IDENTITY(1,1),
	PhoneNumber VARCHAR(15),
	Costs DECIMAL(7,2),
	CONSTRAINT FK_Bills_Phones FOREIGN KEY (PhoneNumber) REFERENCES Phones(PhoneNumber)
);

CREATE TABLE BillsCalls(
	BillId INT,
	CallId INT,
	PRIMARY KEY (BillId, CallId),
	CONSTRAINT FK_Bills_Calls_1 FOREIGN KEY (BillId) REFERENCES Bills(BillId),
	CONSTRAINT FK_Bills_Calls_2 FOREIGN KEY (CallId) REFERENCES Calls(CallId)
);

INSERT INTO Users (FirstName, LastName, Username, Property)
VALUES ('Alice', 'Johnson', 'alicej', 'Verified'),
       ('Bob', 'Smith', 'bsmith', 'Admin'),
       ('Charlie', 'Brown', 'charlieb', 'Seller'),
       ('Diana', 'Prince', 'dprince', 'Client'),
       ('Eve', 'Adams', 'evea', 'Guest');

-- Insert Programs
INSERT INTO Programs (ProgramName, Benefits, Charge)
VALUES ('Basic Plan', '1 GB Storage, Email Support', 9.99),
       ('Premium Plan', '10 GB Storage, Priority Support', 19.99),
       ('Enterprise Plan', 'Unlimited Storage, 24/7 Support', 49.99);

-- Insert Phones
INSERT INTO Phones (PhoneNumber, ProgramName)
VALUES ('+1234567890', 'Basic Plan'),
       ('+0987654321', 'Premium Plan'),
       ('+1122334455', 'Enterprise Plan'),
       ('+2233445566', 'Basic Plan'),
       ('+3344556677', 'Premium Plan');

-- Insert Sellers
INSERT INTO Sellers (UserId)
VALUES (3); -- Referring to Charlie (UserId = 3)

-- Insert Admins
INSERT INTO Admins (UserId)
VALUES (2); -- Referring to Bob (UserId = 2)

-- Insert Clients
INSERT INTO Clients (AFM, PhoneNumber, UserId)
VALUES ('AFM12345', '+1234567890', 4), -- Diana (UserId = 4)
       ('AFM67890', '+0987654321', 5); -- Eve (UserId = 5)

-- Insert Calls
INSERT INTO Calls (Description)
VALUES ('International Call to Europe'),
       ('Local Call within the US'),
       ('Emergency Call'),
       ('Conference Call'),
       ('Voicemail Retrieval');

-- Insert Bills
INSERT INTO Bills (PhoneNumber, Costs)
VALUES ('+1234567890', 15.75), -- Associated with Diana
       ('+0987654321', 20.50), -- Associated with Eve
       ('+1122334455', 49.99); -- Associated with Charlie

-- Insert BillsCalls
INSERT INTO BillsCalls (BillId, CallId)
VALUES (1, 1), -- Bill for Diana includes an international call
       (1, 3), -- Emergency call on the same bill
       (2, 2), -- Bill for Eve includes a local call
       (2, 4), -- And a conference call
       (3, 5); -- Bill for Charlie includes voicemail retrieval
