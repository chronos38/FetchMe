using System;
using FetchMe.Dto;
using FetchMe.Logic;
using FetchMe.Logic.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FetchMe.Service.Tests
{
	internal class ProbabilityStrategyTestContract
	{
		private IProbabilityStrategy ProbabilityStrategy { get; set; }

		public ProbabilityStrategyTestContract(IProbabilityStrategy probabiltyStrategy)
		{
			ProbabilityStrategy = probabiltyStrategy;
		}

		public bool ExpectThrowIfFirstTeamIsNotValid()
		{
			try
			{
				ProbabilityStrategy.Compute(new TeamDto {Name = "", Country = ""}, new TeamDto {Name = "Foo", Country = "Bar"});
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
				ProbabilityStrategy.Compute(new TeamDto { Name = "Foo", Country = "Bar" }, new TeamDto { Name = "", Country = "" });
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
			return ProbabilityStrategy.Compute(new TeamDto { Name = "Foo", Country = "Bar" }, new TeamDto { Name = "Baz", Country = "Bar" });
		}
	}

	[TestClass]
	public class ProbabilityStrategyTest
	{
		[TestMethod]
		public void TestClass_ProbabilityStrategy()
		{
			var adapter = new ProbabilityStrategyTestContract(new ProbabilityStrategy());
			Assert.IsTrue(adapter.ExpectThrowIfFirstTeamIsNotValid());
			Assert.IsTrue(adapter.ExpectThrowIfSecondTeamIsNotValid());
			Assert.AreEqual(0.5f, adapter.ShouldReturn50ForEqualTeams());
		}
	}
}
