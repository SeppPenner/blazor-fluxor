using System.Collections.Generic;

namespace FullStackSample.DomainLayer.Entities
{
	public class PurchaseOrder
	{
		public int Id { get; private set; }
		public Client Client { get; set; }
		public IEnumerable<PurchaseOrderLine> Lines { get; set; }
	}
}
