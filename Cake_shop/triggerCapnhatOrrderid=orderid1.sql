CREATE TRIGGER UpdateColumn2
ON orders_details
AFTER INSERT
AS
BEGIN
    UPDATE orders_details
    SET [Oders_id] = inserted.[Oders_id1]
    FROM orders_details
    INNER JOIN inserted ON orders_details.[id] = inserted.[id]
END
