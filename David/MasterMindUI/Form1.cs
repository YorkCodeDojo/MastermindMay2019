using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMindUI
{
    public partial class Form1 : Form
    {
        private readonly Brush BlackBrush = new SolidBrush(Color.Black);
        private readonly Brush WhiteBrush = new SolidBrush(Color.White);

        private readonly Pen GreyLinePen = new Pen(Color.FromArgb(184, 184, 184));

        private readonly Brush RedBrush = new SolidBrush(Color.Red);
        private readonly Brush BlueBrush = new SolidBrush(Color.Blue);
        private readonly Brush GreenBrush = new SolidBrush(Color.Green);
        private readonly Brush YellowBrush = new SolidBrush(Color.Yellow);
        private readonly Brush PurpleBrush = new SolidBrush(Color.Purple);
        private readonly Brush OrangeBrush = new SolidBrush(Color.Orange);

        private int GuessNumber = 0;
        private Combination _target;

        public Form1()
        {
            InitializeComponent();

            var rnd = new Random();
            _target = new Combination(rnd.Next(1, 7), rnd.Next(1, 7), rnd.Next(1, 7), rnd.Next(1, 7));
        }

        private void DrawEmptyGuesses()
        {
            using (var g = panel1.CreateGraphics())
            {
                for (int i = 0; i < 10; i++)
                {
                    g.DrawEllipse(GreyLinePen, 100, 100 + (i * 50), 30, 30);
                    g.DrawEllipse(GreyLinePen, 150, 100 + (i * 50), 30, 30);
                    g.DrawEllipse(GreyLinePen, 200, 100 + (i * 50), 30, 30);
                    g.DrawEllipse(GreyLinePen, 250, 100 + (i * 50), 30, 30);
                }
            }
        }

        private void CmdGuess_Click(object sender, EventArgs e)
        {

            var guess = CombinationFromGuess();

            var scorer = new Scorer();
            var score = scorer.ScoreGuess(_target, guess);


            DrawEmptyGuesses();

            var y = 100 + (GuessNumber * 50);

            using (var g = panel1.CreateGraphics())
            {
                g.FillEllipse(BrushFromText(cbPeg1.Text), 100, y, 30, 30);
                g.FillEllipse(BrushFromText(cbPeg2.Text), 150, y, 30, 30);
                g.FillEllipse(BrushFromText(cbPeg3.Text), 200, y, 30, 30);
                g.FillEllipse(BrushFromText(cbPeg4.Text), 250, y, 30, 30);

                DisplayScore(y, g, score);
            }

            if (score.Correct == 4)
            {
                MessageBox.Show("You won!", "Well Done");
            }

            GuessNumber++;
        }

        private Combination CombinationFromGuess()
        {
            return new Combination(
                PegNumberFromText(cbPeg1.Text),
                PegNumberFromText(cbPeg2.Text),
                PegNumberFromText(cbPeg3.Text),
                PegNumberFromText(cbPeg4.Text)
                );
        }

        private void DisplayScore(int y, Graphics g, Score score)
        {
            var whiteLeft = score.Correct;
            var blackLeft = score.WrongPosition;

            void NextBrush(int x, int yOffset)
            {
                if (whiteLeft > 0)
                {
                    whiteLeft--;
                    g.FillEllipse(WhiteBrush, x, y + yOffset, 10, 10);
                }
                else if (blackLeft > 0)
                {
                    blackLeft--;
                    g.FillEllipse(BlackBrush, x, y + yOffset, 10, 10);
                }
            }

            NextBrush(300, 0);
            NextBrush(320, 0);
            NextBrush(300, 20);
            NextBrush(320, 20);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var colours = new[] { "Red", "Blue", "Green", "Yellow", "Purple", "Orange" };
            cbPeg1.Items.AddRange(colours);
            cbPeg2.Items.AddRange(colours);
            cbPeg3.Items.AddRange(colours);
            cbPeg4.Items.AddRange(colours);

            cbPeg1.Text = "Red";
            cbPeg2.Text = "Red";
            cbPeg3.Text = "Red";
            cbPeg4.Text = "Red";
        }

        private int PegNumberFromText(string text)
        {
            switch (text)
            {
                case "Red":
                    return 1;

                case "Blue":
                    return 2;

                case "Green":
                    return 3;

                case "Yellow":
                    return 4;

                case "Purple":
                    return 5;

                case "Orange":
                    return 6;

                default:
                    throw new Exception("Unknown peg colour " + text);
            }
        }
        private Brush BrushFromText(string text)
        {
            switch (text)
            {
                case "Red":
                    return RedBrush;

                case "Blue":
                    return BlueBrush;

                case "Green":
                    return GreenBrush;

                case "Yellow":
                    return YellowBrush;

                case "Purple":
                    return PurpleBrush;

                case "Orange":
                    return OrangeBrush;

                default:
                    throw new Exception("Unknown peg colour " + text);
            }
        }
    }
}
