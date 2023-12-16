using System;
using System.Collections.Generic;

namespace Exam.PackageManagerLite
{
    public class Package
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Version { get; set; }

        public List<string> DependenciesIds { get; set; }

        public Package(string id, string name, DateTime releaseDate, string version)
        {
            this.Id = id;
            this.Name = name;
            this.ReleaseDate = releaseDate;
            this.Version = version;

            this.DependenciesIds = new List<string>();
        }

        public override bool Equals(object obj)
        {
            Package other = obj as Package;

            return this.Name == other.Name
                   && this.Version == other.Version;
        }

        public override int GetHashCode()
		{
			return this.Name.GetHashCode() * this.Version.GetHashCode();
		}
	}
}
