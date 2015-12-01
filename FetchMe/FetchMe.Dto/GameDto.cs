using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;

namespace FetchMe.Dto
{
	[Serializable]
	public class GameDto
	{
		protected bool Equals(GameDto other)
		{
			return Date.Equals(other.Date) && Score1 == other.Score1 && Score2 == other.Score2 &&
			       Team1 == other.Team1 && Team2 == other.Team2;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((GameDto) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Date.GetHashCode();
				hashCode = (hashCode*397) ^ Score1;
				hashCode = (hashCode*397) ^ Score2;
				hashCode = (hashCode*397) ^ (Team1?.GetHashCode() ?? 0);
				hashCode = (hashCode*397) ^ (Team2?.GetHashCode() ?? 0);
				return hashCode;
			}
		}

		public int Id { get; set; }
		public DateTime Date { get; set; }
		public int Score1 { get; set; }
		public int Score2 { get; set; }
		public string Team1 { get; set; }
		public string Team2 { get; set; }

		public static bool operator ==(GameDto lhs, GameDto rhs)
		{
			if (ReferenceEquals(null, lhs) && ReferenceEquals(null, rhs))
			{
				return true;
			}

			return !ReferenceEquals(null, lhs) && lhs.Equals((object) rhs);
		}

		public static bool operator !=(GameDto lhs, GameDto rhs) => !(lhs == rhs);
	}
}
