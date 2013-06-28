/// <reference path="../snake-game" />
/* 05. Test the Food contructor. */
describe("Food", function () {
    var position = {
        x: 100,
        y: 100
    };
    var size = 10;

    beforeEach
    (function() {
        food = new snakeGame.Food(position, size);
    });

    describe("init", function() {
        it("Should set correct values", function() {
            expect(food.position.x).toEqual(position.x);
            expect(food.position.y).toEqual(position.y);
            expect(food.size).toEqual(size);
        });
    });

    describe("changePosition", function() {
        it("should be correctly moved", function () {
            var newPosition = {
                x: 50,
                y:50
            };
            food.changePosition(newPosition);
            expect(food.position.x).toEqual(newPosition.x);
            expect(food.position.y).toEqual(newPosition.y);
            expect(food.size).toEqual(size);
        });
    });
});