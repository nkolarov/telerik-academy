/// <reference path="functions.js" />
describe("calculator", function() {
  describe("sum", function() {
    it("when 5 and 6, should return 11", function() {
      var a = 5;
      var b = 6;
      var actual = calculator.sum(a, b);
      expect(actual).toBe(11);      
    });
  });

  describe("substract", function() {
    it("when 5 and 6, should return -1", function() {
      var a = 5;
      var b = 6;
      var actual = calculator.substract(a, b);
      expect(actual).toBe(-1);
    });
  });

  describe("divide", function() {
    it("when 6 and 5, should return 1.2", function() {
      var a = 6;
      var b = 5;
      var actual = calculator.divide(a, b);
      expect(actual).toEqual(1.2);
    });

    it("when 5 and 0, should throw exception", function() {
      var a = 5;
      var b = 0;
      var divide = function(){
        return calculator.divide(a, b);
      }
      expect(divide).toThrow();      
    });
  });
  
  describe("multiply", function() {
    it(" when 5 and 0, should return 0", function() {
      var a = 5;
      var b = 0;
      var actual = calculator.multiply(a, b);
      expect(actual).toBe(0);
    });
    it("when 5 and 6, should return 30", function() {
      var a = 5;
      var b = 6;
      var actual = calculator.multiply(a, b);
      expect(actual).toBe(30);
    });
  });
});