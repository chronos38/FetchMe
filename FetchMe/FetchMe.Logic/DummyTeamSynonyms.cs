using FetchMe.Logic.Interface;

namespace FetchMe.Logic
{
	public class DummyTeamSynonyms : ITeamSynonyms
	{
		public string ResolveSynonym(string teamName)
		{
			return teamName.ToLower();
		}
	}
}