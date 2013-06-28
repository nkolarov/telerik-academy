/// <reference path="../snake-game" />
/* 02. Finish the tests for Snake. */
describe("Snake", function () {
    var snake;
    var position = {
        x: 150,
        y: 150
    };
    var speed = 15;
    var direction = 0;

    beforeEach(function() {
        snake = new snakeGame.Snake(position, speed, direction);
    });

    describe("init", function() {
        it("Should set correct values", function() {
            expect(snake.position.x).toEqual(position.x);
            expect(snake.speed).toBe(speed);
            expect(snake.direction).toBe(direction);
        });

        it("Should contain 5 SnakePieces", function() {
            expect(snake.pieces).toBeTruthy();
            expect(snake.pieces.length).toBe(5);
            expect(snake.head).toBeTruthy();
        });
    })

    describe("consume", function() {
        it("When object is food, should grow", function() {
            var snakeSize = snake.size;
            snake.consume(new snakeGame.Food());
            expect(snake.size).toBe(snakeSize + 1);
        });

        it("When object is Obstacle, should die", function() {
            var isDead = false;
            snake.addDieHandler(function() {
                isDead = true;
            });

            snake.consume(new snakeGame.Obstacle());
            expect(isDead).toBeTruthy();
        });

        it("When object is Snake Piece, should die", function () {
            var isDead = false;
            snake.addDieHandler(function () {
                isDead = true;
            });

            snake.consume(new snakeGame.SnakePiece());
            expect(isDead).toBeTruthy();
        });
    });

    describe("changeDirection", function() {
        describe("when direction is 0", function() {
            beforeEach(function() {
                snake = new snakeGame.Snake(position, speed, 0);
            });

            it("new direction is 0, should set direction to 0", function() {
                snake.changeDirection(0);
                expect(snake.head.direction).toBe(0);
            });
            it("new direction is 1, should set direction to 1", function() {
                snake.changeDirection(1);
                expect(snake.head.direction).toBe(1);
            });
            it("new direction is 2, should set direction to 0", function() {
                snake.changeDirection(2);
                expect(snake.head.direction).toBe(0);
            });
            it("new direction is 3, should set direction to 3", function() {
                snake.changeDirection(3);
                expect(snake.head.direction).toBe(3);
            });
        });

        describe("when direction is 1", function() {
            beforeEach(function() {
                snake = new snakeGame.Snake(position, speed, 1);
            });

            it("new direction is 0, should set direction to 0", function() {
                snake.changeDirection(0);
                expect(snake.head.direction).toBe(0);
            });
            it("new direction is 1, should set direction to 1", function() {
                snake.changeDirection(1);
                expect(snake.head.direction).toBe(1);
            });
            it("new direction is 2, should set direction to 2", function() {
                snake.changeDirection(2);
                expect(snake.head.direction).toBe(2);
            });
            it("new direction is 3, should set direction to 1", function() {
                snake.changeDirection(3);
                expect(snake.head.direction).toBe(1);
            });
        });

        describe("when direction is 2", function() {
            beforeEach(function() {
                snake = new snakeGame.Snake(position, speed, 2);
            });

            it("new direction is 0, should set direction to 2", function() {
                snake.changeDirection(0);
                expect(snake.head.direction).toBe(2);
            });
            it("new direction is 1, should set direction to 1", function() {
                snake.changeDirection(1);
                expect(snake.head.direction).toBe(1);
            });
            it("new direction is 2, should set direction to 2", function() {
                snake.changeDirection(2);
                expect(snake.head.direction).toBe(2);
            });
            it("new direction is 3, should set direction to 3", function() {
                snake.changeDirection(3);
                expect(snake.head.direction).toBe(3);
            });
        });

        describe("when direction is 3", function() {
            beforeEach(function() {
                snake = new snakeGame.Snake(position, speed, 3);
            });

            it("new direction is 0, should set direction to 0", function() {
                snake.changeDirection(0);
                expect(snake.head.direction).toBe(0);
            });
            it("new direction is 1, should set direction to 3", function() {
                snake.changeDirection(1);
                expect(snake.head.direction).toBe(3);
            });
            it("new direction is 2, should set direction to 2", function() {
                snake.changeDirection(2);
                expect(snake.head.direction).toBe(2);
            });
            it("new direction is 3, should set direction to 3", function() {
                snake.changeDirection(3);
                expect(snake.head.direction).toBe(3);
            });
        });
    });

    describe("move", function () {
        it("when direction is 0", function () {
            snake = new snakeGame.Snake(position, speed, 0);
            snake.move();
            expect(snake.position.x).toBe(position.x - (speed));
            expect(snake.position.y).toBe(position.y);
        });

        it("when direction is 1", function () {
            snake = new snakeGame.Snake(position, speed, 1);
            snake.move();
            expect(snake.position.x).toBe(position.x);
            expect(snake.position.y).toBe(position.y - (speed));
        });

        it("when direction is 2", function () {
            snake = new snakeGame.Snake(position, speed, 2);
            snake.move();
            expect(snake.position.x).toBe(position.x + (speed));
            expect(snake.position.y).toBe(position.y);
        });

        it("when direction is 3", function () {
            snake = new snakeGame.Snake(position, speed, 3);
            snake.move();
            expect(snake.position.x).toBe(position.x);
            expect(snake.position.y).toBe(position.y + (speed));
        });
    });

    describe("grow", function () {
        it("grow once", function () {
            snake = new snakeGame.Snake(position, speed, 0);
            snake.grow();
            expect(snake.pieces.length).toBe(6);
        });

        it("grow 5 times", function () {
            snake = new snakeGame.Snake(position, speed, 0);
            for (var i = 0; i < 5; i++) {
                snake.grow();
            }
            expect(snake.pieces.length).toBe(10);
        });
    });

    describe("checkSelfConsume", function () {
        it("the snake dies", function () {
            snake = new snakeGame.Snake(position, speed, 0);

            snake.pieces[1].position.x = position.x;
            snake.pieces[1].position.y = position.y;

            var isDead = false;

            snake.addDieHandler(function () {
                isDead = true;
            });

            snake.checkSelfConsume();
            expect(isDead).toBeTruthy();
        });
    });
});