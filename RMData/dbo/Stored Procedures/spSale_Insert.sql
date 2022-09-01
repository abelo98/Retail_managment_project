CREATE PROCEDURE [dbo].[spSale_Insert]
	@Id int output,
	@CashierId nvarchar (128),
	@SaleDate datetime2,
	@Subtotal money,
	@Tax money,
	@Total money
AS
begin
	set nocount on;

	insert into dbo.Sale(CashierId,SaleDate,Subtotal,Tax,Total)
	values(@CashierId, @SaleDate,@Subtotal,@Tax,@Total);

	select @Id = Scope_Identity()
end
