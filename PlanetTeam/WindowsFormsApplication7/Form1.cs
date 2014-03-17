﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Collections.ObjectModel;


namespace PlanetTeam
{
    public partial class Form1 : Form
    {
        public static int pln_selected;
       public Form2 form;

        public Form1()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();



            // //////////////////////

            PLN.Add(new PLANET());
            PLN[0].CENTER = new Point(400, 400);
            PLN[0].DISTANCE = 0;
            PLN[0].SPEED = 0;
            PLN[0].CLR = Color.Yellow;
            PLN[0].SIZE = 50;
            PLN[0].NAME = "SUN";

            PLN.Add(new PLANET());
            PLN[1].CENTER = new Point(PLN[0].GetPoint().X, PLN[0].GetPoint().Y);
            PLN[1].DISTANCE = 150;
            PLN[1].SPEED = 0.0003f;
            PLN[1].CLR = Color.Green;
            PLN[1].SIZE = 15;
            PLN[1].NAME = "EARTH";

            PLN.Add(new PLANET());
            PLN[2].CENTER = new Point(PLN[1].GetPoint().X, PLN[1].GetPoint().Y);
            PLN[2].DISTANCE = 15;
            PLN[2].SPEED = -0.01f;
            PLN[2].CLR = Color.White;
            PLN[2].SIZE = 5;
            PLN[2].NAME = "MOON";

            

            

            PLN.Add(new PLANET());
            PLN[3].CENTER = new Point(PLN[0].GetPoint().X, PLN[0].GetPoint().Y);
            PLN[3].DISTANCE = 200;
            PLN[3].SPEED = 0.001f;
            PLN[3].CLR = Color.OrangeRed;
            PLN[3].SIZE = 14;
            PLN[3].NAME = "MARS";

            PLN.Add(new PLANET());
            PLN[4].CENTER = new Point(PLN[0].GetPoint().X, PLN[0].GetPoint().Y);
            PLN[4].DISTANCE = 100;
            PLN[4].SPEED = 0.0007f;
            PLN[4].CLR = Color.Blue;
            PLN[4].SIZE = 15;
            PLN[4].NAME = "VENUS";

           

            // //////////////////////



        }



        // ///////////////////////
        static Bitmap BIT = new Bitmap(800, 800);
        static Graphics GBIT = Graphics.FromImage(BIT);
        // ///////////////////////
        public static Collection<PLANET> PLN = new Collection<PLANET>();

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            GBIT.Clear(Color.Black);
            // ////////////////////////////////////////
            for (Int32 i = 0; i < PLN.Count; i++)
            {



                PLN[2].CENTER = new Point(PLN[1].GetPoint().X, PLN[1].GetPoint().Y);

                // /////////////////////////


                GBIT.FillEllipse(new SolidBrush(PLN[i].CLR), new Rectangle(PLN[i].GetPoint().X - (int)PLN[i].SIZE / 2, PLN[i].GetPoint().Y - (int)PLN[i].SIZE / 2, (int)PLN[i].SIZE, (int)PLN[i].SIZE));
                GBIT.DrawString(PLN[i].NAME, new Font("arial", 10), new SolidBrush(Color.White), new Point(PLN[i].GetPoint().X, PLN[i].GetPoint().Y));


                GBIT.DrawEllipse(new Pen(Color.White), PLN[0].GetPoint().X - PLN[i].DISTANCE, PLN[0].GetPoint().Y - PLN[i].DISTANCE, PLN[i].DISTANCE * 2, PLN[i].DISTANCE * 2); 
                
                
            }
           // int rad = (int)Math.Sqrt(PLN[4].GetPoint().X * PLN[4].GetPoint().X + PLN[4].GetPoint().Y * PLN[4].GetPoint().Y);

            
            // ////////////////////////////////////////
            pictureBox1.Image = BIT;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            PLANET PL = new PLANET();

            for (int j = 0; j < PLN.Count; j++)
            {
                pln_selected = j;
                if ((e.X > PLN[j].GetPoint().X-(PLN[j].SIZE / 2)) &&
                    (e.X < PLN[j].GetPoint().X + (PLN[j].SIZE / 2) ) &&
                    (e.Y > PLN[j].GetPoint().Y - (PLN[j].SIZE / 2)) &&
                    (e.Y < PLN[j].GetPoint().Y + (PLN[j].SIZE / 2)))
                {
                    if (form == null)
                    {
                        form = new Form2();
                    }
                    else
                    {
                    form.Close();
                    form = new Form2();
                    }
                    
                    form.Show();
              }
            }
        }
    }
}
