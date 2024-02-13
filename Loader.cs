using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace GCity
{
	public static class Loader
	{
		private static List<Road> LoadRoads(JsonNode jn)
		{
			var roads = new List<Road>();

			var features = jn["features"];
			if (features == null)
			{
				Console.WriteLine("Cannot load 'features'");
				return roads;
			}

			foreach (var f in features.AsArray())
			{
				var road = new Road();	
				if (f == null)
				{
					Console.WriteLine("Feature is empty");
					break;
				}
				var geo = f["geometry"];
				if (geo == null)
				{
					Console.WriteLine("Geometry is empty");
					break;
				}
				var coords = geo["coordinates"];
				if (coords == null)
				{
					Console.WriteLine("Coordinates is empty");
					break;
				}
				foreach (var coord in coords.AsArray())
				{
					if (coord != null)
					{
						float x = 0;
						float y = 0;
						try
						{
							x = float.Parse(coord[0].ToString(), CultureInfo.InvariantCulture.NumberFormat);
							y = float.Parse(coord[1].ToString(), CultureInfo.InvariantCulture.NumberFormat);
						}
						catch (Exception e)
						{
							Console.WriteLine(e.Message);
						}
						//Console.WriteLine($"{x}, {y}");
						road.GeoLocationPoints.Add(new Point(x, y));
					}
				}
				roads.Add(road);
			}


			return roads;
		}
		public static Tile LoadOSMFromGeoJSON(string path)
		{
			Tile tile = new Tile();
			string fileData = "";
			try
			{
				fileData = File.ReadAllText(path);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine($"Cannot load json file: {path}"); return tile;
			}
			if (fileData == null)
			{
				Console.WriteLine($"Cannot load json file: {path}"); return tile;
			}
			JsonNode jsonData = JsonNode.Parse(fileData)!;
			if (jsonData == null)
			{
				Console.WriteLine($"Cannot parse json file: {path}"); return tile;
			}
			tile.roads = LoadRoads(jsonData);
			Console.WriteLine($"JSON file: {path} loaded!"); return tile;
		}
	}
}
