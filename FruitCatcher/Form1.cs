using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace FruitCatcher
{
    public partial class Form1 : Form
    {
        private Player player;
        private List<Fruit> fruits = new List<Fruit>();
        private Random random = new Random();
        private int score = 0;
        private int lives = 3;
        private int fruitsCaught = 0;
        private int fallSpeed = 3;
        private Timer gameTimer;
        private GameMode selectedMode;
        private Timer countdownTimer;
        private int timeRemaining = 60;

        public Form1(GameMode mode) : this()
        {
            selectedMode = mode;
            InitializeMode();
        }

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Width = 600;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            gameTimer = new Timer();
            gameTimer.Interval = 30;
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            this.MouseMove += Form1_MouseMove;
        }


        private void InitializeMode()
        {
            if (selectedMode == GameMode.Standard)
            {
                this.Text = "Fruit Catcher - Standard Mode";
                countdownTimer = new Timer();
                countdownTimer.Interval = 1000;
                countdownTimer.Tick += CountdownTimer_Tick;
                countdownTimer.Start();
            }
            else if (selectedMode == GameMode.Poison)
            {
                this.Text = "Fruit Catcher - Poison Mode";
                timeRemaining = -1;
            }
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            timeRemaining--;
            if (timeRemaining <= 0)
            {
                EndGame();
            }
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(
                this.ClientRectangle,
                Color.MediumOrchid,
                Color.DarkMagenta,
                LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player = new Player(this.Width / 2, this.Height - 100, 40);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            player.MoveTo(e.X);
            this.Invalidate();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {
          
        }

        private void GameLoop(object sender, EventArgs e)
        {
            // 1. Движење на сите овошки и обработка на судири со играчот или излегување од таблата
            foreach (var fruit in fruits.ToList())
            {
                fruit.MoveDown(fallSpeed); // Овошката се движи надолу со моменталната брзина

                // Проверка дали овошката се судрила со играчот
                if (fruit.Bounds.IntersectsWith(player.Bounds))
                {
                    if (fruit.Type == FruitType.Good)
                    {
                        score += 1;        // Зголеми поени за фатена добра овошка
                        fruitsCaught++;    // Зголеми број на фатени овошки
                        if (fruitsCaught % 10 == 0)
                        {
                            fallSpeed++;   // На секои 10 фатени овошки, зголеми ја брзината на паѓање
                        }
                    }
                    else if (selectedMode == GameMode.Poison)
                    {
                        lives -= 1;       // Во Poison mode, лоша овошка одзема живот
                    }
                    fruits.Remove(fruit);  // Овошката се отстранува од листата (фатена или погодена)
                }
                // Проверка дали овошката излегла надвор од екранот
                else if (fruit.Bounds.Top > this.Height)
                {
                    if (fruit.Type == FruitType.Good && selectedMode == GameMode.Poison)
                        lives--;          // Во Poison mode, пропуштена добра овошка одзема живот
                    fruits.Remove(fruit); // Секогаш се отстранува од листата ако излезе од екранот
                }
            }

            // 2. Генерирање на нова овошка со одредена веројатност
            if (random.Next(0, 20) == 0)
            {
                int x = random.Next(0, this.Width - 30);
                FruitType type = random.Next(0, 5) == 0 ? FruitType.Bad : FruitType.Good;

                // Во Standard mode, секогаш се генерира добра овошка
                if (selectedMode == GameMode.Standard)
                {
                    type = FruitType.Good;
                }

                // Дефинирање на боја според типот на овошка
                Brush color;
                if (type == FruitType.Good)
                {
                    Color randomColor = Color.FromArgb(
                        random.Next(100, 256),
                        random.Next(100, 256),
                        random.Next(100, 256)
                    );
                    color = new SolidBrush(randomColor);
                }
                else
                {
                    color = Brushes.Black;
                }

                // Случаен избор на форма
                ShapeType shape = (ShapeType)random.Next(0, 3);
                Rectangle newBounds;
                bool overlaps;
                // Проверка дали новата овошка се преклопува со други на врвот
                do
                {
                    x = random.Next(0, this.Width - 30);
                    newBounds = new Rectangle(x, 0, 30, 30);
                    overlaps = fruits.Any(f => Math.Abs(f.Bounds.X - x) < 35 && f.Bounds.Y < 60);
                }
                while (overlaps);
                fruits.Add(new Fruit(newBounds, color, type, shape)); // Додавање на нова овошка во листата
            }

            // 3. Проверка за крај на играта во зависност од режимот
            if (selectedMode == GameMode.Poison && lives <= 0)
            {
                EndGame(); // Ако се изгубат сите животи во Poison mode, играта завршува
                return;
            }

            if (selectedMode == GameMode.Standard && timeRemaining <= 0)
            {
                EndGame(); // Ако истече времето во Standard mode, играта завршува
                return;
            }

            // 4. Ажурирање на статус лентата со поени и време/животи
            toolStripStatusLabel1.Text = $"Points: {score}";
            toolStripStatusLabel2.Text = selectedMode == GameMode.Standard
                ? $"Time: {timeRemaining}s"
                : $"Lives: {lives}";

            // 5. Освежување на формата
            this.Invalidate();
        }


        private void EndGame()
        {
            gameTimer.Stop();
            if (countdownTimer != null) countdownTimer.Stop();

            this.Hide();
            GameOverForm gameOver = new GameOverForm(score, selectedMode, fruitsCaught, timeRemaining);
            gameOver.FormClosed += (s, args) => this.Close();
            gameOver.Show();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.FillEllipse(Brushes.Blue, player.Bounds);
            foreach (var fruit in fruits)
            {
                fruit.Draw(e.Graphics);
            }
        }
    }
}
