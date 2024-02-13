
namespace GCity
{
	public partial class Program : Form 
	{
		private static void Main(string[] args)
		{

			Tile tile = Loader.LoadOSMFromGeoJSON("map/roads.geojson");
			Console.WriteLine("Hello, World!");
			Application.Run(new Program());
		}
	}
}