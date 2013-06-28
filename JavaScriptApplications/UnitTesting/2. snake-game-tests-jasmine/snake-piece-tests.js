/// <reference path="../snake-game" />
describe("SnakePiece", function () {
  var position = {
    x: 150,
    y: 150
  };
  var size = 15,
    speed = 5,
    direction = 0,
    piece;

  beforeEach(function() {
    piece = new snakeGame.SnakePiece(position, size, speed, direction);
  });

  describe("init", function() {
    it("Should set correct values", function() {
      expect(piece.position).toEqual(position);
      expect(piece.size).toBe(size);
      expect(piece.speed).toBe(speed);
      expect(piece.direction).toBe(direction);
    });
  });

  describe("move", function() {
    it("when direction is 0, should decrease x", function() {
      piece = new snakeGame.SnakePiece(position, size, speed, 0);
      piece.move();
      expect(piece.position.x).toBe(position.x - speed);
      expect(piece.position.y).toBe(position.y);
    });

    it("when direction is 1, should decrease y", function() {
      piece = new snakeGame.SnakePiece(position, size, speed, 1);
      piece.move();
      expect(piece.position.x).toBe(position.x);
      expect(piece.position.y).toBe(position.y - speed);
    });

    it("when direction is 2, should increase x", function() {
      piece = new snakeGame.SnakePiece(position, size, speed, 2);
      piece.move();
      expect(piece.position.x).toBe(position.x + speed);
      expect(piece.position.y).toBe(position.y);
    });
    it("when direction is 3, should increase y", function() {
      piece = new snakeGame.SnakePiece(position, size, speed, 3);
      piece.move();
      expect(piece.position.x).toBe(position.x);
      expect(piece.position.y).toBe(position.y + speed);
    });
  });
});