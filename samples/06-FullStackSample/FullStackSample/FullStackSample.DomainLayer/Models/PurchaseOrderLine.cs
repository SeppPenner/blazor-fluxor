namespace FullStackSample.DomainLayer.Models
{
	public class PurchaseOrderLine
	{
		public int Id { get; private set; }
		public PurchaseOrder Order { get; set; }
		public Product Product { get; set; }
		public uint Quantity { get; set; }
		public decimal Price { get; set; }
		public decimal LineValue => Quantity * Price;
	}
}
