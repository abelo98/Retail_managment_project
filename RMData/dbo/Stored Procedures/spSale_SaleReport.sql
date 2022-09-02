CREATE PROCEDURE [dbo].[spSale_SaleReport]
	
AS
begin
	set nocount on;

	select [s].[SaleDate], [s].[Subtotal], [s].[Tax], [s].[Total], [u].[Firstname], [u].[LastName], [u].[EmailAddress]
	from dbo.Sale s
	inner join dbo.[User] u on u.Id = s.CashierId;
end
