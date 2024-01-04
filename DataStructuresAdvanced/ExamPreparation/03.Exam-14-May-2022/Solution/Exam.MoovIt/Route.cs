using System.Collections.Generic;
using System.Linq;

namespace Exam.MoovIt
{
    public class Route
    {
        public string Id { get; set; }

        public double Distance { get; set; }

        public int Popularity { get; set; }

        public bool IsFavorite { get; set; }

        public List<string> LocationPoints { get; set; } = new List<string>();

        public Route(string id, double distance, int popularity, bool isFavorite, List<string> locationPoints)
        {
            this.Id = id;
            this.Distance = distance;
            this.Popularity = popularity;
            this.IsFavorite = isFavorite;
            this.LocationPoints = locationPoints;
        }

		public override bool Equals(object obj)
		{
			Route other = obj as Route;

			string startingPoint = this.LocationPoints.Any()
								   ? this.LocationPoints[0]
								   : string.Empty;

			string otherStartingPoint = other.LocationPoints.Any()
										? other.LocationPoints[0]
										: string.Empty;

			string endingPoint = this.LocationPoints.Any()
								 ? this.LocationPoints[this.LocationPoints.Count - 1]
								 : string.Empty;

			string otherEndingPoint = other.LocationPoints.Any()
									  ? other.LocationPoints[other.LocationPoints.Count - 1]
									  : string.Empty;

			return startingPoint.Equals(otherStartingPoint)
				   && endingPoint.Equals(otherEndingPoint)
				   && this.Distance.Equals(other.Distance);
		}

		public override int GetHashCode()
		{
			string startingPoint = this.LocationPoints.Any()
								   ? this.LocationPoints[0]
								   : string.Empty;

			string endingPoint = this.LocationPoints.Any()
								 ? this.LocationPoints[this.LocationPoints.Count - 1]
								 : string.Empty;

			return startingPoint.GetHashCode() * endingPoint.GetHashCode() * this.Distance.GetHashCode();
		}
	}
}
