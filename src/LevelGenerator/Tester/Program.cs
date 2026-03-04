using System;
using LevelGenerator;

class Program
{
    static int Main(string[] args)
    {
        if (args.Length >= 1 && args[0].Equals("check", StringComparison.OrdinalIgnoreCase))
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Usage: check <size> <tiles-comma-separated> <blankRow,blankCol>");
                return 2;
            }
            int size = int.Parse(args[1]);
            var tilesList = args[2].Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
            var numbers = new System.Collections.Generic.List<int>();
            foreach (var t in tilesList) numbers.Add(int.Parse(t.Trim()));
            var rc = args[3].Split(',');
            int br = int.Parse(rc[0]) - 1; 
            int bc = int.Parse(rc[1]) - 1;

            int[,] board = new int[size, size];
            int idx = 0;
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    if (r == br && c == bc)
                    {
                        board[r, c] = 0;
                    }
                    else
                    {
                        if (idx >= numbers.Count) { Console.WriteLine("Not enough tile numbers provided"); return 3; }
                        board[r, c] = numbers[idx++];
                    }
                }
            }

            var gen = new PuzzleGenerator();
            bool solv = gen.IsSolvable(board);
            int inversions = 0;
            var flat = new System.Collections.Generic.List<int>();
            int blankRow = -1;
            for (int r = 0; r < size; r++)
            {
                for (int c = 0; c < size; c++)
                {
                    int v = board[r, c];
                    if (v == 0) blankRow = r;
                    else flat.Add(v);
                }
            }
            for (int i = 0; i < flat.Count; i++) for (int j = i+1; j < flat.Count; j++) if (flat[i] > flat[j]) inversions++;
            int rowFromBottom = size - blankRow;
            Console.WriteLine($"Inversions: {inversions}");
            Console.WriteLine($"Blank row from bottom: {rowFromBottom}");
            Console.WriteLine($"Sum: {inversions + rowFromBottom}");
            Console.WriteLine($"Solved by IsSolvable: {solv}");
            return solv ? 0 : 1;
        }

        int sizeDefault = 4;
        int triesDefault = 100;
        int size2 = sizeDefault;
        int tries2 = triesDefault;
        if (args.Length >= 1 && int.TryParse(args[0], out var parsed)) tries2 = parsed;
        if (args.Length >= 2 && int.TryParse(args[1], out var s2)) size2 = s2;

        var gen2 = new PuzzleGenerator();
        int bad = 0;
        for (int i = 0; i < tries2; i++)
        {
            var board = gen2.GeneratePuzzle(size2);
            if (!gen2.IsSolvable(board))
            {
                bad++;
                Console.WriteLine($"Unsolvable detected on iteration {i}");
            }
        }

        Console.WriteLine($"Checked {tries2} puzzles of size {size2}x{size2}, unsolvable: {bad}");
        return bad == 0 ? 0 : 1;
    }
}
