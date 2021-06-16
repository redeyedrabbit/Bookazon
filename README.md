# Bookazon App
> An API that allows a bookstore to manage its product listing database, and allows a bookstore customer to view the inventory based on Title, Author, or Publisher information.

## Table of Contents
* [Database](#database)
* [Features](#features)
* [Endpoints](#endpoints)
* [User Stories](#user-stories)
* [Tasks and Tickets](#tasks-and-tickets)
* [Acceptance Criteria and Tests](#acceptance-criteria-and-tests)
* [Sprint Planning](#sprint-planning)
* [Assigned Tasks](#assigned-tasks)
* [Stretch Goals](#stretch-goals)
* [Schedule](#schedule)
* [Created By](#created-by)
* [Screenshots](#screenshots)
* [Links](#links)


## Database
![DB Diagram](https://github.com/redeyedrabbit/Bookazon/blob/develop/img/DBdatabase.PNG)

**Table 1: Product**

	ProductId - int (Primary Key)

	ManagerId - guid

	Title - string

	Description - string

	StarRating - double

	FormatType - enum

	Genre - enum

	Audience - enum

	Author - string (Many-to-Many with Author, using Authorship as a joining table)

	PublisherId - int (ForeignKey)

	PublishYear - int

	Price - decimal

	Condition - enum
	
Group member assigned to this table: **Ben**

**Table 2: Authorship** (Joining table, for the Product and Author tables)

	Id - int (Primary Key)

	ProductId - int (Foreign Key)

	AuthorId - int (Foreign Key)

Group member assigned to this table: **Ben**

**Table 3: Author**

	AuthorId - int (Primary Key)

	FirstName - string

	LastName - string

Group member assigned to this table: **Tad**

**Table 4: Publisher**

	PublisherID - int ((Primary Key)

	Name - string

Group member assigned to this table: **Rachel**

**Table 5: User**

	Id - (Primary Key)

	UserName - string

	IsAdmin - bool

Group member assigned to this table: **Tad**


## Features
Version  1.0 / MVP | Version 2.0 / Stretch Goals
-------------------| -------------------------
Add New Product | Product Star Rating
Update Product | User Favorite List
Get Product by Title | Shopping Cart
Delete Existing Product | Checkout
Get All Products | Featured Best Sellers
Get All Products by Author | Stock Availability
Get All Products by Publisher | Audience
Get All Products by ID | Book Price Range
User Registration | Inventory Control
Add New Publisher | Purchase Ability
Add New Author | Interface
Update Publisher |
Update Author |
Delete Publisher |
Delete Author |
Get All Publishers |
Get All Authors |

## Endpoints

Product - Post a new Product, Get all Product, Get Product by Id, Get Product by Genre, Get Product by Star Rating, Get Product by Audience, Get Product by Price Range, Get Product by Star Rating Range, Get Poduct by Author, Get Product by Publisher, Put existing Product, Delete existing Product

Author - Post new Author, GET Author by Id, GET all Authors, PUT existing Author, Delete existing Author

Publisher - Post new Publisher, Get Publisher by Id, Get All Publishers, Put existing Publisher, Delete existing Publisher

Authorship - Get Product(s) by Author, Get Author(s) by Product, Post, Delete


## User Stories
1. As a store manager, I want to Create/Post products to the database so that users can easily find them.

2. As a store manager, I want to Update/Put changes to existing products in the database so that I can easily update products (i.e. newer versions of books available).

3. As a store manager, I want to Delete a product from the database when it is no longer available.

4. As a customer, I want to see the intended audience of a given product, so that I can ensure a product is for either my children or myself.

5. As a customer, I want to Read/Get products by title for more information such as format, publish date, condition, genre, stock availability, price, rating, etc.

6. As a customer, I want to Create/Post a star rating on a product so that I can share with others how I feel about a given product title. 

7. As a customer, I want to see the star ratings of a given product when I search for a product title, so that I can choose a product based on average ratings.

8. As a customer, I want to Read/Get products by price range so that I can see products that I am willing to purchase for X amount.

9. As a customer, I want to Read/Get products by range of star ratings, so that I can easily choose a product that meets my standards.

10. As a store manager, I want to Create/Post genres to the database as needed to accommodate products.


## Tasks and Tickets
1. Create the GitHub Repository - **Points: 1**
2. Create the initial API scaffolding - **Points: 1**
3. Create User Identities - Data Layer - **Points: 1**
4. Create Product Class (id, Title, Description, FormatType, Author, Publisher, PublishDate, Price, Condition, Genre) - Data Layer - **Points: 0.5**
5. Create Author Class (AuthorId, FirstName, LastName) - Data Layer - **Points: 0.5**
6. Create Publisher Class (PublisherId, Name) - Data Layer - **Points: 0.5**
7. Create Product Services - Service Layer - **Points: 2**
8. Create Author Services - Service Layer - **Points: 2**
9. Create Publisher Services - Service Layer - **Points: 2**
10. Create Product Controller - Controller Layer - **Points: 3**
11. Create Author Controller - Controller Layer - **Points: 3**
12. Create Publisher Controller - Controller Layer - **Points: 3**
13. Create Entity Models for Product - **Points: 2**
14. Create Entity Models for Author - **Points: 2**
15. Create Entity Models for Publisher - **Points: 2**
16. Create Authorship Model - Data Layer - **Points: 1**
17. Create Authorship Services - Service Layer - **Points: 5**
18. Create Authorship Controller - Controller Layer - **Points: 5**
19. Create Authorship entity models - **Points: 2**
20. Create the ReadME - **Points: 2**


## Acceptance Criteria and Tests

User Story | Acceptance Criteria/Tests
-----------| -------------------------
**User story 1** | Post product without all of the required fields - Get 400 Error
**User story 1** | Post product successfully - Get 200 Ok “Product Added Successfully”
**User story 2** | Update/Put product without required fields - Get 400 Error
**User story 2** | Update/Put product that does not exist - Get 404 Error
**User story 2** | Update/Put product successfully - Get 200 Ok “Product Updated Successfully”
**User story 3** | Delete product that does not exist - Get 404 Error
**User story 3** | Delete product successfully - Get 200 Ok “Product Deleted Successfully”
**User story 5** | Read/Get product that does not exist - Get 404 Error
**User story 5** | Read/Get product by Title successfully - Get 200 Ok
**User story 6** | Post Star Rating on product that does not exist - Get 404 Error
**User story 6** | Post Star Rating on product - Get 200 Ok
**User story 7** | Get/Read Star Rating on product that does not exist - Get 404 Error
**User story 7** | Get/Read Star Rating on product - Get 200 Ok


## Sprint Planning
### Assigned Tasks:
**Rachel:** 1, 2, 3, 6, 9, 12, 15

**Tad:** 5, 7, 8, 10, 11,  14 

**Ben:** 4, 7, 10, 13, 16, 17, 18, 19

**Backlog / Stretch Goals:** 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41

**Backlog / Stretch Goals Completed:**

**Rachel:** 22, 23, 24, 25, 26, 29, 30

**Tad:** 20, 31, 32

**Ben:** 21, 27, 28

### Stretch Goals:
* User Favorite/Wishlist

* Featured Best Sellers

* Product Star Rating

* Shopping Cart

* Checkout

* Book Price Range (under $5, $5-$10, $10-$20, $20+)

* Audience - Adult, Teen, Child

* Inventory Control

* Purchase Availability

* Interface

* Author Profile (About)

* Book Price Range

* Create Post with automatic authorship if author exists already

* Get Product by Author

* Get Product by Publisher

* Get all Products by Publisher

* Get product by Audience

* Get Product by Genre

* Get product by Star Rating

* Star Rating Range (1-3, 3-4, 3+, 3-5)

* Add Sku

* Console App/Program

* Clone Repo

* Flowchart 

* API Documentation 

## Schedule
### Goal Schedule
Day 1 | Day 2 | Day 3 | Day 4 | Day 5 | Day 6 | Day 7
-----------| -----------|-----------|-----------|-----------|-----------|-----------|
Planning Documenation | Establish GitHub Repository, Initial API Scaffolding, and Branches. Assign Tables and Workload. | Product, Author, Authorship, Publisher Services Complete | Product, Author, Authorship, Publisher Controllers Complete | Testing/Debug | Work independantly | Work Independantly 
**Day 8** | **Day 9** | **Day 10** | **Day 11** |  |  | 
Testing | ReadME Complete, PostMan Testing Complete. | Stretch Goals | Due |  |  | 

### Actual Schedule
Day 1 | Day 2 | Day 3 | Day 4 | Day 5 | Day 6 | Day 7
-----------| -----------|-----------|-----------|-----------|-----------|-----------|
Planning Documentation Completed, GitHub Repository Created, Initial API scaffolding, and Branches Created | Product, Author, Publisher Classes and Models completed. Author Services completed. | Product, Author, Publisher Services and Controllers completed. Authorship class, model, service, and controller completed. | Postman testing and troubleshooting code. | Cont. Testing and troubleshooting, taking on backlog/stretch goals | Work independantly | Work Independantly 
**Day 8** | **Day 9** | **Day 10** | **Day 11** |  |  | 
Completed stretch goals: Price range, star rating, audience. Some testing and troubleshooting. Started documentation. | Postman Testing, ReadME, Flowchart, Documentation completed, clone testing. Backlog/stretch goals completed: Error handling added to code, Star Rating range added, Create post with automatic authorship if author exists already, Get product by genre, Get product by star rating, Get product by Audience. Console App started | Stretch Goals | Due |  |  | 

## Screenshots
![DB Diagram](https://github.com/redeyedrabbit/Bookazon/blob/develop/img/DBdatabase.PNG)

![PlanITPoker](https://github.com/redeyedrabbit/Bookazon/blob/develop/img/PlanITpoker.png)

![Trello](https://github.com/redeyedrabbit/Bookazon/blob/develop/img/Trello.PNG)


## Comments
Our team utilized [Google Docs](https://docs.google.com/document/d/1y99a8TTk6gH-SR1y_qPijcA5GCSFTuY-hy5GBpv6Cn8), [DB Diagram](https://dbdiagram.io/d/60ca12060c1ff875fcd52069), Zoom, Slack, [PlanITPoker](https://www.planitpoker.com/board/#/room/96840c6892c64465bf72ea7657f8f97f), and [Trello Board](https://trello.com/b/4pg7GnEn/api-project) to collaborate and complete this assignment. 

## Created By
- Ben Ellis

- Tad Luedeke

- Rachel Bellwood


## Links
[DB Diagram](https://dbdiagram.io/d/60ca12060c1ff875fcd52069)

[PlanITPoker](https://www.planitpoker.com/board/#/room/96840c6892c64465bf72ea7657f8f97f)

[Trello Board](https://trello.com/b/4pg7GnEn/api-project)

[Google Docs](https://docs.google.com/document/d/1y99a8TTk6gH-SR1y_qPijcA5GCSFTuY-hy5GBpv6Cn8)
