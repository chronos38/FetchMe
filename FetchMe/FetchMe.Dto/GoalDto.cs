using System;

namespace FetchMe.Dto
{
	[Serializable]
	public class GoalDto
	{
		protected bool Equals(GoalDto other)
		{
			return Equals(Goalscrorer, other.Goalscrorer) && Minute == other.Minute;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((GoalDto) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return ((Goalscrorer?.GetHashCode() ?? 0)*397) ^ Minute;
			}
		}

		public int Id { get; set; }
		public TeamMemberDto Goalscrorer { get; set; }
		public int Minute { get; set; }

		public static bool operator ==(GoalDto lhs, GoalDto rhs)
		{
			if (ReferenceEquals(null, lhs) && ReferenceEquals(null, rhs))
			{
				return true;
			}

			return !ReferenceEquals(null, lhs) && lhs.Equals((object) rhs);
		}

		public static bool operator !=(GoalDto lhs, GoalDto rhs) => !(lhs == rhs);
	}
}