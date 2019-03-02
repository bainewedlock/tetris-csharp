namespace Tetris
{
    struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public Point Below => new Point(X, Y + 1);
        public Point Above => new Point(X, Y - 1);
        public override string ToString() => $"{X}.{Y}";
        public Point Move(int x, int y) => new Point(x + X, y + Y);
    }
}
