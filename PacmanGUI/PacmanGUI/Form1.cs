using EZInput;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacmanGUI
{
    public partial class Form1 : Form
    {
        PictureBox enemyBlack;
        PictureBox enemyBlue;
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*enemyBlack = createEnemy(SpaceShoterFramework.Properties.Resources.enemyBlack);
            enemyBlue = createEnemy(SpaceShoterFramework.Properties.Resources.enemyBlue);
            this.Controls.Add(enemyBlack);
            this.Controls.Add(enemyBlue);

            if (enemyBlackDirection == "MovingRight")
            {
                enemyBlack.Left = enemyBlack.Left + 10;
            }
            if (enemyBlackDirection == "MovingLeft")
            {
                enemyBlack.Left = enemyBlack.Left - 10;
            }
            if ((enemyBlack.Left + enemyBlack.Width) > this.Width)
            {
                enemyBlackDirection = "MovingLeft";
            }
            if (enemyBlack.Left <= 2)
            {
                enemyBlackDirection = "MovingRIght";
            }*/
        }

        private void TimeGameLoop_Tick(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                pbPlayerShip.Left = pbPlayerShip.Left + 25;
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                pbPlayerShip.Left = pbPlayerShip.Left - 25;
            }
            /*if (Keyboard.IsKeyPressed(Key.Space))
            {
                PictureBox pbFire = new PictureBox();
                Image fireImage = SpaceShoterFramework.Properties.Resources.LaserBlue01;
                pbFire.Image = fireImage;
                pbFire.Width = fireImage.Width;
                pbFire.Height = fireImage.Height;
                pbFire.BackColor = Color.Transparent;
                System.Drawing.Point fireLocation = new System.Drawing.Point();
                fireLocation.X = pbPlayerShip.Left + (pbPlayerShip.Width / 2) - 5;
                fireLocation.Y = pbPlayerShip.Top;
                pbFire.Location = fireLocation;
                playerFires.Add(pbFire);
                this.Controls.Add(pbFire);
            }
            if (Keyboard.IsKeyPressed(Key.Space))
            {
                Image fireImage= SpaceShoterFramework.Properties.Resources.LaserGreen01;
                PictureBox pbFire = createFire(fireImage, pbPlayerShip);
                playerFires.Add(pbFire);
                this.Controls.Add(pbFire);
            }
            
            foreach (PictureBox bullet in playerFires)
            {
                bullet.Top = bullet.Top - 20;
            }
            for (int idx = 0; idx < playerFires.Count; idx++)
            {
                if (playerFires[idx].Bottom < 0)
                {
                    playerFires.Remove(palyerFires[idx]);
                }
            }*/
        }
        private PictureBox createEnemy(Image img)
        {
            PictureBox pbEnemy = new PictureBox();
            int left = rand.Next(30, this.Width);
            int top = rand.Next(5, img.Height + 20);

            pbEnemy.Left = left;
            pbEnemy.Top = top;
            pbEnemy.Width = img.Width;
            pbEnemy.Height = img.Height;
            pbEnemy.BackColor = Color.Transparent;
            pbEnemy.Image = img;
            return pbEnemy;
        }
        private void moveEnemy(PictureBox enemy, ref string enemyDirection)
        {
            if (enemyDirection == "MovingRight")
            {
                enemy.Left = enemy.Left + 10;
            }
            if (enemyDirection == "MovingLeft")
            {
                enemy.Left = enemy.Left - 10;
            }
            if ((enemy.Left + enemy.Width) > this.Width)
            {
                enemyDirection = "MovingLeft";
            }
            if (enemy.Left <= 2)
            {
                enemyDirection = "MovingLeft";
            }
        }
        private PictureBox createFire(Image fireImage, PictureBox source)
        {
            PictureBox pbFire = new PictureBox();
            pbFire.Image = fireImage;
            pbFire.Width = fireImage.Width;
            pbFire.Height = fireImage.Height;
            pbFire.BackColor = Color.Transparent;
            System.Drawing.Point fireLocation;
            fireLocation = new System.Drawing.Point();
            fireLocation.X = source.Left + (source.Width / 2) - 5;
            fireLocation.Y = source.Top;
            pbFire.Location = fireLocation;
            return pbFire;
        }
    }
}
