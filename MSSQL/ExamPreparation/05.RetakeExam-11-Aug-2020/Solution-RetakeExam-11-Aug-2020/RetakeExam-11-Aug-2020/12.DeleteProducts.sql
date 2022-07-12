CREATE TRIGGER tr_deletingAProduct
ON Products INSTEAD OF DELETE
AS
	DECLARE @productId INT = (SELECT Id
	                            FROM deleted);

    DELETE FROM Feedbacks
	 WHERE ProductId = @productId;

	DELETE FROM ProductsIngredients
	 WHERE ProductId = @productId;

	DELETE FROM Products
	 WHERE Id = @productId;