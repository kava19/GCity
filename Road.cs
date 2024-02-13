using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GCity
{
	public class Road
	{
		private List<Point> geoLocationPoints = new List<Point>();

		public List<Point> GeoLocationPoints 
		{ 
			get => geoLocationPoints;
			set
			{
				geoLocationPoints = value;
				GeoLocationMin = _GetLocationMin();
				GeoLocationMax = _GetLocationMax();
			}
		}
		public List<Point> DrawLocationPoints { get; set; } = new List<Point>();
		public Point GeoLocationMin { get; set; } = new Point();
		public Point GeoLocationMax { get; set; } = new Point();


		private Point _GetLocationMin()
		{
			var org = GeoLocationPoints;
			return new Point(org.Min(org => org.X), org.Min(org => org.Y));
		}

		private Point _GetLocationMax()
		{
			var org = GeoLocationPoints;
			return new Point(org.Max(org => org.X), org.Max(org => org.Y));
		}


		public void CalculateDrawLocationPoints(float xNewMin, float xNewMax, float yNewMin, float yNewMax, Point oldMin, Point oldMax)
		{
			float xOldMin = oldMin.X;
			float xOldMax = oldMax.X;
			float yOldMin = oldMin.Y;
			float yOldMax = oldMax.Y;

			var org = GeoLocationPoints;
			List<Point> ret = new List<Point>();

			foreach (Point p in org)
			{
				var oldValueX = p.X;
				var newValueX = ((oldValueX - xOldMin) / (xOldMax - xOldMin)) * (xNewMax - xNewMin) + xNewMin;
				var oldValueY = p.Y;
				var newValueY = ((oldValueY - yOldMin) / (yOldMax - yOldMin)) * (yNewMax - yNewMin) + yNewMin;

				ret.Add(new Point(newValueX, newValueY));
			}

			DrawLocationPoints = ret;
		}
		
	}
}
