using FetchMe.Dto;

namespace FetchMe.Logic.Interface
{
	public interface IProbabilityStrategy
	{
		/// <summary>
		/// Computes probabilty <paramref name="team1">first team</paramref> wins against <paramref name="team2">second team</paramref>.
		/// This method throws a <see cref="LogicException"/> if either of the given teams could neither be found nor any data is available.
		/// </summary>
		/// <param name="team1">First team to compute.</param>
		/// <param name="team2">Second team to compute.</param>
		/// <returns>Value ranging between 0 and 1 where 0 is 0 percent and 1 is a 100 percent.</returns>
		float? Compute(TeamDto team1, TeamDto team2);
	}
}