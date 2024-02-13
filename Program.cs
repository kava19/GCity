
namespace GCity
{
	internal class Program
	{
		private static void Main(string[] args)
		{

			OSMData osmData = Loader.LoadOSMFromGeoJSON("map/roads.geojson");
			Console.WriteLine("Hello, World!");
		}
	}
}