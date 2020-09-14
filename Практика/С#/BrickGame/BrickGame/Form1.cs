using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace BrickGame
{
    public partial class Form1 : Form
    {
         const int width = 14, height = 25, k = 16; // Размеры поля и размер клетки в пикселях
         int[,] figure = new int[2, 4]; 
         int[,] field = new int[width, height]; // Массив для хранения поля
         Bitmap maps = new Bitmap(k * (width + 1) + 1, k * (height + 3) + 1);
        int lines;
        int score = 0;
        int newlines=1;
     
        int timer;
         Graphics gr; 

        public Form1()
        {
            InitializeComponent();
         
            
            gr = Graphics.FromImage(maps);
            for (int i = 0; i < width; i++)
                field[i, height - 1] = 1;
            for (int i = 0; i < height; i++)
            {
                field[0, i] = 1;
                field[width - 1, i] = 1;
            }
            GameTimer.Stop();
            SetFigure();


        }
       

        public void PlaySoundUp()
        {
            Assembly PathMusic = Assembly.GetExecutingAssembly();
            Stream ResourceStream = PathMusic.GetManifestResourceStream(@"BrickGame.Up.wav");
            SoundPlayer Up = new SoundPlayer(ResourceStream);
            Up.Play();
        }

        public void PlaySoundDown()
        {
            Assembly PathMusic = Assembly.GetExecutingAssembly();
            Stream ResourceStream = PathMusic.GetManifestResourceStream(@"BrickGame.Down.wav");
            SoundPlayer Down = new SoundPlayer(ResourceStream);
            Down.Play();
        }
        public void PlaySoundLeftOrRight()
        {
            Assembly PathMusic = Assembly.GetExecutingAssembly();
            Stream ResourceStream = PathMusic.GetManifestResourceStream(@"BrickGame.LeftAndRight.wav");
            SoundPlayer LeftOrRight = new SoundPlayer(ResourceStream);
            LeftOrRight.Play();
        }

        public void PlaySoundGameOver()
        {
            Assembly PathMusic = Assembly.GetExecutingAssembly();
            Stream ResourceStream = PathMusic.GetManifestResourceStream(@"BrickGame.GameOver.wav");
            SoundPlayer GameOver = new SoundPlayer(ResourceStream);
            GameOver.Play();
        }

        public void SetFigure()
        {
            Random rnd = new Random();
            switch (rnd.Next(1,7))
            { 
             case 1: figure = new int[,] { { 2, 3, 4, 5 }, { 8, 8, 8, 8 } }; break; // Палка
             case 2: figure = new int[,] { { 2, 3, 2, 3 }, { 8, 8, 9, 9 } }; break; // Квадрат
             case 3: figure = new int[,] { { 2, 3, 4, 4 }, { 8, 8, 8, 9 } }; break; // L
             case 4: figure = new int[,] { { 2, 3, 4, 4 }, { 8, 8, 8, 7 } }; break; 
             case 5: figure = new int[,] { { 3, 3, 4, 4 }, { 7, 8, 8, 9 } }; break;
             case 6: figure = new int[,] { { 3, 3, 4, 4 }, { 9, 8, 8, 7 } }; break;
             case 7: figure = new int[,] { { 3, 4, 4, 4 }, { 8, 7, 8, 9 } }; break;
           
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    for (int i = 0; i < 4; i++)
                    {
                        figure[1, i]--; // Сначала сдвигаем координаты всех кусочков фигуры на 1 влево по оси OX 
                    }
                    if (ExixtMistake())
                    {// Если после этого нашлась ошибка
                        for (int i = 0; i < 4; i++)
                        {
                            figure[1, i]++; // Возвращаем фигурку обратно на 1 вправо
                        }
                    }
                    PlaySoundLeftOrRight();
                    break;
                case Keys.Right:
                    for (int i = 0; i < 4; i++)
                    {
                        figure[1, i]++;
                    }
                    if (ExixtMistake())
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            figure[1, i]--;
                        }
                    }
                    PlaySoundLeftOrRight();
                    break;
                case Keys.Up:
                    var CopyFig = new int[2, 4];
                    Array.Copy(figure, CopyFig, figure.Length); 
                    int maxx = 0, maxy = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (figure[0, i] > maxy)
                            maxy = figure[0, i];
                        if (figure[1, i] > maxx)
                            maxx = figure[1, i];
                    } 
                    for (int i = 0; i < 4; i++)
                    {
                        int temp = figure[0, i];
                        figure[0, i] = maxy - (maxx - figure[1, i]) - 1;
                        figure[1, i] = maxx - (3 - (maxy - temp)) + 1;
                    } 
                    if (ExixtMistake())
                        Array.Copy(CopyFig, figure, figure.Length);
                    PlaySoundUp();
                    break;
                case Keys.Down: 
                    GameTimer.Interval = 60;
                    PlaySoundDown();
                    break;

            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (field[8, 3] == 1 )
            {
                PlaySoundGameOver();
               
                GameTimer.Stop();
                DialogResult result = MessageBox.Show("Вы проиграли", "Проигрыш", MessageBoxButtons.OK);

                if (result == DialogResult.OK)
                {

                    Application.Restart();
                    Environment.Exit(0);
                }
                 
            }
            if (lines==newlines)
            {
                PlaySoundGameOver();
                GameTimer.Stop();
                DialogResult result = MessageBox.Show("Вы выйграли", "Выйгрыш", MessageBoxButtons.OK);

                if (result == DialogResult.OK)
                {
                    Application.Restart();
                    Environment.Exit(0);
                }

            }
            for (int i = 0; i < 4; i++)
                figure[0, i]++; 
            if (ExixtMistake())
            {
                for (int i = 0; i < 4; i++)
                    field[figure[1, i], --figure[0, i]]++;
                SetFigure();
            } 
            for (int i = height - 2; i > 2; i--)
            {
                var cross = (from t in Enumerable.Range(0, field.GetLength(0)).Select(j => field[j, i]).ToArray() where t == 1 select t).Count(); // Количество заполненных полей в ряду
                if (cross == width)
                {
                     lines += 1;
                    score += 1000;
                    for (int k = i; k > 1; k--)
                    {
                        for (int l = 1; l < width - 1; l++)
                        {
                            field[l, k] = field[l, k - 1];
                        }
                    }

                    label1.Text = Convert.ToString(lines);
                    label4.Text = Convert.ToString(score);
                }
            } 

            DrawFigure(); 

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            GameTimer.Interval = timer;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(155, 165, 130);
            levels dificult = new levels();
            dificult.ShowDialog();
            if (dificult.DialogResult == DialogResult.OK)
            {
                timer = 225;
                newlines = 5;
                label6.Text = "EASY";
                label7.Text = Convert.ToString(newlines);
            }
            if (dificult.DialogResult == DialogResult.Yes)
            {
                timer = 180;
                newlines = 10;
                label6.Text = "MIDDLE";
                label7.Text = Convert.ToString(newlines);
            }
            if (dificult.DialogResult == DialogResult.Cancel)
            {
               
                Environment.Exit(0);
            }
            if (dificult.DialogResult == DialogResult.No)
            {
                timer = 155;
                newlines = 15;
                label6.Text = "Hard";
                label7.Text = Convert.ToString(newlines);
            }
            GameTimer.Interval = timer;
            PlaySoundGameOver();
            GameTimer.Start();
        }

        public void DrawFigure()
        {
            gr.Clear(Color.FromArgb(155, 165, 130)); //Очистим поле
            
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    if (field[i, j] == 1)
                    {
                        gr.FillRectangle(Brushes.Black, i * k, j * k, k, k);
                      
                    }
            for (int i = 0; i < 4; i++)
            { 
                gr.FillRectangle(Brushes.Black, figure[1, i] * k, figure[0, i] * k, k, k);

            }
            GameMap.Image = maps;
        }
        public bool ExixtMistake()
        {
            for (int i = 0; i < 4; i++)
            {
                if (figure[1, i] >= width || figure[0, i] >= height ||
                    figure[1, i] <= 0 || figure[0, i] <= 0 ||
                    field[figure[1, i], figure[0, i]] == 1)
                    return true;
            }
            return false;
        }



    }
}
