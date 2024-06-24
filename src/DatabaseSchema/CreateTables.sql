CREATE TABLE Accounts (
    Id INT PRIMARY KEY IDENTITY(1,1),
    CardNumber NVARCHAR(50) NOT NULL,
    Balance DECIMAL(18, 2) NOT NULL
);

CREATE TABLE Transactions (
    Id INT PRIMARY KEY IDENTITY(1,1),
    AccountId INT,
    Amount DECIMAL(18, 2) NOT NULL,
    Description NVARCHAR(255) NOT NULL,
    FOREIGN KEY (AccountId) REFERENCES Accounts(Id)
);
