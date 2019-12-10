using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Invoiced
{

	public class PendingLineItem : AbstractEntity<PendingLineItem>
	{

		private long CustomerId;

		public PendingLineItem(Connection conn, long customerId) : base(conn) {
			this.CustomerId = customerId;
		}

		public PendingLineItem() : base(){

		}

		protected override string EntityId() {
			return this.Id.ToString();
		}

		public override string EntityName() {
			return "customers/" + this.CustomerId.ToString() + "/line_items";
		}

		[JsonProperty("id")]
		public long Id { get; set; }

		[JsonProperty("catalog_item")]
		public string CatalogItem { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

        [JsonProperty("description")]
		public string Description { get; set; }

        [JsonProperty("quantity")]
		public long Quantity { get; set; }

        [JsonProperty("amount")]
		public long Amount { get; set; }

        [JsonProperty("unit_cost")]
		public long UnitCost { get; set; }

        [JsonProperty("discountable")]
		public bool Discountable { get; set; }

        [JsonProperty("discounts")]
		public IList<Discount> Discounts { get; set; }

		[JsonProperty("taxable")]
		public bool Taxable { get; set; }

		[JsonProperty("taxes")]
		public IList<Tax> Taxes { get; set; }

		[JsonProperty("plan")]
		public string Plan { get; set; }

		[JsonProperty("metadata")]
		public Metadata Metadata { get; set; }

		// Conditional Serialisation

		public bool ShouldSerializeId() {
			return false;
		}

		public bool ShouldSerializeCatalogItem() {
			return this.CurrentOperation == "Create";
		}

	}

}