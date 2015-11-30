namespace FetchMe.Data
{
	using System;
	using System.Data.Entity;
	using System.Linq;

	public class FetchMeModel : DbContext
	{
		// Your context has been configured to use a 'FetchMeModel' connection string from your application's 
		// configuration file (App.config or Web.config). By default, this connection string targets the 
		// 'FetchMe.Data.FetchMeModel' database on your LocalDb instance. 
		// 
		// If you wish to target a different database and/or database provider, modify the 'FetchMeModel' 
		// connection string in the application configuration file.
		public FetchMeModel()
			: base("name=FetchMeModel")
		{
		}

		// Add a DbSet for each entity type that you want to include in your model. For more information 
		// on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

		// public virtual DbSet<MyEntity> MyEntities { get; set; }
		public virtual DbSet<Game> Games { get; set; }
		public virtual DbSet<GameData> GameData { get; set; }
		public virtual DbSet<Goal> Goals { get; set; }
		public virtual DbSet<Replacement> Replacements { get; set; }
		public virtual DbSet<Score> Scores { get; set; }
		public virtual DbSet<Team> Teams { get; set; }
		public virtual DbSet<TeamMember> TeamMembers { get; set; }   
	}

	//public class MyEntity
	//{
	//    public int Id { get; set; }
	//    public string Name { get; set; }
	//}
}