﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GalaxyConquest
{
    public partial class Tech_Tree : Form
    {
        public Bitmap TechTreeBitmap;

        public float scaling = 1f;
        public int horizontal = 0;
        public int vertical = 0;

        public int mouseX;
        public int mouseY;

        public Tech_Tree()
        {
            InitializeComponent();
            Redraw();
        }

        private void Redraw()
        {
            TechTreeBitmap = new Bitmap(TechTreeImage.Width, TechTreeImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            Graphics g = Graphics.FromImage(TechTreeBitmap);

            float centerX = TechTreeBitmap.Width / 2 / scaling;
            float centerY = TechTreeBitmap.Height / 2 / scaling;

            centerX += horizontal;
            centerY += vertical;

            g.ScaleTransform(scaling, scaling);

            g.DrawString("Обработка металлов.", new Font("Arial", 10.0F), Brushes.White, new PointF(centerX - 80, centerY + 50));
            g.DrawString("Добыча полезных\n ископаемых.", new Font("Arial", 10.0F), Brushes.White, new PointF(centerX - 120, centerY + 100));
            g.DrawString("Обработка металлов.", new Font("Arial", 10.0F), Brushes.White, new PointF(centerX + 20, centerY + 100));

            TechTreeImage.Image = TechTreeBitmap;
            TechTreeImage.Refresh();
        }


        private void TechTreeImage_MouseDown(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
        }

        private void TechTreeImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int dx = mouseX - e.X;
                int dy = mouseY - e.Y;
                if (dx > 0)
                {
                    horizontal -= (5+(int)(1/scaling)*10);
                }
                if (dx < 0)
                {
                    horizontal += (5+(int)(1/scaling)*10);
                }
                if (dy > 0)
                {
                    vertical -= (5+(int)(1/scaling)*10);
                }
                if (dy < 0)
                {
                    vertical += (5+(int)(1/scaling)*10);
                }
                mouseX = e.X;
                mouseY = e.Y;
                Redraw();
            }
        }

        private void Tech_Tree_Resize(object sender, EventArgs e)
        {
            Redraw();
        }

        private void buttonScalingUp_Click(object sender, EventArgs e)
        {
            if (scaling >= 10)
            {
                return;
            }

            else
            {
                scaling += 0.2f;
                Redraw();
            }
        }

        private void buttonScalingDown_Click(object sender, EventArgs e)
        {
            if (scaling <= 0.4)
            {
                return;
            }
            else
            {
                scaling -= 0.2f;
                Redraw();
            }
        }
    }
}
