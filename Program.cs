
namespace GCity
{
	public partial class Program : Form 
	{
		private static void Main(string[] args)
		{

			OSMData osmData = Loader.LoadOSMFromGeoJSON("map/roads.geojson");
			Console.WriteLine("Hello, World!");
			Application.Run(new Program());
		}
	}
}