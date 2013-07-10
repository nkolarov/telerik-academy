var ui = (function () {
    var escapeHTML = (function () {
        'use strict';
        var chr = {
            '"': '&quot;', '&': '&amp;', "'": '&#39;',
            '/': '&#47;', '<': '&lt;', '>': '&gt;'
        };
        return function (text) {
            return text.replace(/[\"&'\/<>]/g, function (a) { return chr[a]; });
        };
    }());

	function buildLoginForm() {
		var html =
            '<div id="login-form-holder">' +
				'<form>' +
					'<div id="login-form">' +
						'<label for="tb-login-username">Username: </label>' +
						'<input type="text" id="tb-login-username"><br />' +
						'<label for="tb-login-password">Password: </label>' +
						'<input type="text" id="tb-login-password"><br />' +
						'<button id="btn-login" class="button">Login</button>' +
					'</div>' +
					'<div id="register-form" style="display: none">' +
						'<label for="tb-register-username">Username: </label>' +
						'<input type="text" id="tb-register-username"><br />' +
						'<label for="tb-register-nickname">Nickname: </label>' +
						'<input type="text" id="tb-register-nickname"><br />' +
						'<label for="tb-register-password">Password: </label>' +
						'<input type="text" id="tb-register-password"><br />' +
						'<button id="btn-register" class="button">Register</button>' +
					'</div>' +
					'<a href="#" id="btn-show-login" class="button selected">Login</a>' +
					'<a href="#" id="btn-show-register" class="button">Register</a>' +
				'</form>' +
            '</div>';
		return html;
	}

	function buildGameUI(nickname) {
		var html = '<span id="user-nickname">' +
				escapeHTML(nickname) +
		'</span>' +
		'<button id="btn-logout">Logout</button><br/>' +
		'<div id="create-game-holder">' +
			'Title: <input type="text" id="tb-create-title" />' +
			'Password: <input type="text" id="tb-create-pass" />' +
			'<button id="btn-create-game">Create</button>' +
		'</div>' +
		'<div id="open-games-container">' +
			'<h2>Open</h2>' +
			'<div id="open-games"></div>' +
		'</div>' +
		'<div id="active-games-container">' +
			'<h2>Active</h2>' +
			'<div id="active-games"></div>' +
		'</div>' +
		'<div id="game-holder">' +
		'</div>';
		return html;
	}

	function buildOpenGamesList(games) {
		var list = '<ul class="game-list open-games">';
		for (var i = 0; i < games.length; i++) {
			var game = games[i];
			list +=
				'<li data-game-id="' + game.id + '">' +
					'<a href="#" >' +
						$("<div />").html(game.title).text() +
					'</a>' +
					'<span> by ' +
						game.creator +
					'</span>' +
				'</li>';
		}
		list += "</ul>";
		return list;
	}

	function buildActiveGamesList(games) {
		var gamesList = Array.prototype.slice.call(games, 0);
		gamesList.sort(function (g1, g2) {
			if (g1.status == g2.status) {
				return g1.title > g2.title;
			}
			else
			{
				if (g1.status == "in-progress") {
					return -1;
				}
			}
			return 1;
		});

		var list = '<ul class="game-list active-games">';
		for (var i = 0; i < gamesList.length; i++) {
			var game = gamesList[i];
			list +=
				'<li data-game-id="' + game.id + '">' +
					'<a href="#" class="' + game.status + '">' +
						$("<div />").html(game.title).text() +
					'</a>' +
					'<span> by ' +
						game.creator +
					'</span>' +
                    '<span> Status:  ' +
						game.status +
					'</span>' +
				'</li>';
		}
		list += "</ul>";
		return list;
	}

	function getPlayerAtPosition(warriorsPositions, positionX, positionY) {

	    for (var i = 0; i < warriorsPositions.length; i++) {
	        if (warriorsPositions[i].positionX == positionX && warriorsPositions[i].positionY == positionY) {
	            return warriorsPositions[i];
	        }
	    }

	    return {};
	}

	function buildFieldTable(gameField) {
	    var redWarriors = gameField.red.units;
	    var blueWarriors = gameField.blue.units;

	    var warriorsPositions = [];
	    for (var i = 0; i < redWarriors.length; i++) {
	        warriorsPositions.push({ warriorReference: redWarriors[i], positionX: redWarriors[i].position.x, positionY: redWarriors[i].position.y });
	    }

	    for (var i = 0; i < blueWarriors.length; i++) {
	        warriorsPositions.push({ warriorReference: blueWarriors[i], positionX: blueWarriors[i].position.x, positionY: blueWarriors[i].position.y });
	    }

	    
	    var tableHtml =
			'<table border="1" cellspacing="0" cellpadding="0">';

	    for (var i = 0; i < 9; i++) {
	        tableHtml +=
                '<tr>';
	        for (var j = 0; j < 9; j++) {
	            var player = getPlayerAtPosition(warriorsPositions, i, j);
	            
	            if (!player.warriorReference) {
	                tableHtml +=
                        '<td '+ ' data-row-id="' + i + '"' + ' data-col-id="' + j + '">&nbsp;</td>';
	            } else {
	                
	                tableHtml +=
                           	'<td data-player-id="' + player.warriorReference.id + '"' + ' data-row-id="' + i + '"' + ' data-col-id="' + j + '" class="' + player.warriorReference.owner + ' ' + player.warriorReference.mode + '">' +
                                player.warriorReference.type +
                            '</td>';
	            }
	        }
	        tableHtml +=
                '</tr>';
	    }
	    tableHtml += '</table>';

		return tableHtml;
	}

	function buildGameField(gameField) {
		var html =
			'<div id="game-state" data-game-id="' + gameField.gameId + '">' +
				'<h2>' + gameField.title + '</h2>' +
                '<h2>' + gameField.red.nickname + '(red) VS ' + gameField.blue.nickname + '(blue)</h2>' +
				'<div id="game-field">' +
					'<h3>' +
						'<span> Turn: ' + gameField.turn + '</span>'+
		                '<span> InTurn: ' + gameField.inTurn + '</span>'+
					'</h3>'+
					buildFieldTable(gameField) +
				'</div>' +
		'</div>';

		return html;
	}

	function generateMessagesList(messages) {
	    var html = '<div id="message-holder"><ul>';
            for (var i = 0; i < messages.length; i++) {
                var current = messages[i];
                html += '<li>' + current.text + '</li>';
            }
            html += '</ul></div>';

            return html;

	}


	return {
		gameUI: buildGameUI,
		openGamesList: buildOpenGamesList,
		loginForm: buildLoginForm,
		activeGamesList: buildActiveGamesList,
		gameField: buildGameField,
        messagesList: generateMessagesList,
	}

}());