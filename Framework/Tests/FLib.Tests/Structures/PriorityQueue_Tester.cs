using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FLib.Structures;

namespace FLib.Tests.Structures
{
	[TestClass]
	public class PriorityQueue_Tester
	{
		[TestMethod]
		public void TestEnqueue()
		{
			var queue = new PriorityQueue<PQItem>();

			queue.Enqueue(new PQItem("Sally", 1));
			queue.Enqueue(new PQItem("Roger", 2));
			queue.Enqueue(new PQItem("Bill", 2));
			queue.Enqueue(new PQItem("Nancy", 3));
			queue.Enqueue(new PQItem("Gertrude", 1));
			queue.Enqueue(new PQItem("George", 3));
			queue.Enqueue(new PQItem("Adam", 4));
		}

		[TestMethod]
		public void TestDequeue()
		{
			var queue = new PriorityQueue<PQItem>();

			queue.Enqueue(new PQItem("Sally", 1));
			queue.Enqueue(new PQItem("Roger", 2));
			queue.Enqueue(new PQItem("Bill", 2));
			queue.Enqueue(new PQItem("Nancy", 3));
			queue.Enqueue(new PQItem("Gertrude", 1));
			queue.Enqueue(new PQItem("George", 3));
			queue.Enqueue(new PQItem("Adam", 4));

			PQItem item = null;

			item = queue.Dequeue();
			Assert.IsTrue(item.Name == "Sally");

			item = queue.Dequeue();
			Assert.IsTrue(item.Name == "Gertrude");

			item = queue.Dequeue();
			Assert.IsTrue(item.Name == "Roger");

			item = queue.Dequeue();
			Assert.IsTrue(item.Name == "Bill");

			item = queue.Dequeue();
			Assert.IsTrue(item.Name == "Nancy");

			item = queue.Dequeue();
			Assert.IsTrue(item.Name == "George");

			item = queue.Dequeue();
			Assert.IsTrue(item.Name == "Adam");

			Assert.IsTrue(queue.Count == 0);
		}
	}
}
