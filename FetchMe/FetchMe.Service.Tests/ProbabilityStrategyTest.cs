using System;
using System.Collections.Generic;
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
				ProbabilityStrategy.Compute(new TeamDto {Name = "", Country = ""},
					new TeamDto {Id = 1, Name = "Foo", Country = "Bar"});
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
				ProbabilityStrategy.Compute(new TeamDto {Id = 1, Name = "Foo", Country = "Bar"},
					new TeamDto {Name = "", Country = ""});
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
			return ProbabilityStrategy.Compute(new TeamDto {Id = 1, Name = "Foo", Country = "Bar"},
				new TeamDto {Id = 2, Name = "Baz", Country = "Bar"});
		}
	}

	[TestClass]
	public class ProbabilityStrategyTest
	{
		private Mock<IGameRepository> Mock { get; } = new Mock<IGameRepository>();

		[TestInitialize]
		public void Setup()
		{
			var teamFoo = new TeamDto { Id = 1, Name = "Foo", Country = "Bar" };
			var teamBaz = new TeamDto { Id = 2, Name = "Baz", Country = "Bar" };
			var result = new List<GameDto>
			{
				new GameDto
				{
					Team1 = new GameDataDto {Id = 1, Team = new TeamDto {Id = 1, Name = "Foo", Country = "Bar"}},
					Team2 = new GameDataDto {Id = 2, Team = new TeamDto {Id = 2, Name = "Baz", Country = "Bar"}},
					Score = new ScoreDto {Id = 1, Score1 = 0, Score2 = 1}
				},
				new GameDto
				{
					Team1 = new GameDataDto {Id = 3, Team = new TeamDto {Id = 1, Name = "Foo", Country = "Bar"}},
					Team2 = new GameDataDto {Id = 4, Team = new TeamDto {Id = 2, Name = "Baz", Country = "Bar"}},
					Score = new ScoreDto {Id = 2, Score1 = 1, Score2 = 0}
				},
				new GameDto
				{
					Team1 = new GameDataDto {Id = 5, Team = new TeamDto {Id = 1, Name = "Foo", Country = "Bar"}},
					Team2 = new GameDataDto {Id = 6, Team = new TeamDto {Id = 2, Name = "Baz", Country = "Bar"}},
					Score = new ScoreDto {Id = 3, Score1 = 0, Score2 = 1}
				},
				new GameDto
				{
					Team1 = new GameDataDto {Id = 7, Team = new TeamDto {Id = 1, Name = "Foo", Country = "Bar"}},
					Team2 = new GameDataDto {Id = 8, Team = new TeamDto {Id = 2, Name = "Baz", Country = "Bar"}},
					Score = new ScoreDto {Id = 4, Score1 = 1, Score2 = 0}
				}
			};

			Mock.Setup(repository => repository.GetGames(teamFoo)).Returns(result);
			Mock.Setup(repository => repository.GetGames(teamFoo, teamBaz)).Returns(result);
		}

		[TestMethod]
		public void TestClass_ProbabilityStrategy()
		{
			var adapter = new ProbabilityStrategyTestContract(new ProbabilityStrategy(Mock.Object).SetGameCount(4));
			Assert.IsTrue(adapter.ExpectThrowIfFirstTeamIsNotValid());
			Assert.IsTrue(adapter.ExpectThrowIfSecondTeamIsNotValid());
			Assert.AreEqual(0.5f, adapter.ShouldReturn50ForEqualTeams());
		}
	}
}
