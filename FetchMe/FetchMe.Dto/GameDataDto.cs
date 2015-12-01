using System;
using System.Collections.Generic;

namespace FetchMe.Dto
{
	[Serializable]
	public class GameDataDto
	{
		protected bool Equals(GameDataDto other)
		{
			return Equals(Team, other.Team) && Equals(Lineup, other.Lineup) && Equals(Replacements, other.Replacements) &&
			       Equals(YellowCards, other.YellowCards) && Equals(RedCards, other.RedCards) &&
			       string.Equals(Trainer, other.Trainer);
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((GameDataDto) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Team?.GetHashCode() ?? 0;
				hashCode = (hashCode*397) ^ (Lineup?.GetHashCode() ?? 0);
				hashCode = (hashCode*397) ^ (Replacements?.GetHashCode() ?? 0);
				hashCode = (hashCode*397) ^ (YellowCards?.GetHashCode() ?? 0);
				hashCode = (hashCode*397) ^ (RedCards?.GetHashCode() ?? 0);
				hashCode = (hashCode*397) ^ (Trainer?.GetHashCode() ?? 0);
				return hashCode;
			}
		}

		public int Id { get; set; }
		public TeamDto Team { get; set; }
		public IEnumerable<TeamMemberDto> Lineup { get; set; }
		public IEnumerable<ReplacementDto> Replacements { get; set; }
		public IEnumerable<TeamMemberDto> YellowCards { get; set; }
		public IEnumerable<TeamMemberDto> RedCards { get; set; }
		public string Trainer { get; set; }

		public static bool operator ==(GameDataDto lhs, GameDataDto rhs)
		{
			if (ReferenceEquals(null, lhs) && ReferenceEquals(null, rhs))
			{
				return true;
			}

			return !ReferenceEquals(null, lhs) && lhs.Equals((object) rhs);
		}

		public static bool operator !=(GameDataDto lhs, GameDataDto rhs) => !(lhs == rhs);
	}
}