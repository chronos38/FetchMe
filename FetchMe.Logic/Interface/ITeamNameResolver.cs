using FetchMe.Dto;

namespace FetchMe.Logic.Interface
{
	public interface ITeamNameResolver
	{
		TeamDto ResolveTeamName(string teamName);
	}
}