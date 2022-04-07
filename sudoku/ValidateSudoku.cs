/* TAKES A 9x9 ARRAY AND CHECKS IF IT IS A VALID SUDOKU
 *
 * Returns: -1 .. Input not valid
 *           0 .. Input valid, but no valid sudoku
 *           1 .. Valid sudoku
 *
 * Input should look like the following:
 * int[][] test = new int[][]
 * {
 *   new int[] {5, 3, 4, 6, 7, 8, 9, 1, 2},
 *   new int[] {6, 7, 2, 1, 9, 5, 3, 4, 8},
 *   new int[] {1, 9, 8, 3, 4, 2, 5, 6, 7},
 *   new int[] {8, 5, 9, 7, 6, 1, 4, 2, 3},
 *   new int[] {4, 2, 6, 8, 5, 3, 7, 9, 1},
 *   new int[] {7, 1, 3, 9, 2, 4, 8, 5, 6},
 *   new int[] {9, 6, 1, 5, 3, 7, 2, 8, 4},
 *   new int[] {2, 8, 7, 4, 1, 9, 6, 3, 5},
 *   new int[] {3, 4, 5, 2, 8, 6, 1, 7, 9},
 * };
 */

public int ValidateSudoku(int[][] board)
{
    // Validate input
    if (board.Count() != 9 || board.Where(i => i.Count() != 9).Count() > 0) return -1;
    if (board.Where(i => i.Where(v => v < 1 || v > 9).Count() > 0).Count() > 0) return -1;

    // Validate rows
    if (board.Where(i => i.Sum() != 45).Count() > 0) return 0;

    // Validate columns
    for(int i = 0; i < 9; i++)
    {
        int count = 0;
        for(int j = 0; j < 9; j++)
        {
            count += board[j][i];
        }
        if (count != 45) return 0;
    }

    // Validate grids
    for(int i = 0; i < 9; i++)
    {
        int count = 0;
        for(int j = 0; j < 3; j++)
        {
            count += i % 3 == 0 ? board[j + (i < 3 ? 0 : i < 6 ? 3 : 6)].Take(3).Sum() 
                : i % 3 == 1 ? board[j + (i < 3 ? 0 : i < 6 ? 3 : 6)].Skip(3).Take(3).Sum() 
                : board[j + (i < 3 ? 0 : i < 6 ? 3 : 6)].Skip(6).Take(3).Sum();
        }
        Console.WriteLine(count);
        if (count != 45) return 0;
    }

    return 1;
}
