using System;

namespace FetchMe.Dto
{
	[Serializable]
	public class TeamDto
	{
		protected bool Equals(TeamDto other)
		{
			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((TeamDto) obj);
		}

		public override int GetHashCode()
		{
			return Id;
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