﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ex1
{
    public partial class Form1 : Form
    {
        private Graphics Graph;
        private Pen MyPen;
        private int A;

        public Form1()
        {
            InitializeComponent();
            Graph = CreateGraphics();
            MyPen = new Pen(Color.Black);
            A = 0;
        }
        
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                A = int.Parse(textBox.Text);
            }
            catch (Exception ex)
            {
                A = 0;
            }
        }
        
        private void paintButton_Click(object sender, EventArgs e)
        {
            if (A == 0)
            {
                return;
            }
            
            const double xMin = 0;
            const double xMax = 6.28;
            const double step = 0.01;
            
            Graph.Clear(Color.White);
            
            int x0 = ClientSize.Width / 2;
            int y0 = ClientSize.Height / 2;
            double t = xMin;
            double x = A * Math.Cos(t) * (1 + Math.Cos(t));
            double y = A * Math.Sin(t) * (1 + Math.Cos(t));
            int x1 = (int)(x0 + x);
            int y1 = (int)(y0 - y);
            while (t < xMax)
            {
                t += step;
                x = A * Math.Cos(t) * (1 + Math.Cos(t));
                y = A * Math.Sin(t) * (1 + Math.Cos(t));
                int x2 = (int)(x0 + x);
                int y2 = (int)(y0 - y);
                Graph.DrawLine(MyPen, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MyPen.Dispose();
            Graph.Dispose();
        }
    }
}