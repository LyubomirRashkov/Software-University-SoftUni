using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.MoovIt
{
    public class MoovIt : IMoovIt
    {
        private readonly Dictionary<string, Route> routesById;
        private readonly HashSet<Route> routes;

        public MoovIt()
        {
            this.routesById = new Dictionary<string, Route>();
            this.routes = new HashSet<Route>();
        }

        public int Count => this.routes.Count;

        public void AddRoute(Route route)
        {
            if (this.routes.Contains(route))
            {
                throw new ArgumentException();
            }

            this.routesById.Add(route.Id, route);

            this.routes.Add(route);
        }

        public void RemoveRoute(string routeId)
        {
            this.ValidateRouteExists(routeId);

            Route route = this.routesById[routeId];

            this.routesById.Remove(routeId);

            this.routes.Remove(route);
        }

        public bool Contains(Route route) => this.routes.Contains(route);

        public Route GetRoute(string routeId)
        {
            this.ValidateRouteExists(routeId);

            return this.routesById[routeId];
        }

        public void ChooseRoute(string routeId)
        {
            this.ValidateRouteExists(routeId);

            this.routesById[routeId].Popularity++;
        }

        public IEnumerable<Route> SearchRoutes(string startPoint, string endPoint)
            => this.routes
               .Where(r => r.LocationPoints.Contains(startPoint)
                           && r.LocationPoints.IndexOf(endPoint) > r.LocationPoints.IndexOf(startPoint))
               .OrderByDescending(r => r.IsFavorite)
               .ThenBy(r => r.LocationPoints.IndexOf(endPoint) - r.LocationPoints.IndexOf(startPoint))
               .ThenByDescending(r => r.Popularity);

        public IEnumerable<Route> GetFavoriteRoutes(string destinationPoint)
            => this.routes
               .Where(r => r.IsFavorite && r.LocationPoints.IndexOf(destinationPoint) > 0)
               .OrderBy(r => r.Distance)
               .ThenByDescending(r => r.Popularity);

        public IEnumerable<Route> GetTop5RoutesByPopularityThenByDistanceThenByCountOfLocationPoints()
            => this.routes
               .OrderByDescending(r => r.Popularity)
               .ThenBy(r => r.Distance)
               .ThenBy(r => r.LocationPoints.Count)
               .Take(5);

		private void ValidateRouteExists(string routeId)
		{
            if (!this.routesById.ContainsKey(routeId))
            {
                throw new ArgumentException();
            }
		}
    }
}
