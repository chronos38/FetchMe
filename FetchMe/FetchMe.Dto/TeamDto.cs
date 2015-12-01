using System;

namespace FetchMe.Dto
{
	[Serializable]
	public class TeamDto
	{
		protected bool Equals(TeamDto other)
		{
			return string.Equals(Name, other.Name) && string.Equals(Country, other.Country);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((TeamDto) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Name?.GetHashCode() ?? 0)*397) ^ (Country?.GetHashCode() ?? 0);
			}
		}

		public int Id { get; set; }
		public string Name { get; set; } 
		public string Country { get; set; }

		public static bool operator ==(TeamDto lhs, TeamDto rhs)
		{
			if (ReferenceEquals(null, lhs) && ReferenceEquals(null, rhs))
			{
				return true;
			}

			return !ReferenceEquals(null, lhs) && lhs.Equals(rhs);
		}

		public static bool operator !=(TeamDto lhs, TeamDto rhs) => !(lhs == rhs);
	}
}