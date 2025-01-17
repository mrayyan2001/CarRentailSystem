-- Create the database
CREATE DATABASE CarRentalSystem;


GO
    -- Use the database
    USE CarRentalSystem;


GO
    -- Create the Users table
    CREATE TABLE Users (
        UserId INT IDENTITY(1, 1) PRIMARY KEY,
        Username NVARCHAR(50) NOT NULL UNIQUE,
        PasswordHash NVARCHAR(255) NOT NULL,
        Email NVARCHAR(100) NOT NULL UNIQUE,
        Role NVARCHAR(20) NOT NULL CHECK (Role IN ('Admin', 'User')),
        CreatedAt DATETIME DEFAULT GETDATE()
    );


-- Create the Cars table
CREATE TABLE Cars (
    CarId INT IDENTITY(1, 1) PRIMARY KEY,
    Model NVARCHAR(100) NOT NULL,
    Brand NVARCHAR(50) NOT NULL,
    Year INT NOT NULL,
    PricePerDay DECIMAL(10, 2) NOT NULL,
    IsAvailable BIT DEFAULT 1
);


-- Create the Rentals table
CREATE TABLE Rentals (
    RentalId INT IDENTITY(1, 1) PRIMARY KEY,
    UserId INT NOT NULL,
    CarId INT NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    TotalCost DECIMAL(10, 2) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (UserId) REFERENCES Users(UserId),
    FOREIGN KEY (CarId) REFERENCES Cars(CarId)
);


-- Sample data for testing (optional)
INSERT INTO
    Users (Username, PasswordHash, Email, Role)
VALUES
    (
        'admin',
        'hashed_password_for_admin',
        'admin@example.com',
        'Admin'
    ),
    (
        'user1',
        'hashed_password_for_user1',
        'user1@example.com',
        'User'
    );


INSERT INTO
    Cars (Model, Brand, Year, PricePerDay)
VALUES
    ('Model S', 'Tesla', 2023, 100.00),
    ('Civic', 'Honda', 2022, 50.00),
    ('Corolla', 'Toyota', 2021, 60.00);