using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCity
{
	public class Tile
	{

		private List<Road> roads = new List<Road>();
		public List<Road> Roads
		{
			get { return roads; }
			set 
			{ 
				roads = value; 
				foreach (Road road in roads)
				{
					if (road.GeoLocationMin.X <= geoMin.X)
						geoMin.X = road.GeoLocationMin.X;
					if (road.GeoLocationMin.Y <= geoMin.Y)
						geoMin.Y = road.GeoLocationMin.Y;

					if (road.GeoLocationMax.X >= geoMax.X)
						geoMax.X = road.GeoLocationMax.X;
					if (road.GeoLocationMax.Y >= geoMax.Y)
						geoMax.Y = road.GeoLocationMax.Y;
				}
				foreach (Road road in roads)
				{
					road.CalculateDrawLocationPoints(DrawX, DrawWidth + DrawX, DrawY, DrawHeight + DrawY, geoMin, geoMax);
				}

			}
		}


		private Point geoMin;
		private Point geoMax;
		public int DrawX { get; set; } = 0;
		public int DrawY { get; set; } = 0;
		public int DrawWidth { get; set; } = 400;
		public int DrawHeight { get; set; } = 400;


		public Tile() { }
		
	}
}
