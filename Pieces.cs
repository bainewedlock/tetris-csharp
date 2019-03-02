using System;

namespace Tetris
{
    static class Pieces
    {
        static readonly Random rand = new Random();

        public static T Pick_Random<T>(this T[] items) => items[rand.Next(items.Length)];

        public static readonly string[][] Normal = new string[][]
        {
            new[] { " #  " +
                    "### " +
                    "    " +
                    "    " ,

                    " #  " +
                    " ## " +
                    " #  " +
                    "    " ,

                    "    " +
                    "### " +
                    " #  " +
                    "    " ,

                    " #  " +
                    "##  " +
                    " #  " +
                    "    " },

            new[] { "  # " +
                    "### " +
                    "    " +
                    "    " ,

                    " #  " +
                    " #  " +
                    " ## " +
                    "    " ,

                    "    " +
                    "### " +
                    "#   " +
                    "    " ,

                    "##  " +
                    " #  " +
                    " #  " +
                    "    " },

            new[] { "#   " +
                    "### " +
                    "    " +
                    "    " ,

                    " ## " +
                    " #  " +
                    " #  " +
                    "    " ,

                    "    " +
                    "### " +
                    "  # " +
                    "    " ,

                    " #  " +
                    " #  " +
                    "##  " +
                    "    " },

            new[] { "    " +
                    "##  " +
                    " ## " +
                    "    " ,

                    "  # " +
                    " ## " +
                    " #  " +
                    "    "},

            new[] { "    " +
                    " ## " +
                    "##  " +
                    "    " ,

                    "#   " +
                    "##  " +
                    " #  " +
                    "    "},

            new[] { " #  " +
                    " #  " +
                    " #  " +
                    " #  " ,

                    "    " +
                    "####" +
                    "    " +
                    "    "},

            new[] { "    " +
                    " ## " +
                    " ## " +
                    "    " },
        };
    }
}
