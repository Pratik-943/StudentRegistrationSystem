# EduEnroll - Student Registration System

A fully-featured, 3-tier architecture ASP.NET Web Forms application for managing student registrations. This application encompasses a robust backend implemented with C# and ADO.NET, alongside a "Light & Elegant" custom-styled frontend.

## 📂 Project Architecture & File Structure

This repository strictly separates concerns into an industry-standard 3-tier application model:

```text
📦 StudentRegistrationSystem
 ┣ 📂 Presentation Layer/          # Frontend & Pages
 ┃ ┣ 📜 Site.Master                # Global layout (Navbar, CSS links, Scripts)
 ┃ ┣ 📜 Home.aspx                  # Landing page
 ┃ ┣ 📜 Login.aspx                 # User authentication
 ┃ ┣ 📜 Signup.aspx                # User registration
 ┃ ┣ 📜 StudentRegistration.aspx   # Core CRUD dashboard to manage students
 ┃ ┗ 📜 Logout.aspx                # Session destruction
 ┣ 📂 Business Access Layer/       # Logic & Validation Routing
 ┃ ┣ 📜 StateService.cs
 ┃ ┣ 📜 StudentService.cs
 ┃ ┗ 📜 UserService.cs
 ┣ 📂 Data Access Layer/           # ADO.NET SQL Integrations
 ┃ ┣ 📜 DbHelper.cs                # ConnectionString provider ("db")
 ┃ ┣ 📜 StateRepository.cs
 ┃ ┣ 📜 StudentRepository.cs
 ┃ ┗ 📜 UserRepository.cs
 ┣ 📂 Entity Layer/                # POCO Classes / Models
 ┃ ┣ 📜 City.cs
 ┃ ┣ 📜 State.cs
 ┃ ┣ 📜 Student.cs
 ┃ ┗ 📜 User.cs
 ┣ 📂 Style/                       # Static Assets
 ┃ ┗ 📜 dashboard.css              # Custom styling for the clean UI
 ┣ 📂 Uploads/                     # Dynamic storage for uploaded Student Photos
 ┗ 📜 Web.config                   # SQL Connection string and app rules
```

## 🗄️ Database & Table Structure

To run the application, you need to set up the following tables in your SQL Server database. Please execute these creation queries. *(Note: Data insertion is left to the user to manage within the Web UI/Database directly)*.

### 1. `Users` Table
Manages system administrators/personnel.
```sql
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL
);
```

### 2. `State` Table
Stores geographical states for dropdown populations.
```sql
CREATE TABLE State (
    StateId INT IDENTITY(1,1) PRIMARY KEY,
    StateName NVARCHAR(100) NOT NULL
);
```

### 3. `City` Table
Stores geographical cities linked to corresponding states.
```sql
CREATE TABLE City (
    CityId INT IDENTITY(1,1) PRIMARY KEY,
    CityName NVARCHAR(100) NOT NULL,
    StateId INT NOT NULL,
    FOREIGN KEY (StateId) REFERENCES State(StateId)
);
```

### 4. `Student` Table
The primary table tracking registered students.
```sql
CREATE TABLE Student (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(150),
    Phone NVARCHAR(15),
    Email NVARCHAR(150),
    Address NVARCHAR(MAX),
    Gender NVARCHAR(10),
    Language NVARCHAR(100),
    StateId INT,
    CityId INT,
    Photo NVARCHAR(500),
    FOREIGN KEY (StateId) REFERENCES State(StateId),
    FOREIGN KEY (CityId) REFERENCES City(CityId)
);
```

---

## ⚙️ ADO.NET SQL Queries (Internal Implementations)

The data access layer utilizes parameterized raw SQL. Here is the operational queries mapping used by our core repositories:

### User Queries (`UserRepository.cs`)
*   **Register User:**
    ```sql
    INSERT INTO Users (Name, Email, Password) VALUES (@Name, @Email, @Password)
    ```
*   **Login User:**
    ```sql
    SELECT * FROM Users WHERE Email=@Email AND Password=@Password
    ```

### State / City Queries (`StateRepository.cs`)
*   **Get States:**
    ```sql
    SELECT * FROM State
    ```
*   **Get Cities by State:**
    ```sql
    SELECT * FROM City WHERE StateId=@StateId
    ```

### Student Queries (`StudentRepository.cs`)
*   **Fetch All Students:**
    ```sql
    SELECT * FROM Student
    ```
*   **Fetch Student by ID:**
    ```sql
    SELECT * FROM Student WHERE StudentId=@Id
    ```
*   **Add Student:**
    ```sql
    INSERT INTO Student VALUES (@Name, @Phone, @Email, @Address, @Gender, @Language, @StateId, @CityId, @Photo)
    ```
*   **Update Student:**
    ```sql
    UPDATE Student SET 
        Name=@Name, 
        Phone=@Phone, 
        Email=@Email, 
        Address=@Address, 
        Gender=@Gender, 
        Language=@Language, 
        StateId=@StateId, 
        CityId=@CityId, 
        Photo=ISNULL(@Photo, Photo) 
    WHERE StudentId=@Id
    ```
*   **Delete Student:**
    ```sql
    DELETE FROM Student WHERE StudentId=@id
    ```

## 🚀 Setup Instructions
1. Setup a SQL Server database.
2. Execute the `CREATE TABLE` scripts above.
3. Update the `connectionString` named `db` inside the `Web.config` file to point to your new database.
4. Launch via IIS or Visual Studio `(F5)` and navigate to `Signup.aspx` to create your first administrative user.
