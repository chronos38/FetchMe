using FetchMe.Dto;

namespace FetchMe.Logic.Interface
{
	public interface IGameValidation
	{
		bool ValidateAndAdd(GameDto game);
	}
}