/// <reference path="../snake-game" />
/* 01. Finish the Unit Tests for MovingGameObject. */
describe("Moving Object", function () {
    var movingObject = {};
    var position = {
        x: 10,
        y: 10
    };
    var size = 15,
    speed = 5,
    direction = 0,
    piece;
    var fcolor = "#000000";
    var scolor = "#ffffff";

    beforeEach
    (function() {
        movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
    });

    describe("init", function() {
        it("Should set correct values", function() {
            expect(movingObject.position).toEqual(position);
            expect(movingObject.size).toBe(size);
            expect(movingObject.speed).toBe(speed);
            expect(movingObject.direction).toBe(direction);
            expect(movingObject.fcolor).toBe(fcolor);
            expect(movingObject.scolor).toBe(scolor);
        });
    });

    describe("move", function() {
        it("when direction is 0, should decrease x", function() {
            movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 0);
            movingObject.move();
            expect(movingObject.position.x).toBe(position.x - speed);
            expect(movingObject.position.y).toBe(position.y);
        });

        it("when direction is 1, should decrease y", function() {
            movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 1);
            movingObject.move();
            expect(movingObject.position.x).toBe(position.x);
            expect(movingObject.position.y).toBe(position.y - speed);
        });

        it("when direction is 2, should increase x", function() {
            movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 2);
            movingObject.move();
            expect(movingObject.position.x).toBe(position.x + speed);
            expect(movingObject.position.y).toBe(position.y);
        });

        it("when direction is 3, should increase y", function() {
            movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 3);
            movingObject.move();
            expect(movingObject.position.x).toBe(position.x);
            expect(movingObject.position.y).toBe(position.y + speed);
        });

        it("when direction is 2, should increase x, speed increased", function () {
            speed += 5;
            movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 2);
            movingObject.move();
            expect(movingObject.position.x).toBe(position.x + speed);
            expect(movingObject.position.y).toBe(position.y);
        });

        it("when direction is 3, should increase y, speed increased", function () {
            speed += 5;
            movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 3);
            movingObject.move();
            expect(movingObject.position.x).toBe(position.x);
            expect(movingObject.position.y).toBe(position.y + speed);
        });
    });

    describe("changeDirection", function () {
        describe("changeDirection when start direction is 0", function () {
            beforeEach(function () {
                movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 0);
            });

            it("when direction is 0, try change to 1", function () {
                movingObject.changeDirection(1);
                expect(movingObject.direction).toBe(1);
            });

            it("when direction is 0, try change to 2", function () {
                movingObject.changeDirection(2);
                // Shold not turn back.
                expect(movingObject.direction).toBe(0);
            });

            it("when direction is 0, try change to 3", function () {
                movingObject.changeDirection(3);
                expect(movingObject.direction).toBe(3);
            });

            it("when direction is 0, try change to 0", function () {
                movingObject.changeDirection(0);
                // Should not change.
                expect(movingObject.direction).toBe(0);
            });
        });
    
        describe("changeDirection when start direction is 1", function () {
            beforeEach(function () {
                movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 1);
            });

            it("when direction is 1, try change to 1", function () {
                movingObject.changeDirection(1);
                // Should not change.
                expect(movingObject.direction).toBe(1);
            });

            it("when direction is 1, try change to 2", function () {
                movingObject.changeDirection(2);
                expect(movingObject.direction).toBe(2);
            });

            it("when direction is 1, try change to 3", function () {
                movingObject.changeDirection(3);
                // Shold not turn back.
                expect(movingObject.direction).toBe(1);
            });

            it("when direction is 1, try change to 0", function () {
                movingObject.changeDirection(0);
                expect(movingObject.direction).toBe(0);
            });
        });

        describe("changeDirection when start direction is 2", function () {
            beforeEach(function () {
                movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 2);
            });

            it("when direction is 2, try change to 1", function () {
                movingObject.changeDirection(1);
                expect(movingObject.direction).toBe(1);
            });

            it("when direction is 2, try change to 2", function () {
                movingObject.changeDirection(2);
                // Should not change.
                expect(movingObject.direction).toBe(2);
            });

            it("when direction is 2, try change to 3", function () {
                movingObject.changeDirection(3);
                expect(movingObject.direction).toBe(3);
            });

            it("when direction is 2, try change to 0", function () {
                movingObject.changeDirection(0);
                // Shold not turn back.
                expect(movingObject.direction).toBe(2);
            });
        });

        describe("changeDirection when start direction is 3", function () {
            beforeEach(function () {
                movingObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 3);
            });

            it("when direction is 2, try change to 1", function () {
                movingObject.changeDirection(1);
                // Shold not turn back.
                expect(movingObject.direction).toBe(3);
            });

            it("when direction is 2, try change to 2", function () {
                movingObject.changeDirection(2);

                expect(movingObject.direction).toBe(2);
            });

            it("when direction is 2, try change to 3", function () {
                movingObject.changeDirection(3);
                // Should not change.
                expect(movingObject.direction).toBe(3);
            });

            it("when direction is 2, try change to 0", function () {
                movingObject.changeDirection(0);
                expect(movingObject.direction).toBe(0);
            });
        });
    });
});