using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbBasic
{

	internal class Program
	{

		static void Main(string[] args)
		{
			MongoDbCrud<Package> packageDb = new MongoDbCrud<Package>("PackagesDb");
			var package1 = new Package()
			{
				ReceivedDate = DateTime.Now,
				Size = "XS",
				Weight = 1
			};
			var package2 = new Package()
			{
				ReceivedDate = DateTime.Now,
				Size = "S",
				Weight = 10
			};
			var package3 = new Package()
			{
				ReceivedDate = DateTime.Now,
				Size = "L",
				Weight = 100
			};

			packageDb.Insert(package1);
			packageDb.Insert(package2);
			packageDb.Insert(package3);

			var packages = packageDb.ListRecords();

			foreach (var package in packages)
			{
				Console.WriteLine($"Id: {package.Id}, Received Date: {package.ReceivedDate}");
			}

			var deletePackage = packages.First(p => p.Size == "S");

			packageDb.Delete(deletePackage.Id);

		}

	}
}
