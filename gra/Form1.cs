﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gra
{
    public partial class Form1 : Form
    {
        bool idzlewo;
        bool idzprawo;
        int szybkosc = 5;
        int punkty = 0;
        bool jestnacisniety;
        int ileprzeciwnikow = 12;
        int szybkoscgracz = 6;

        public Form1()
        {
            InitializeComponent();
        }

        private void klawiszdol(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Left)
            {
                idzlewo = true;
            }
            if(e.KeyCode==Keys.Right)
            {
                idzprawo = true;
            }
            if(e.KeyCode==Keys.Space&& !jestnacisniety)
            {
                jestnacisniety = true;
                robpocisk();
            }
        }

        private void klawiszgora(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Left)
            {
                idzlewo = false;
            }
            if(e.KeyCode==Keys.Right)
            {
                idzprawo = false;
            }
            if(jestnacisniety)
            {
                jestnacisniety = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (idzlewo)
            {
                gracz.Left -= szybkoscgracz;
            }
            else if(idzprawo)
            {
                gracz.Left += szybkoscgracz;
            }

            foreach(Control x in this.Controls)
            {
                if(x is PictureBox && x.Tag == "wrog")
                {
                    if
                        (((PictureBox)x).Bounds.IntersectsWith(gracz.Bounds))
                    {
                        koniecgry();
                    }
                    ((PictureBox)x).Left += szybkosc;
                    if (((PictureBox)x).Left>720)
                    {
                        ((PictureBox)x).Top += ((PictureBox)x).Height + 10;
                        ((PictureBox)x).Left = -50;
                    }
                }
            }
        }
        private void robpocisk()
        {
            PictureBox pocisk = new PictureBox();
            pocisk.Image = Properties.Resources.bullet;
            pocisk.Size = new Size(5, 20);
            pocisk.Tag = "pocisk";
            pocisk.Left = gracz.Left + gracz.Width / 2;
            pocisk.Top = gracz.Top - 20;
            this.Controls.Add(pocisk);
            pocisk.BringToFront();
        }
        private void koniecgry()
        {
            timer1.Stop();
            label1.Text += "koniec gry";
        }
    }
}
