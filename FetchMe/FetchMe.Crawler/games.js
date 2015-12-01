"use strict";
module.exports = function () {
	let url = require("url");
	let async = require("async");
	let request = require("request");
	let winston = require("winston");
	let baseUrl = "api.football-data.org";
	let soccerSeasons = "/v1/soccerseasons";
	let soccerFixtures = "/v1/soccerseasons/:id/fixtures";
	let headers = { "X-Response-Control": "minified" };
	let self = this;
	
	this.run = function (options, done) {
		this.season = options.season;
		this.league = options.league.toLocaleLowerCase();
		headers["X-Auth-Token"] = options.token;
		let n = (new Date).getUTCFullYear() - this.season + 1;
		
		// iterate over every season beginning at start date
		async.times(n, function (iteration, next) {
			async.waterfall([
				function (callback) {
					// request season data
					let apiUrl = url.format({ protocol: "http", hostname: baseUrl, pathname: soccerSeasons, query: "season=" + (self.season + n) });
					request({ url: apiUrl, headers: headers }, function (error, response, body) {
						if (error) {
							return callback(error);
						} else if (response.statusCode !== 200) {
							return callback(new Error("Status: " + response.statusCode));
						}
						
						winston.info("Acquired season data for: " + (self.season + iteration));
						let called = false;
						let data = JSON.parse(body);
						data.forEach(function (item) {
							if (item.caption.toLocaleLowerCase().indexOf(self.league) !== -1) {
								callback(null, item);
								called = true;
								return false;
							}
						});
						
						if (!called) {
							callback(null, null);
						}
					});
				},
				function (season, callback) {
					if (!season) {
						return callback(null, []);
					}
					
					// request fixtures (games)
					let fixturesUrl = soccerFixtures.replace(":id", season.id);
					let apiUrl = url.format({ protocol: "http", hostname: baseUrl, pathname: fixturesUrl });
					request({ url: apiUrl, headers: headers }, function (error, response, body) {
						if (error) {
							callback(error);
						} else if (response.statusCode !== 200) {
							return callback(new Error("Status: " + response.statusCode));
						} else {
							winston.info("Acquired fixtures for: " + season.id);
							callback(null, JSON.parse(body).fixtures);
						}
					});
				}
			], function (error, fixtures) {
				if (error) {
					return next(error);
				}
				
				let games = [];
				fixtures.forEach(function (fixture) {
					// convert to required data for web service
					games.push({
						date: new Date(fixture.date),
						score1: fixture.result.goalsHomeTeam,
						score2: fixture.result.goalsAwayTeam,
						team1: fixture.homeTeamName,
						team2: fixture.awayTeamName
					});
				});
				next(null, games);
			});
		}, function (error, gamesCollection) {
			if (error) {
				return done(error);
			}
			
			// gamesCollection contains an array per index, so it is here merged
			let result = [];
			gamesCollection.forEach(function (games) {
				result = result.concat(games);
			});
			done(null, result);
		});
	};
};
