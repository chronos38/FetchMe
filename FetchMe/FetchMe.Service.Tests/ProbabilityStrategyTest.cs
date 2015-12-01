using System;
using System.Collections.Generic;
using FetchMe.Data;
using FetchMe.Data.Interface;
using FetchMe.Dto;
using FetchMe.Logic;
using FetchMe.Logic.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FetchMe.Service.Tests
{
	internal class ProbabilityStrategyTestContract
	{
		private IProbabilityStrategy ProbabilityStrategy { get; }

		public ProbabilityStrategyTestContract(IProbabilityStrategy probabilityStrategy)
		{
			ProbabilityStrategy = probabilityStrategy;
		}

		public bool ExpectThrowIfFirstTeamIsNotValid()
		{
			try
			{
				ProbabilityStrategy.Compute("", "Foo");
				return false;
			}
			catch (LogicException)
			{
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool ExpectThrowIfSecondTeamIsNotValid()
		{
			try
			{
				ProbabilityStrategy.Compute("Foo", "");
				return false;
			}
			catch (LogicException)
			{
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public float? ShouldReturn50ForEqualTeams()
		{
			return ProbabilityStrategy.Compute("Foo", "Bar");
		}
	}

	[TestClass]
	public class ProbabilityStrategyTest
	{
		public IGameRepository GameRepository;

		[TestInitialize]
		public void Setup()
		{
			GameRepository = new GameRepositoryInMemory();
			GameRepository.AddGame(new Game
			{
				Team1 = "Foo",
				Team2 = "Bar",
				Score1 = 0,
				Score2 = 1
			});
			GameRepository.AddGame(new Game
			{
				Team1 = "Foo",
				Team2 = "Bar",
				Score1 = 1,
				Score2 = 0
			});
			GameRepository.AddGame(new Game
			{
				Team1 = "Foo",
				Team2 = "Bar",
				Score1 = 0,
				Score2 = 1
			});
			GameRepository.AddGame(new Game
			{
				Team1 = "Foo",
				Team2 = "Bar",
				Score1 = 1,
				Score2 = 0
			});
		}

		[TestMethod]
		public void TestClass_ProbabilityStrategy()
		{
			var adapter = new ProbabilityStrategyTestContract(new ProbabilityStrategy(GameRepository).SetGameCount(4));
			Assert.IsTrue(adapter.ExpectThrowIfFirstTeamIsNotValid());
			Assert.IsTrue(adapter.ExpectThrowIfSecondTeamIsNotValid());
			Assert.AreEqual(0.5f, adapter.ShouldReturn50ForEqualTeams());
		}
	}
}
