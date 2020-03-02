using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Asteroidgame
{
    class Program
    {
        static void Main(string[] args)
        {
            Form menu = new Form();
            menu.Width = 800;
            menu.Height = 600;


            SplashScreen.Init(menu);
            menu.Show();
            SplashScreen.Draw();

            Button startBtn = new Button
            {
                Text = "Играть",
                Location = new System.Drawing.Point(menu.Width / 2 - 30, menu.Height / 3)

            };
            startBtn.Click += startBtnClick;
            menu.Controls.Add(startBtn);

            Button recordsBtn = new Button
            {
                Text = "Рекорды",
                Location = new System.Drawing.Point(menu.Width / 2 - 30, menu.Height - menu.Height / 2)

            };
            recordsBtn.Click += recordsBtnClick;
            menu.Controls.Add(recordsBtn);

            Button exitBtn = new Button
            {
                Text = "Выход",
                Location = new System.Drawing.Point(menu.Width / 2 - 30, menu.Height - menu.Height / 3)

            };
            exitBtn.Click += exitBtnClick;
            menu.Controls.Add(exitBtn);

            Label autor = new Label
            {
                Text = "Сергей Ткачёв © " + DateTime.Now.Year.ToString(),
                ForeColor = System.Drawing.Color.White,
                BackColor = System.Drawing.Color.Black,
                AutoSize = true,
                Font = new Font("Arial", 14, FontStyle.Bold),
                Location = new System.Drawing.Point(menu.Width / 10, menu.Height - menu.Height / 6)

            };
            menu.Controls.Add(autor);

            Application.Run(menu);


            void exitBtnClick(object sender, EventArgs e)
            {
                menu.Close();
            }

            void recordsBtnClick(object sender, EventArgs e) { }

            void startBtnClick(object sender, EventArgs e)
            {
                Form game = new Form()
                {
                    Width = (Screen.PrimaryScreen.Bounds.Width / 10) * 9,
                    Height = (Screen.PrimaryScreen.Bounds.Height / 10) * 9
                };
                //game.Width = 800;
                //game.Height = 600;
                Game.Init(game);
                game.FormClosed += Game_FormClosed;
                game.Show();
                Game.Draw();
            }
        }

        /// <summary>Метод остановки таймера и отписки от него при закрытии формы</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            Game.Closed();
        }
    }

}
