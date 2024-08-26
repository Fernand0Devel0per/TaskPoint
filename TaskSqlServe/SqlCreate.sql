CREATE TABLE Users (
    UserId UNIQUEIDENTIFIER PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    PasswordHash NVARCHAR(255) NOT NULL,
    CreatedDate DATETIME NOT NULL,
    UpdatedDate DATETIME NOT NULL,
    Role INT NOT NULL,
    FOREIGN KEY (Role) REFERENCES UserRoles(RoleId)
);

CREATE TABLE Projects (
    ProjectId UNIQUEIDENTIFIER PRIMARY KEY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    StartDate DATETIME,
    EndDate DATETIME,
    UpdateDate DATETIME NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Tasks (
    TaskId UNIQUEIDENTIFIER PRIMARY KEY,
    UserId UNIQUEIDENTIFIER NOT NULL,
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(255),
    Status INT NOT NULL,
    Priority INT NOT NULL,
    DueDate DATETIME,
    CreatedDate DATETIME NOT NULL,
    UpdateDate DATETIME NOT NULL,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

CREATE TABLE Tags (
    TagId UNIQUEIDENTIFIER PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL,
    Color NVARCHAR(7)
);

CREATE TABLE TaskTags (
    TaskId UNIQUEIDENTIFIER NOT NULL,
    TagId UNIQUEIDENTIFIER NOT NULL,
    PRIMARY KEY (TaskId, TagId),
    FOREIGN KEY (TaskId) REFERENCES Tasks(TaskId),
    FOREIGN KEY (TagId) REFERENCES Tags(TagId)
);

CREATE TABLE Comments (
    CommentId UNIQUEIDENTIFIER PRIMARY KEY,
    TaskId UNIQUEIDENTIFIER NOT NULL,
    UserId UNIQUEIDENTIFIER NOT NULL,
    Content NVARCHAR(255) NOT NULL,
    CreatedDate DATETIME NOT NULL,
    UpdateDate DATETIME NOT NULL,
    FOREIGN KEY (TaskId) REFERENCES Tasks(TaskId),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- Enumerations
CREATE TABLE TaskStatus (
    StatusId INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

CREATE TABLE TaskPriority (
    PriorityId INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

CREATE TABLE UserRoles (
    RoleId INT PRIMARY KEY,
    Name NVARCHAR(50) NOT NULL
);

-- Insert enumeration values
INSERT INTO TaskStatus (StatusId, Name) VALUES (0, 'Pending'), (1, 'InProgress'), (2, 'Completed');
INSERT INTO TaskPriority (PriorityId, Name) VALUES (0, 'Low'), (1, 'Medium'), (2, 'High');
INSERT INTO UserRoles (RoleId, Name) VALUES (0, 'Admin'), (1, 'UserDefault'), (2, 'Guest');