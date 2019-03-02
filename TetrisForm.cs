using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tetris
{
    public partial class TetrisForm : Form
    {
        const int Block_Size = 20;
        Bitmap bitmap;
        Graphics graphics;
        Game game;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TetrisForm());
        }

        public TetrisForm()
        {
            InitializeComponent();

            bitmap = new Bitmap(200, 400);
            graphics = Graphics.FromImage(bitmap);
            game_image.Image = bitmap;

            New_Game();
        }

        void New_Game() => game = new Game(10, 20);

        void redraw_timer_Tick(object sender, EventArgs e)
        {
            game.Tick();
            Redraw();
        }

        void Redraw()
        {
            graphics.Clear(Color.White);
            game.Render_Blocks(Draw_Block);
            game_image.Refresh();
        }

        void Draw_Block(Point p) => graphics.FillRectangle(Brushes.Black, Block_Size * p.X, Block_Size * p.Y, Block_Size, Block_Size);

        void TetrisForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (game.Game_Over) New_Game();

            if (e.KeyCode == Keys.Left) game.Left();
            if (e.KeyCode == Keys.Right) game.Right();
            if (e.KeyCode == Keys.Up) game.RotateRight();
            if (e.KeyCode == Keys.Space) game.Drop();

            Redraw();
        }
    }
}
