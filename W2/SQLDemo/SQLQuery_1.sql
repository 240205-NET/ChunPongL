
CREATE PROCEDURE dbo.UpdateGenre(@rowsChanged INT OUTPUT)
AS
BEGIN
    BEGIN TRY
        IF(NOT EXISTS(SELECT * FROM dbo.Genre))
        BEGIN
            RAISERROR('No data found',1);
        END
        UPDATE dbo.Genre SET Name = 'Alt Rock' WHERE GenreId = 23;
    END TRY
    BEGIN CATCH
        PRINT 'Error';
    END CATCH
    @rowChanged = 1;
END CATCH
GO

DeClare @rowChanged INT = 0;

Declare @result INT;
EXECUTE dbo.UpdateGenre @result OUTPUT
SELECT @result;

SELECT * FROM dbo.Genre;
GO