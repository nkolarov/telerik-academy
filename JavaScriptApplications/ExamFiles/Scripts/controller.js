/// <reference path="class.js" />
/// <reference path="persister.js" />
/// <reference path="jquery-2.0.2.js" />
/// <reference path="ui.js" />

var controllers = (function () {
    var rootUrl = "http://localhost:22954/api/";
    var Controller = Class.create({
        init: function () {
            this.persister = persisters.get(rootUrl);
        },
        loadUI: function (selector) {
            if (this.persister.isUserLoggedIn()) {
                this.loadGameUI(selector);
            }
            else {
                this.loadLoginFormUI(selector);
            }
            this.attachUIEventHandlers(selector);
        },
        loadLoginFormUI: function (selector) {
            var loginFormHtml = ui.loginForm()
            $(selector).html(loginFormHtml);
        },
        loadGameUI: function (selector) {
            var list =
            ui.gameUI(this.persister.nickname());
            $(selector).html(list);

            this.persister.game.open(function (games) {
                var list = ui.openGamesList(games);
                $(selector + " #open-games")
                .html(list);
            });

            this.persister.game.myActive(function (games) {
                var list = ui.activeGamesList(games);
                $(selector + " #active-games")
                .html(list);
            });
        },
        loadGame: function (selector, gameId) {
            this.persister.game.field(gameId, function (gameField) {
                var gameHtml = ui.gameField(gameField);
                $(selector + " #game-holder").html(gameHtml)
            });
        },
        attachUIEventHandlers: function (selector) {
            var wrapper = $(selector);
            var self = this;

            wrapper.on("click", "#btn-show-login", function () {
                wrapper.find(".button.selected").removeClass("selected");
                $(this).addClass("selected");
                wrapper.find("#login-form").show();
                wrapper.find("#register-form").hide();
            });
            wrapper.on("click", "#btn-show-register", function () {
                wrapper.find(".button.selected").removeClass("selected");
                $(this).addClass("selected");
                wrapper.find("#register-form").show();
                wrapper.find("#login-form").hide();
            });

            wrapper.on("click", "#btn-login", function () {
                var that = this;
                var user = {
                    username: $(selector + " #tb-login-username").val(),
                    password: $(selector + " #tb-login-password").val()
                }

                self.persister.user.login(user, function () {
                    self.loadGameUI(selector);
                }, function (errData) {
                    self.reportError(that, errData);
                });
                return false;
            });
            wrapper.on("click", "#btn-register", function () {
                var that = this;
                var user = {
                    username: $(selector + " #tb-register-username").val(),
                    nickname: $(selector + " #tb-register-nickname").val(),
                    password: $(selector + " #tb-register-password").val()
                }

                self.persister.user.register(user, function () {
                    self.loadGameUI(selector);
                }, function (errData) {
                    self.reportError(that, errData);
                });
                return false;
            });
            wrapper.on("click", "#btn-logout", function () {
                var that = this;
                self.persister.user.logout(function () {
                    self.loadLoginFormUI(selector);
                }, function (errData) {
                    self.reportError(that, errData);
                });
            });

            wrapper.on("click", "#open-games-container a", function () {
                $("#game-join-inputs").remove();
                var html =
                '<div id="game-join-inputs">' +
                'Password: <input type="text" id="tb-game-pass"/>' +
                '<button id="btn-join-game">join</button>' +
                '</div>';
                $(this).after(html);
            });

            wrapper.on("click", "#active-games-container a.full", function () {
                $("#start-game-parameters").remove();
                var html =
                '<div id="start-game-parameters">' +
                '<button id="btn-start-game">Start</button>' +
                '</div>';
                $(this).after(html);
            });

            wrapper.on("click", "#btn-join-game", function () {
                var that = this;

                var game = {
                    number: $("#tb-game-number").val(),
                    gameId: $(this).parents("li").first().data("game-id")
                };

                var password = $("#tb-game-pass").val();

                if (password) {
                    game.password = password;
                }
                self.persister.game.join(game, function () {
                    self.loadGameUI(selector);
                }, function (errData) {
                    self.reportError(that, errData);
                });
            });
            wrapper.on("click", "#btn-create-game", function () {
                var that = this;

                var game = {
                    title: $("#tb-create-title").val(),
                }
                var password = $("#tb-create-pass").val();
                if (password) {
                    game.password = password;
                }
                self.persister.game.create(game, function () {
                    self.loadGameUI(selector);
                }, function (errData) {
                    self.reportError(that, errData);
                });
            });

            wrapper.on("click", "#btn-start-game", function () {
                var that = this;

                var game = {
                    gameId: $(this).parents("li").first().data("game-id")
                }

                self.persister.game.start(game, function () {
                    self.loadGameUI(selector);
                }, function (errData) {
                    self.reportError(that, errData);
                });
            });

            wrapper.on("click", ".active-games .in-progress", function () {
                //var that = this;
                //(function refresh() {
                //    self.loadGame(selector, $(that).parent().data("game-id"));
                //setInterval(function() {
                //    refresh();
                //}, 2000);}());
                // ToDo: Fix refreshing.
                self.loadGame(selector, $(this).parent().data("game-id"));
            });

            wrapper.on("click", "#game-field table td", function () {
                var gameId = $("#game-state").data("game-id");

                var getColor = function (warrior) {
                    for (var i = 0; i < warrior[0].classList.length; i++) {
                        if (warrior[0].classList[i] == "blue") {
                            return "blue";
                        }
                        if (warrior[0].classList[i] == "red") {
                            return "red";
                        }
                    }
                };

                var selectedWarriors = $(".first-warrior");
                var firstWarrior = $(selectedWarriors[0]);
                var firstWarriorId = firstWarrior.data("player-id");

                if (firstWarrior && (firstWarriorId == $(this).data("player-id"))) {
                    $(".first-warrior").removeClass("first-warrior");
                    return;
                }
                
                // if we have more than one selected element.
                if (selectedWarriors.length > 0) {
                    if ($(this).data("player-id") != undefined) {
                        var firstWarriorColor = getColor(firstWarrior);
                        var secondWarrior = $(this);
                        var secondWarriorId = secondWarrior.data("player-id");
                        var secondWarriorColor = getColor(secondWarrior);
                        
                        if (firstWarriorColor == secondWarriorColor) {
                            // move
                            var warriorData = { gameId: gameId, unitId: firstWarriorId, positionX: secondWarrior.data("row-id"), positionY: secondWarrior.data("col-id") };
                            self.persister.battle.move(warriorData, function () {
                                $(".first-warrior").removeClass("first-warrior");
                                self.loadGame(selector, gameId);
                            }, function (errData) {
                                self.reportError("#game-state", errData);
                                $(".first-warrior").removeClass("first-warrior");
                            });
                        }
                        else {
                            // attack
                            var warriorData = { gameId: gameId, unitId: firstWarriorId, positionX: secondWarrior.data("row-id"), positionY: secondWarrior.data("col-id") };
                            self.persister.battle.attack(warriorData, function () {
                                $(".first-warrior").removeClass("first-warrior");
                                self.loadGame(selector, gameId);
                            }, function (errData) {
                                self.reportError("#game-state", errData);
                                $(".first-warrior").removeClass("first-warrior");
                            });
                        }
                    }
                    else {
                        // move
                        var newPosition = $(this);
                        var newPositionData = { gameId: gameId, unitId: firstWarriorId, positionX: newPosition.data("row-id"), positionY: newPosition.data("col-id") };
                        self.persister.battle.move(newPositionData, function () {
                            $(".first-warrior").removeClass("first-warrior");
                            self.loadGame(selector, gameId);
                        }, function (errData) {
                            self.reportError("#game-state", errData);
                            $(".first-warrior").removeClass("first-warrior");
                        });
                    }
                }
                else {
                    $(this).addClass("first-warrior");
                }
            });

            // Defend
            wrapper.on("dblclick", "#game-field table td", function () {
                if ($(this).data("player-id") != undefined) {
                    var playerId = $(this).data("player-id");
                    var gameId = $("#game-state").data("game-id");
                    var warriorData = { gameId: gameId, unitId: playerId };
                    self.persister.battle.defend(warriorData, function () {
                        self.loadGame(selector, gameId);
                        $(this).addClass("defend-mode");
                    }, function (errData) {
                        self.reportError("#game-state", errData);
                        $(".first-warrior").removeClass("first-warrior");
                    });
                }
                else {
                    return;
                }
            });
        },
        reportError: function (selector, errData) {
            $("#error-message").remove();
            var message = JSON.parse(errData.responseText).Message;
            message = message != "" ? "Error! " + message + "!" : "Error!";
            // console.log(message);
            var html =
            '<div id="error-message">' +
            message +
            '</div>';
            $(selector).after(html);
            $("#error-message").fadeOut(3000);
        }
    });
    return {
        get: function () {
            return new Controller();
        }
    }
}());

$(function () {
    var controller = controllers.get();
    controller.loadUI("#content");
});