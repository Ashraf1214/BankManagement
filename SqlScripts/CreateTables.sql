USE FinalCaseStudy13;

DROP TABLE IF EXISTS Transactions;
DROP TABLE IF EXISTS Account;
DROP TABLE IF EXISTS Customer;
DROP TABLE IF EXISTS CustomerStatus;
DROP TABLE IF EXISTS AccountStatus;


CREATE TABLE Customer 
(
  ID INT PRIMARY KEY NOT NULL IDENTITY(100000000, 1),
  SSN INT UNIQUE NOT NULL,
  Name VARCHAR(30) NOT NULL,
  Age INT NOT NULL,
  Address_1 VARCHAR(50) NOT NULL,
  Address_2 VARCHAR(50) NULL,
  City VARCHAR(20) NOT NULL,
  State VARCHAR(2) NOT NULL, 
  Customer_Status VARCHAR(25),
  Status_Last_Updated DATE,
  CONSTRAINT chk_SSN CHECK (SSN >= 100000000 AND SSN < 1000000000),
  CONSTRAINT chk_age CHECK (Age >= 16 AND Age < 100),
);

CREATE TABLE Account
(
  ID INT PRIMARY KEY NOT NULL IDENTITY,
  Customer_ID INT NOT NULL References Customer(ID),
  Account_Type VARCHAR(10) NOT NULL,
  Account_Status VARCHAR(25) NOT NULL,
  Status_Last_Updated DATE,
  Balance INT NOT NULL,
  CONSTRAINT chk_Account_Type CHECK (Account_Type IN ('Checking', 'Savings'))
);

CREATE TABLE Transactions 
(
	ID INT PRIMARY KEY NOT NULL IDENTITY,
	Account_ID INT NOT NULL REFERENCES Account(ID) ON DELETE CASCADE,
	Account_ID_2 INT REFERENCES Account(ID),
	Transaction_Type VARCHAR(10) NOT NULL,
	Amount INT NOT NULL,
	Balance INT NOT Null,
	TranDate Date NOT NULL,
	CONSTRAINT chk_Transaction_Type CHECK (Transaction_Type IN ('Withdrawl', 'Deposit', 'Transfer')),
	CONSTRAINT chk_Transfer CHECK (Transaction_Type NOT IN ('Transfer') OR Account_ID_2 is not null),
);



insert into Customer
values(111111111,'Anabelle',21,'100 North Street','Unit 100','Anapolis', 'MI', 'CUSTOMER CREATED', CAST(GETDATE() AS DATE))

insert into Customer
values(222222222,'Bella',22,'200 East Street','Unit 200','Boston', 'MI', 'CUSTOMER CREATED', CAST(GETDATE() AS DATE))

insert into Customer
values(333333333,'Cole',23,'300 South Street', NULL, 'Denver', 'WA', 'CUSTOMER CREATED', CAST(GETDATE() AS DATE))

insert into Customer
values(444444444,'David',24,'400 West Street', NULL, 'Miami', 'MA', 'CUSTOMER CREATED', CAST(GETDATE() AS DATE))

insert into Customer
values(111111112,'Anabelle',21,'100 North Street','Unit 100','Anapolis', 'MI', 'SOFT DELETE', CAST(GETDATE() AS DATE))

insert into Customer
values(222222223,'Bella',22,'200 East Street','Unit 200','Boston', 'MI', 'CUSTOMER CREATED', CAST(GETDATE() AS DATE))

insert into Customer
values(333333332,'Cole',23,'300 South Street', NULL, 'Denver', 'WA', 'SOFT DELETE', CAST(GETDATE() AS DATE))

insert into Customer
values(444444442,'David',24,'400 West Street', NULL, 'Miami', 'MA', 'CUSTOMER CREATED', CAST(GETDATE() AS DATE))

select * from Customer



insert into Account
values(100000000,'Checking', 'ACCOUNT CREATED', CAST(GETDATE() AS DATE), 0)

insert into Account
values(100000000,'Savings', 'ACCOUNT CREATED', CAST(GETDATE() AS DATE), 0)

insert into Account
values(100000001,'Savings', 'ACCOUNT CREATED', CAST(GETDATE() AS DATE), 0)

insert into Account
values(100000002,'Checking', 'ACCOUNT CREATED', CAST(GETDATE() AS DATE), 0)

insert into Account
values(100000003,'Checking', 'ACCOUNT CREATED', CAST(GETDATE() AS DATE), 0)

insert into Account
values(100000000,'Checking', 'ACCOUNT CREATED', CAST(GETDATE() AS DATE), 0)

insert into Account
values(100000004,'Savings', 'ACCOUNT CREATED', CAST(GETDATE() AS DATE), 0)

insert into Account
values(100000005,'Savings', 'SOFT DELETE', CAST(GETDATE() AS DATE), 0)

insert into Account
values(100000005,'Checking', 'SOFT DELETE', CAST(GETDATE() AS DATE), 0)

insert into Account
values(100000006,'Checking', 'SOFT DELETE', CAST(GETDATE() AS DATE), 0)


select * from Account

insert into Transactions
values(1, null, 'Withdrawl', 1000,1000,CAST(GETDATE() AS DATE))

insert into Transactions
values(1, null, 'Deposit', 1000, 1000,CAST(GETDATE() AS DATE))

insert into Transactions
values(2, null, 'Withdrawl', 1000, 1000,CAST(GETDATE() AS DATE))

insert into Transactions
values(3, 2, 'Transfer', 1000, 1000,CAST(GETDATE() AS DATE))

insert into Transactions
values(1, 4, 'Transfer', 1000, 1000,CAST(GETDATE() AS DATE))

insert into Transactions
values(3, 1, 'Transfer', 1000, 1000,CAST(GETDATE() AS DATE))

SELECT * FROM Transactions;
