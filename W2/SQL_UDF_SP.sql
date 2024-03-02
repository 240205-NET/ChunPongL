-- User Defined Function - a method/function that is stored on the db server that we can reference and run later on.
DROP FUNCTION dbo.GetAllCustomers;
GO


CREATE FUNCTION dbo.GetAllCustomers( @length INT )
RETURNS TABLE
AS
   RETURN(
    SELECT *
        FROM [dbo].[Customer]
        WHERE LEN(FirstName) = @length
   );
GO

-- this UDF will return a scalar value, it is a Scalar Function.
CREATE FUNCTION dbo.GetCountOfEmployees()
RETURNS INT
AS
BEGIN
    DECLARE @result INT;

    SELECT @result = COUNT(*) FROM dbo.Employee;

    RETURN @result
END
GO    


-- UDF are read-only, we need a stored procedure to handle modifying the database in any way.
CREATE PROCEDURE dbo.UpdateGenre(@rowsChanged INT OUTPUT)
AS
BEGIN
    BEGIN TRY
        IF(NOT EXISTS (SELECT * FROM dbo.Genre))
        BEGIN
            RAISERROR('No data found', 15, 1);
        END
        UPDATE dbo.Genre SET Name = 'Alt Rock' WHERE GenreId = 23;
    END TRY
    BEGIN CATCH
        PRINT 'Error';
    END CATCH
    SELECT @rowsChanged = 1;
END
GO

DECLARE @result INT;
EXECUTE dbo.UpdateGenre @result OUTPUT;
SELECT @result;
GO


SELECT * FROM dbo.Genre;
GO





SELECT dbo.GetCountOfEmployees();

SELECT CustomerId, FirstName, LastName
    FROM dbo.GetAllCustomers(6);
GO