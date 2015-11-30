using System;

namespace FetchMe.Dto
{
	[Serializable]
	public class TeamMemberDto
	{
		protected bool Equals(TeamMemberDto other)
		{
			return Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((TeamMemberDto) obj);
		}

		public override int GetHashCode()
		{
			return Id;
		}

		public int Id { get; set; }
		public TeamDto Team { get; set; }
		public string Name { get; set; }

		public static bool operator ==(TeamMemberDto lhs, TeamMemberDto rhs)
		{
			if (ReferenceEquals(null, lhs) && ReferenceEquals(null, rhs))
			{
				return true;
			}

			return !ReferenceEquals(null, lhs) && lhs.Equals(rhs);
		}

		public static bool operator !=(TeamMemberDto lhs, TeamMemberDto rhs)
		{
			return !(lhs == rhs);
		}
	}
}