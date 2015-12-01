using System;
using System.Collections.Generic;
using FetchMe.Service.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FetchMe.Service.Tests
{
	[TestClass]
	public class MapperTest
	{
		[TestMethod]
		public void AutomapperTest()
		{
			// Given
			var game = new Game
			{
				Date = DateTime.UtcNow,
				Minutes = 90,
				Score1 = 1,
				Score2 = 2,
				Team1 = new GameData
				{
					Team = "Foo",
					Lineup = new List<string> { "Foo" }
				},
				Team2 = new GameData
				{
					Team = "Bar",
					Lineup = new List<string> { "Foo" } 
				}
			};

			// When
			var dto = Mapper.Map(game);

			// Then
			Assert.AreEqual(game.Date, dto.Date);
			Assert.AreEqual(game.Minutes, dto.Minutes);
			Assert.AreEqual(game.Score1, dto.Score1);
			Assert.AreEqual(game.Score2, dto.Score2);
		}
	}
}
