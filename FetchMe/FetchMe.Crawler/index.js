"use strict";
let config = require("config");
let path = require("path");
let url = require("url");
let request = require("request");
let async = require("async");
let winston = require("winston");

let crawlerServiceUrl = url.format({
	protocol: "http",
	port: config.crawlerService.port,
	hostname: config.crawlerService.host,
	pathname: config.crawlerService.path
});
let games = require(path.resolve(path.join(".", "games.js")));
let instance = new games();

winston.info("Start to process");
instance.run({
	season: parseInt(config.footballDataOrg.season, 10),
	league: config.footballDataOrg.league,
	token: config.footballDataOrg.token
}, function (error, games) {
	if (error) {
		return winston.error(error);
	}
	
	winston.info("Acquired all games, sending them now to CrawlerService: " + crawlerServiceUrl);
	async.each(games, function (game, callback) {
		request({
			url: crawlerServiceUrl,
			method: "POST",
			body: game,
			json: true
		}, function (error, response) {
			if (error) {
				callback(error);
			} else if (response.statusCode !== 200) {
				callback(new Error("Status: " + response.statusCode));
			} else {
				callback();
			}
		});
	}, function (error) {
		if (error) {
			winston.error(error);
		} else {
			winston.info("Finished processing, shuting down ...");
		}
	});
});
