/// <reference path="libs/require.js" />
require.config({
	paths: {
		jquery: "libs/jquery-1.8.2",
		rsvp: "libs/rsvp.min",
		"class": "libs/class",
		mustache: "libs/mustache",
		controlls: "libs/controlls",
		httpRequester: "libs/http-requester",
		controller: "apps/controller",
		dataPersister: "apps/dataPersister"
	}
});

require(["controller"], function (controller) {
    controller.initialize();
});