using System;
using NUnit.Framework;

//using NUnit.Framework.SyntaxHelpers;

namespace EsriDE.Commons.Ags.Tests
{
	// ReSharper disable InconsistentNaming

	[TestFixture]
	public class ServiceDirectoryUtilFixture
	{
		private const string _testAgsRootFolder = @"http://server.arcgisonline.com/ArcGIS/rest/services";
		private const string _testAgsDemographicsFolder = @"http://server.arcgisonline.com/ArcGIS/rest/services/Demographics";

		private const string _testAgs2RootFolder = @"http://vsdp1001.srvc.esri-de.com/ArcGIS/rest/services/";
		private const string _testAgs2MosaikeFolder = @"http://vsdp1001.srvc.esri-de.com/ArcGIS/rest/services/Mosaike";


		[Test]
		public void GetMapServices_Works()
		{
			var uri = new Uri(_testAgsRootFolder);
			var services = AgsUtil.GetMapServices(uri);

			var count = 0;
			foreach (var service in services)
			{
				count++;
			}

			Assert.That(count, Is.GreaterThan(0), "Keine Mapservice (f�r root) gefunden.");

			Console.WriteLine("Gefundene Mapservices (f�r root): " + count);
			Assert.That(count, Is.EqualTo(13), "Anzahl der Mapservices (f�r root) unpassend.");
		}

		[Test]
		public void GetImageServices_Works()
		{
			var uri = new Uri(_testAgs2MosaikeFolder);
			var services = AgsUtil.GetImageServices(uri);

			var count = 0;
			foreach (var service in services)
			{
				count++;
			}

			Assert.That(count, Is.GreaterThan(0), "Keine Imageservice (f�r root) gefunden.");

			Console.WriteLine("Gefundene Imageservices (f�r root): " + count);
			Assert.That(count, Is.EqualTo(9), "Anzahl der Imageservices (f�r root) unpassend.");
		}

		[Test]
		public void GetServices_FromRoot_ReturnsSomeServices()
		{
			var uri = new Uri(_testAgsRootFolder);
			var services = AgsUtil.GetServices(uri);

			var count = 0;
			foreach (var service in services)
			{
				count++;
			}

			Assert.That(count, Is.GreaterThan(0), "Keine Services (f�r root) gefunden.");

			Console.WriteLine("Gefundene Services (f�r root): " + count);
			Assert.That(count, Is.EqualTo(20), "Anzahl der Services (f�r root) unpassend.");
		}

		[Test]
		public void GetFolders_FromRoot_ReturnsSomeFolders()
		{
			var uri = new Uri(_testAgsRootFolder);
			var folders = AgsUtil.GetFolderUris(uri);

			var count = 0;
			foreach (var folder in folders)
			{
				count++;
			}
			Assert.That(count, Is.GreaterThan(0), "Keine Folder (f�r root) gefunden.");

			Console.WriteLine("Gefundene Folder (f�r root): " + count);
			Assert.That(count, Is.EqualTo(4), "Anzahl der Folder (f�r root) unpassend.");
		}

		[Test]
		public void GetServices_FromDemographics_ReturnsSomeServices()
		{
			var uri = new Uri(_testAgsDemographicsFolder);
			var services = AgsUtil.GetServices(uri);

			var count = 0;
			foreach (var service in services)
			{
				count++;
			}

			Assert.That(count, Is.GreaterThan(0), "Keine Services (f�r root) gefunden.");

			Console.WriteLine("Gefundene Services (f�r root): " + count);
			Assert.That(count, Is.EqualTo(21), "Anzahl der Services (f�r root) unpassend.");
		}

		[Test]
		public void GetFolders_FromDemographics_ReturnsNoFolder()
		{
			var uri = new Uri(_testAgsDemographicsFolder);
			var folders = AgsUtil.GetFolderUris(uri);

			var count = 0;
			foreach (var folder in folders)
			{
				count++;
			}

			Console.WriteLine("Gefundene Folder (f�r Demographics): " + count);
			Assert.That(count, Is.EqualTo(0), "Anzahl der Folder (f�r Demographics) unpassend.");
		}
	}

	// ReSharper restore InconsistentNaming
}
