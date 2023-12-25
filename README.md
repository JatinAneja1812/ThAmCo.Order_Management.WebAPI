# ThAmCo Orders Management WebAPI

Welcome to ThAmCo Orders Management WebAPI! This microservice is a powerful tool for handling comprehensive order management within your application. From order creation and updates to cancellations, order status changes, and delivery schedule adjustments, this API provides a robust solution for managing the entire order lifecycle. The service seamlessly interacts with the underlying database to ensure data integrity and reliability.


## Features in current implementation

- **Order Retrieval From Database:** Quickly fetches data for all orders from the database, ensuring fast and reliable access to order information.
- **Archiving Delivered Orders:** Automatically archives historic orders upon delivery, providing staff users with a visual representation of past orders through the frontend.
- **Order Creation:** Easily create new orders using a straightforward API endpoint, streamlining the order creation process.
- **Order Cancellations:** Implements a soft delete mechanism for orders, allowing for seamless cancellations without permanent removal from the database.
- **Order Status Changes:** Track and manage order status changes in real-time, providing immediate insights into the current state of orders.
- **Delivery Schedule Adjustments:** Allows staff users to modify delivery schedules after the order is created, providing flexibility in managing delivery logistics.


## Upcomming features
 Here are some exciting features that will be included in upcoming releases:
 
### 1. **Enhanced Analytics Dashboard**
   - Gain deeper insights into order trends, customer behavior, and overall performance with a new analytics dashboard.

### 2. **Automated Email Notifications**
   - Planning to implement automated email notifications for order confirmations, status updates, and delivery schedules to improve communication with customers.

### 3. **User Permissions and Roles**
   -  Planning to introduce a robust user management system with granular permissions and roles, allowing for better control over who can perform specific actions within the system.

### 4. **Integration with Payment Gateways**
   -  Planning to enable seamless integration with popular payment gateways, streamlining the payment process and providing a better user experience for customers.


## Getting Started
Follow these steps to set up and run the ThAmCo Orders Management WebAPI on your local machine.

### Prerequisites
Before you can run the ThAmCo Orders Management WebAPI project in Visual Studio 2022, ensure that you have the following prerequisites installed on your development environment:

1. **Visual Studio 2022:** 
   - You can download the latest version of Visual Studio 2022 from the [official Visual Studio website](https://visualstudio.microsoft.com/downloads/).

2. **.NET 6 SDK:**
   - The project is built using .NET 6, and you'll need the .NET 6 SDK. You can download it from [here](https://dotnet.microsoft.com/download/dotnet/6.0).

3. **Database:**
   - To connect to you database locally ensure you have SQL Server 2019 and Microsoft SQL Server Managment Studio installed:
   - Link:[Microsoft SQL Server Managment Studio](https://sqlserverbuilds.blogspot.com/2018/01/sql-server-management-studio-ssms.html) 
   - Link:[SQL Server 2019](https://www.microsoft.com/en-us/evalcenter/download-sql-server-2019)

### Installation

1. Fork the project.
2. Open Visual Studio 2022 Community/Professional/Enterprise Edition in Admin Mode.
3. Clone the project by coping the link from GitHub repository.
4. Make a new branch from master.
5. Right click on ThAmCo.Order_Managment.WebAPI and make it as default startup project ( Click on set as startup project button in the menu).
6. Clean the project. Click build(On top of IDE) -> Clean Solution.
7. Click on ThAmCo.Order_Managment.WebAPI on top navigation bar or either click on "Play" button to run the project.

If there is error connecting to your local database make sure you have installed correct version of SQL Server and SQL Server Managment Studio is connected. 
Also in SQL Server Managment Studio : Database Engine name is : Localhost\\SQLExpress.

## Connected Projects 
- ThAmCo.User_Profiles :       Link:[here](https://github.com/JatinAneja1812/ThAmCo.User_Profiles).
- ThAmCo.Staff_Portal.WebAPI : Link:[here](https://github.com/JatinAneja1812/ThAmCo.Staff_Protal_BFF.WebAPI).
- thamco_staff_frontend :      Link:[here](https://github.com/JatinAneja1812/thamco_staff_frontendapp).
