using System;
using System.Collections.Generic;
using FetchMe.Service.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FetchMe.Service.Tests
{
	[TestClass]
	public class MapperTest
	{
		[TestInitialize]
		public void Startup()
		{
			Mapper.Configure();
		}

		[TestMethod]
		public void AutomapperTest()
		{
			// Given
			var game = new Game
			{
				Date = DateTime.UtcNow,
				Minutes = 90,
				Score = new Score
				{
					Score1 = 1,
					Score2 = 2
				},
				Team1 = new GameData
				{
					Team = new Team
					{
						Country = "Foo",
						Name = "Bar"
					},
					Lineup = new List<TeamMember>
					{
						new TeamMember
						{
							Name = "Foo"
						}
					}
				},
				Team2 = new GameData
				{
					Team = new Team
					{
						Country = "Baz",
						Name = "Bar"
					},
					Lineup = new List<TeamMember>
					{
						new TeamMember
						{
							Name = "Bar"
						}
					}
				}
			};

			// When
			var dto = Mapper.Map(game);

			// Then
			Assert.AreEqual(game.Date, dto.Date);
			Assert.AreEqual(game.Minutes, dto.Minutes);
			Assert.AreEqual(game.Score.Score1, dto.Score.Score1);
			Assert.AreEqual(game.Score.Score2, dto.Score.Score2);
		}
	}
}
