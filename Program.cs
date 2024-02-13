
namespace GCity
{
	internal class Program
	{
		private static void Main(string[] args)
		{

			Road r = new Road();
			Loader.LoadFromGeoJSON("map/roads.geojson");
			Console.WriteLine("Hello, World!");
		}
	}
}