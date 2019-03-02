using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris
{
    class Game
    {
        HashSet<Point> occupied = new HashSet<Point>();
        HashSet<Point> border;
        int width, height;
        string[] piece;
        Point piece_loc;
        int piece_rot;

        public bool Game_Over { get; private set; }

        public Game(int width, int height)
        {
            this.width = width;
            this.height = height;

            border = new HashSet<Point>(new[] {
                Horizontal_Border(height),
                Vertical_Border(-1),
                Vertical_Border(width) }.SelectMany(x => x));

            New_Piece();
        }

        IEnumerable<Point> Horizontal_Border(int y) => Enumerable.Range(-1, width + 1).Select(x => new Point(x, y));
        IEnumerable<Point> Vertical_Border(int x) => Enumerable.Range(-1, height + 1).Select(y => new Point(x, y));

        public void Render_Blocks(Action<Point> callback)
        {
            foreach (var o in occupied) callback(o);
            foreach (var p in Piece_points()) callback(p);
        }

        public void Left() => Move(-1);
        public void Right() => Move(+1);
        void Move(int offset)
        {
            piece_loc = piece_loc.Move(offset, 0);
            if (Check_Collision())
                piece_loc = piece_loc.Move(-offset, 0);
        }

        public void Drop()
        {
            while (!Check_Collision())
                piece_loc = piece_loc.Below;
            piece_loc = piece_loc.Above;
            Fall();
        }

        public void RotateRight() => Rotate(1);
        void Rotate(int offset) => piece_rot = (piece_rot + 1) % piece.Length;

        void New_Piece()
        {
            piece = Pieces.Normal.Pick_Random();
            piece_loc = new Point(width / 2, 0);
            piece_rot = 0;

            if (Check_Collision())
                Game_Over = true;
        }

        bool Check_Collision() =>
            Piece_points().Intersect(occupied).Any() ||
            Piece_points().Intersect(border).Any();

        IEnumerable<Point> Piece_points() => from x in Enumerable.Range(0, 4)
                                             from y in Enumerable.Range(0, 4)
                                             where piece[piece_rot][x + y * 4] != ' '
                                             select piece_loc.Move(x, y);

        public void Tick()
        {
            if (!Game_Over)
                Fall();
        }

        void Fall()
        {
            piece_loc = piece_loc.Below;

            if (Check_Collision())
            {
                piece_loc = piece_loc.Above;
                occupied = new HashSet<Point>(occupied.Concat(Piece_points()));

                Remove_full_lines();

                New_Piece();
            }
        }

        void Remove_full_lines()
        {
            var full_lines = (
                from y in Enumerable.Range(0, height)
                let points_in_line = Enumerable.Range(0, width).Select(x => new Point(x, y))
                where points_in_line.All(occupied.Contains)
                select y).ToArray();

            occupied = new HashSet<Point>(
                from o in occupied
                let removed_below = full_lines.Count(y => y > o.Y)
                where !full_lines.Contains(o.Y)
                select o.Move(0, removed_below));
        }
    }
}
