CREATE PROC usp_PlaceOrder(@jobId INT, @partSerialNumber VARCHAR(50), @quantity INT)
AS
	IF(@quantity <= 0)
		THROW 50012, 'Part quantity must be more than zero!', 1;

	DECLARE @jobIdVerified INT = (SELECT TOP (1) JobId 
									FROM Jobs 
									WHERE JobId = @jobId);

	IF(@jobIdVerified IS NULL)
		THROW 50013, 'Job not found!', 1;

	DECLARE @jobStatus VARCHAR(11) = (SELECT TOP (1) [Status] 
										FROM Jobs 
										WHERE JobId = @jobIdVerified);
	
	IF(@jobStatus = 'Finished')
		THROW 50011, 'This job is not active!', 1;

	DECLARE @partIdVerified INT = (SELECT TOP (1) PartId 
									 FROM Parts 
									WHERE SerialNumber = @partSerialNumber);

	IF(@partIdVerified IS NULL)
		THROW 50014, 'Part not found!', 1;

	DECLARE @orderId INT = (SELECT OrderId 
							  FROM Orders
							 WHERE JobId = @jobIdVerified AND IssueDate IS NULL);

	IF(@orderId IS NULL)
	BEGIN
		INSERT INTO Orders (JobId, IssueDate, Delivered) VALUES
			(@jobIdVerified, NULL, 0);

		DECLARE @newOrderId INT = (SELECT OrderId 
									 FROM Orders 
									WHERE JobId = @jobIdVerified AND IssueDate IS NULL);

		INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
			(@newOrderId, @partIdVerified, @quantity);
	END

	ELSE
	BEGIN
		DECLARE @partQuantity INT = (SELECT Quantity 
									   FROM OrderParts 
									  WHERE OrderId = @orderId AND PartId = @partIdVerified);

		IF(@partQuantity IS NULL)
		BEGIN
			INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
				(@orderId, @partIdVerified, @quantity);
		END

		ELSE
		BEGIN
			 UPDATE OrderParts
				SET Quantity += @quantity
			  WHERE OrderId = @orderId AND PartId = @partIdVerified;
		END
	END