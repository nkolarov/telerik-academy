01. Write a recursive program that simulates the execution of n nested loops from 1 to n. Examples:
                           1 1 1
                           1 1 2
                           1 1 3
         1 1               1 2 1
n=2  ->  1 2      n=3  ->  ...
         2 1               3 2 3
         2 2               3 3 1
                           3 3 2
                           3 3 3
02. Write a recursive program for generating and printing all the combinations with duplicates of k elements from n-element set. Example:
	n=3, k=2 ? (1 1), (1 2), (1 3), (2 2), (2 3), (3 3)
03. Modify the previous program to skip duplicates:
	n=4, k=2 ? (1 2), (1 3), (1 4), (2 3), (2 4), (3 4)
04. Write a recursive program for generating and printing all permutations of the numbers 1, 2, ..., n for given integer number n. Example:
	n=3 ? {1, 2, 3}, {1, 3, 2}, {2, 1, 3},					{2, 3, 1}, {3, 1, 2},{3, 2, 1}
05. Write a recursive program for generating and printing all ordered k-element subsets from n-element set (variations Vkn).
	Example: n=3, k=2, set = {hi, a, b} =>
	(hi hi), (hi a), (hi b), (a hi), (a a), (a b), (b hi), (b a), (b b)
06. Write a program for generating and printing all subsets of k strings from given set of strings.
	Example: s = {test, rock, fun}, k=2
	(test rock),  (test fun),  (rock fun)
07. We are given a matrix of passable and non-passable cells. Write a recursive program for finding all paths between two cells in the matrix.
08. Modify the above program to check whether a path exists between two cells without finding all possible paths. Test it over an empty 100 x 100 matrix.
09. Write a recursive program to find the largest connected area of adjacent empty cells in a matrix.