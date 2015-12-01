using System.Collections.Generic;
using FetchMe.Dto;

namespace FetchMe.Logic.Interface
{
	public interface ITeamNameResolver
	{
		string ResolveTeamName(string teamName);
	}
}