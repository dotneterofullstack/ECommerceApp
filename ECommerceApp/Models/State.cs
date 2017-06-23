using System;
using System.Collections.Generic;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace ECommerceApp.Models
{
    public class State
    {
		[PrimaryKey]
		public int StateId { get; set; }

		public string Description { get; set; }

		[OneToMany(CascadeOperations = CascadeOperation.All)]
		public List<Order> Orders { get; set; }

		public override int GetHashCode()
		{
			return StateId;
		}

	}
}
