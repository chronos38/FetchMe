using System;

namespace FetchMe.Dto
{
	[Serializable]
	public class ReplacementDto
	{
		protected bool Equals(ReplacementDto other)
		{
			return Equals(In, other.In) && Equals(Out, other.Out) && Minute == other.Minute;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			return obj.GetType() == GetType() && Equals((ReplacementDto) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = In?.GetHashCode() ?? 0;
				hashCode = (hashCode*397) ^ (Out?.GetHashCode() ?? 0);
				hashCode = (hashCode*397) ^ Minute;
				return hashCode;
			}
		}

		public int Id { get; set; }
		public string In { get; set; }
		public string Out { get; set; }
		public int Minute { get; set; }

		public static bool operator ==(ReplacementDto lhs, ReplacementDto rhs)
		{
			if (ReferenceEquals(null, lhs) && ReferenceEquals(null, rhs))
			{
				return true;
			}

			return !ReferenceEquals(null, lhs) && lhs.Equals((object) rhs);
		}

		public static bool operator !=(ReplacementDto lhs, ReplacementDto rhs) => !(lhs == rhs);
	}
}