using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCity
{
	public partial class Program : Form
	{
		public Program()
		{
			InitializeComponent();

		}
		private static void Main(string[] args)
		{

			Tile tile = Loader.LoadOSMFromGeoJSON("map/roads.geojson");
			Console.WriteLine("Hello, World!");
			Application.Run(new Program());
		}
	}
}



/*namespace GCity
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
}*/