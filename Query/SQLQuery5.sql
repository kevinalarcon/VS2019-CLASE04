CREATE PROCEDURE usp_UpdateArtist
@pName NVARCHAR(120),
@pId INT
AS

BEGIN
	IF (NOT EXISTS(SELECT ArtistId FROM Artist WHERE Name = @pName))
	BEGIN
		UPDATE	Artist
		SET		Name = @pName
		WHERE	ArtistId = @pId;
	END
END
GO

CREATE PROCEDURE usp_DeleteArtist
@pName NVARCHAR(120),
@pId INT
AS

BEGIN
	IF (NOT EXISTS(SELECT ArtistId FROM Artist WHERE Name = @pName))
	BEGIN
		UPDATE	Artist
		SET		Name = @pName
		WHERE	ArtistId = @pId;
	END
END
GO

CREATE PROCEDURE usp_InsertGenre
@pName NVARCHAR(120)
AS

BEGIN
	IF (NOT EXISTS(SELECT GenreId FROM Genre WHERE Name = @pName))
	BEGIN
		INSERT INTO Genre(Name)
		VALUES (@pName);
	END
	ELSE
	BEGIN
		SELECT 0;
	END
	SELECT SCOPE_IDENTITY();	
END
GO

CREATE PROCEDURE usp_UpdateGenre
@pName NVARCHAR(120),
@pId INT
AS

BEGIN
	IF (NOT EXISTS(SELECT GenreId FROM Genre WHERE Name = @pName))
	BEGIN
		UPDATE	Genre
		SET		Name = @pName
		WHERE	GenreId = @pId;
	END
END
GO

CREATE PROCEDURE usp_InsertAlbum
@pTitle NVARCHAR(320),
@pArtistId INT
AS

BEGIN
	IF (NOT EXISTS(SELECT AlbumId FROM Album WHERE Title = @pTitle AND ArtistId = @pArtistId))
	BEGIN
		INSERT INTO Album(Title, ArtistId)
		VALUES (@pTitle,@pArtistId);
	END
	ELSE
	BEGIN
		SELECT 0;
	END
	SELECT SCOPE_IDENTITY();	
END
GO

CREATE PROCEDURE usp_InsertInvoice
(
@CustomerId INT, 
@InvoiceDate DATETIME, 
@BillingAddress NVARCHAR(70), 
@BillingCity NVARCHAR(40), 
@BillingState NVARCHAR(40), 
@BillingCountry NVARCHAR(40), 
@BillingPostalCode NVARCHAR(10), 
@Total NUMERIC(10,2)
)
AS
BEGIN
	INSERT	INTO Invoice(
		CustomerId, InvoiceDate, BillingAddress, 
		BillingCity, BillingState, BillingCountry, 
		BillingPostalCode, Total)
	VALUES	(
		@CustomerId, @InvoiceDate, @BillingAddress, 
		@BillingCity, @BillingState, @BillingCountry, 
		@BillingPostalCode, @Total);

	SELECT SCOPE_IDENTITY();
END
GO

CREATE PROCEDURE usp_InsertInvoiceLine
( 
@InvoiceId INT, 
@TrackId INT, 
@UnitPrice NUMERIC(10,2), 
@Quantity INT
)
AS
BEGIN
	INSERT	INTO InvoiceLine
	(
		InvoiceId, TrackId, 
		UnitPrice, Quantity
	)
	VALUES(
		@InvoiceId, @TrackId, 
		@UnitPrice, @Quantity
	)

END
GO