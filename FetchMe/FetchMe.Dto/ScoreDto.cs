using System;

namespace FetchMe.Dto
{
	[Serializable]
	public class ScoreDto
	{
		protected bool Equals(ScoreDto other)
		{
			return Score1 == other.Score1 && Score2 == other.Score2;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((ScoreDto) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Score1*397) ^ Score2;
			}
		}

		public int Id { get; set; }
		public int Score1 { get; set; }
		public int Score2 { get; set; }

		public static bool operator ==(ScoreDto lhs, ScoreDto rhs)
		{
			if (ReferenceEquals(null, lhs) && ReferenceEquals(null, rhs))
			{
				return true;
			}

			return !ReferenceEquals(null, lhs) && lhs.Equals((object) rhs);
		}

		public static bool operator !=(ScoreDto lhs, ScoreDto rhs) => !(lhs == rhs);
	}
}