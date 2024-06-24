INSERT INTO Accounts (CardNumber, Balance) VALUES
('1234567890123456', 1000.00),
('9876543210987654', 2000.00);

INSERT INTO Transactions (AccountId, Amount, Description) VALUES
(1, -100.00, 'Purchase at Store A'),
(2, -50.00, 'Purchase at Store B');
