"use strict";
let request = require("request");

request({ url: "http://api.football-data.org/v1/soccerseasons", headers: { "X-Response-Control": "minified" } }, function (error, response, body) {
	if (error) {
		return console.error(error);
	} else {
		console.log(JSON.parse(body));
	}
});