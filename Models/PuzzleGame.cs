using System.Collections.Generic;
using System.Linq;

namespace BanglaConsonantPuzzle.Models
{
    public class PuzzleGame
    {
        public static readonly string[] BanglaConsonants =
        {
            "ক","খ","গ","ঘ","ঙ",
            "চ","ছ","জ","ঝ","ঞ",
            "ট","ঠ","ড","ঢ","ণ",
            "ত","থ","দ","ধ","ন",
            "প","ফ","ব","ভ","ম",
            "য","র","ল","শ","ষ",
            "স","হ","ড়","ঢ়","য়",
            "ৎ","ং","ঃ","ঁ"
        };

        public const int Rows = 9;
        public const int Cols = 5;
        public const string Empty = "";

        // 45 cells: 39 consonants + 6 blanks
        public List<string> Board { get; set; } = new();
        public bool IsSolved { get; set; }

        public static List<string> GetSolvedBoard()
        {
            var b = new List<string>(BanglaConsonants);
            for (int i = 0; i < 6; i++) b.Add(Empty);
            return b;
        }

        public static List<string> GetShuffledBoard()
        {
            var b = GetSolvedBoard();
            var rng = new System.Random();
            do
            {
                for (int i = b.Count - 1; i > 0; i--)
                {
                    int j = rng.Next(i + 1);
                    (b[i], b[j]) = (b[j], b[i]);
                }
            } while (CheckSolved(b));
            return b;
        }

        public static bool CheckSolved(List<string> board)
        {
            var solved = GetSolvedBoard();
            return board.SequenceEqual(solved);
        }
    }
}
