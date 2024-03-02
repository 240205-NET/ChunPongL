-- On the Chinook DB, practice writing queries with the following exercises
-- List all customers (full name, customer id, and country) who are not in the USA
SELECT FirstName || ' ' || LastName AS FullName, CustomerId, Country
    FROM Customer
    WHERE Country NOT LIKE 'USA'; -- !=

    SELECT CustomerId, FirstName, LastName, Address, City, State From [dbo].[Customer] WHERE Country='Brazil';

SELECT CustomerId, FirstName, LastName, Address, City, State From [dbo].[Customer] WHERE CustomerId = 5;

SELECT * From [dbo].[Customer] WHERE CustomerId = 9999;

SELECT CONCAT(FirstName,  ' ', LastName) AS FullName, CustomerId, Country
        FROM [dbo].[Customer]
        WHERE Country !='USA';

-- List all customers from Brazil
SELECT *
        From [dbo].[Customer]
        WHERE Country='Brazil';

select * from Customer where Country = 'Brazil';

SELECT *
    FROM Customer
    WHERE Country LIKE 'Brazil';


-- List all sales agents
    SELECT *
    FROM Employee
    WHERE Title='Sales Support Agent';


    SELECT *
    FROM [dbo].[Employee] AS e
    WHERE e.Title = 'Sales Support Agent'

    SELECT FirstName || ' ' || LastName AS FullName, EmployeeId, Title, Country
    FROM Employee
    WHERE Title LIKE 'Sales%';

    SELECT *
    FROM Employee
    WHERE TITLE LIKE '%sale%agent%';

-- Retrieve a list of all countries in billing addresses on invoices

-- Retrieve how many invoices there were in 2009, and what was the sales total for that year?
    -- (challenge: find the invoice count sales total for every year using one query)

-- how many line items were there for invoice #37

-- how many invoices per country?

-- Retrieve the total sales per country, ordered by the highest total sales first.



-- JOINS CHALLENGES
-- Show all invoices of customers from brazil (mailing address not billing)
-- Invoice 
-- Customer
-- Country

SELECT *
FROM Invoice JOIN Customer
ON  Invoice.CustomerId = Customer.CustomerId
where Customer.Country = 'Brazil';


-- Show all invoices together with the name of the sales agent for each one

-- Invoice
    -- Customer.Id
-- Customer
    -- Employee.Id
-- Employees

SELECT i.*, CONCAT(e.FirstName, ' ', e.LastName) AS 'Sales Agent'
    FROM [dbo].[Invoice] AS i
    LEFT JOIN [dbo].[Customer] AS c ON i.CustomerId = c.CustomerId
    LEFT JOIN [dbo].[Employee] AS e ON c.SupportRepId = e.EmployeeId;


-- Show all playlists ordered by the total number of tracks they have

-- Which sales agent made the most sales in 2009?

-- How many customers are assigned to each sales agent?

-- Which track was purchased the most ing 20010?

-- Show the top three best selling artists.

-- Which customers have the same initials as at least one other customer?



-- solve these with a mixture of joins, subqueries, CTE, and set operators.
-- solve at least one of them in two different ways, and see if the execution
-- plan for them is the same, or different.

-- 1. which artists did not make any albums at all?

-- 2. which artists did not record any tracks of the Latin genre?

-- 3. which video track has the longest length? (use media type table)

-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)

-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?

-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.


-- DML exercises

-- 1. insert two new records into the employee table.

-- 2. insert two new records into the tracks table.

-- 3. update customer Aaron Mitchell's name to Robert Walter

-- 4. delete one of the employees you inserted.

-- 5. delete customer Robert Walter.