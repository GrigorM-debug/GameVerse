# GameVerse 🎮

GameVerse is a robust web platform that provides an all-in-one solution for gaming enthusiasts. Users can explore and purchase games, participate in gaming-themed events, and enjoy a tailored experience based on their preferences. The platform supports multiple roles (User, Moderator, Admin), each with unique permissions and tools to ensure a smooth experience for both users and administrators.

---

## Features 📋

### **User Functionalities** 👤

GameVerse offers an engaging user experience with the following capabilities:

#### Games 🎮
- **Explore Games**:
  - Browse a wide variety of games available for purchase.
  - View detailed information about each game, including descriptions, pricing, and availability.

- **Purchase Games**:
  - Buy games with a simple checkout process.
  - Don't worry we don't have payment methods and I will not take you money

- **Review System**:
  - Submit reviews for games.
  - Rate games on a scale of 1 to 5 and provide written feedback visible to other users.

- **Purchase History**:
  - Access a personalized "Bought Games" page.
  - View details of previously purchased games, including purchase dates and game information.

#### Events 🎟️
- **Explore Events**:
  - Discover gaming-themed events with details such as dates, descriptions, pricing, location.

- **Purchase Tickets**:
  - Buy tickets for events through a secure and efficient process.
  - After buying ticket user receive unique Qr Code

- **Event Registration History**:
  - Access a personalized "Events Registrations" page.
  - View purchased event tickets, including event details, registration dates, and the generated QR code for your ticket.

- **Event Details**:
  - See comprehensive event information, including:
    - **Location:** View the event location displayed on an interactive map.
    - **Navigation Tools:** Calculate the route and distance between your current location and the event venue using integrated mapping features.

---

### **Moderator Functionalities** 🔧

Moderators are entrusted with managing site content while maintaining restrictions on ownership and responsibilities:

#### Game Management 🎮
- **Create Games**:
  - Add new games to the platform by entering key details such as title, description, price, and initial stock quantity.

- **Edit and Delete Games**:
  - Modify or remove games they have created.

- **Restock Games**:
  - Add stock to out-of-stock games they own, ensuring uninterrupted availability.


#### Event Management 🎟️
- **Create Events**:
  - Add gaming-related events to the platform, specifying details such as title, description, date, time, location, and ticket price.

- **Edit and Delete Events**:
  - Modify or remove events they have created.

#### Dashboard Access 📊
- **Moderator Dashboard**:
  - Access a dedicated dashboard for managing their games and events efficiently.

---

### **Admin Functionalities** 🛠️

Admins have complete control over the platform and can perform the following tasks:

#### Full Control 🔒
- **Manage All Content**:
  - Edit or delete any game or event, regardless of ownership.

- **Assign User Roles**:
  - Assign and manage roles for all users, including promoting or demoting users to Moderator or Admin roles.

#### Logs and Analytics 📁
- **Download Log Files**:
  - Access detailed log files to monitor recent site activities, ensuring transparency and accountability.


#### QR Code Validation 📷
- **Ticket Validation**:
  - This logic is designed to simulate how QR code validation could be implemented in a real-world application. Currently, the system uses the laptop's camera for scanning. However, the logic can be adapted to utilize the back camera of a smartphone or even a dedicated scanner for enhanced functionality and practical use in live scenarios.
  - Navigate to the QR code scanner page.
  - Use the front camera  to scan QR codes on event tickets.
  - Upon successful validation:
    - View detailed information about the user, event, purchase details.
  - For invalid tickets:
    - Display an error message indicating "Ticket is invalid."

#### Dashboard Access 📊
- **Admin Dashboard**:
  - Access a powerful dashboard to oversee the entire platform's operations and metrics.

---

## Technology Stack 🛠️
GameVerse is built using modern technologies to deliver a scalable, secure, and user-friendly experience.

| **Technology**             | **Purpose**                                                                 |
|-----------------------------|-----------------------------------------------------------------------------|
| **C#**                     | Primary programming language                                                |
| **.NET 8.0**               | Backend framework for web application logic                                |
| **JavaScript**             | Enabling interactivity on the frontend                                     |
| **AJAX**                   | Allows asynchronous web page updates by exchanging data with the server without reloading the page |
| **HTML & CSS**             | Structuring and styling web pages                                          |
| **Bootstrap**              | Responsive and visually appealing design                                   |
| **ASP.NET Core MVC**       | MVC framework for creating a structured web application                    |
| **Entity Framework Core**  | Database ORM for managing data and queries                                 |
| **MS SQL Server**          | Relational database for storing and retrieving data                        |
| **Serilog**                | Logging framework for tracking application behavior                        |
| **Notyf**                  | Displaying user-friendly toaster notifications                            |
| **Leaflet**                | Integrating interactive maps for event location display                    |
| **HTML5-QRCode**           | Scanning QR codes                                           |
| **SendGrid**               | Email delivery service for transactional emails                            |
| **Rapid API NSFW Images**  | Moderation tool for detecting inappropriate content in uploaded images     |
| **QRCode**                 | Generating unique QR codes for event tickets                              |

---

## Installation ⚙️

To run the GameVerse project locally, follow these steps:

### 1️⃣ Clone the repository:
```bash
git https://github.com/GrigorM-debug/GameVerse.git
```

### 3️⃣ Set up the database:
- Ensure **SQL Server** is installed and running.
- Update the connection string in the `appsettings.json` file with your SQL Server credentials.

### 4️⃣ Run the project:
Use **Visual Studio** or the **.NET CLI** to build and run the project:
```bash
dotnet run
```
---

## 📜 License

This project is licensed under the **MIT License**. See the [LICENSE](./LICENSE) file for details.