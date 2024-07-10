using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Дз1
{
    class DrawGraphs
    {
        public void DrawUktIkt(Panel p, double[] Ik, double[] Uk)
        {
            Graphics g = p.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            p.Invalidate();
            p.Controls.Clear();
            double minI = Ik.Min();
            double maxI = Ik.Max();
            double minU = Uk.Min();
            double maxU = Uk.Max();
            //расчет значений на оси ОX
            double[] OX = new double[18];
            for(int i = 0; i < 18; i++)
                OX[i] = (double)0.1 / (double)17 * (double)i * 1000;

            DrawAxis(g,p,maxI,maxU,minI,minU,125,375, OX);
            WriteAxis(p, "I, A","U, B", "t, C*10^(-3)",125,375);

            //нормируем значение силы тока
            Norm(minI, maxI,Ik, 80, 120);
            //рисуем график силы тока
            for (int i = 0; i < 79; i++)
            {
                g.DrawLine(new Pen(Color.Blue, 2.0f), 40 + (float)578 / 79 * i, 125-(float)Ik[i], 40 + (float)578 / 79 * (i+1), 125 - (float)Ik[i+1]);
            }
           // g.DrawLine(new Pen(Color.Red, 2.0f), 40 + 578 / 79 * 0, 125, 40 + (float)578 / 79 * 79, 125);
            //нормируем значение напряжения
            Norm(minU, maxU, Uk, 80,120);
            //рисуем график напряжения
            for (int i = 0; i < 79; i++)
            {
                g.DrawLine(new Pen(Color.Green, 2.0f), 40 + (float)578 / 79 * i, 375-(float)Uk[i], 40 + (float)578 / 79 * (i+1), 375 - (float)Uk[i+1]);
            }

            //Легенда
            Legacy(g, p, "I", "U");

        }

        public void DrawSpectrum(Panel p,double[] spI,double[] spU, double[] freq)
        {
            Graphics g = p.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            p.Invalidate();
            p.Controls.Clear();
            double minI = spI.Min();
            double maxI = spI.Max();
            double minU = spU.Min();
            double maxU = spU.Max();
            DrawAxis(g, p, maxI, maxU, minI, minU, 245, 495, freq);
            WriteAxis(p, "Амплитуда","Амплитуда","Freq, Гц",245,495);
            Norm(minI, maxI, spI,80,240);
            //рисуем график спектра силы тока
            for (int i = 0; i < 79; i++)
            {
                g.DrawLine(new Pen(Color.Blue, 2.0f), 40 + (float)578 / 79 * i, 245 - (float)spI[i], 40 + (float)578 / 79 * (i + 1), 245 - (float)spI[i + 1]);
            }
            Norm(minU, maxU, spU,80,240);
            //рисуем график спектра напряжения
            for (int i = 0; i < 79; i++)
            {
                g.DrawLine(new Pen(Color.Green, 2.0f), 40 + (float)578 / 79 * i, 495 - (float)spU[i], 40 + (float)578 / 79 * (i + 1), 495 - (float)spU[i + 1]);
            }
            //легенда
            Legacy(g, p, "Спектр сигнала силы тока", "Спектр сигнала напряжения");
            
        }

        public void DrawPt(Panel p, double[] Pt)
        {
            Graphics g = p.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            p.Invalidate();
            p.Controls.Clear();
            double min = Pt.Min();
            double max = Pt.Max();

            DrawAxis(g, p, max, min, 100, 0, 250);
            WriteAxis(p, "P,Вт", "", "t, C*10^(-3)", 255, -50);

            //нормируем значение мощности
            Norm(min, max, Pt, 80, 245);
            //рисуем график мощности
            for (int i = 0; i < 79; i++)
            {
                g.DrawLine(new Pen(Color.Blue, 2.0f), 40 + (float)578 / 79 * i, 245 - (float)Pt[i], 40 + (float)578 / 79 * (i + 1), 245 - (float)Pt[i + 1]);
            }
            //легенда
            g.DrawLine(new Pen(Color.Blue, 3.0f), 225, 525, 245, 525);
            Label l4 = new Label();
            l4.Text = "Мгновенная мощность p(t)";
            l4.Location = new Point(250, 520);
            l4.MaximumSize = new Size(800, 20);
            l4.AutoSize = true;
            l4.Font = new Font("Arial", 10);
            p.Controls.Add(l4);

        }
        public void DrawPQS(Panel p, double[] P, double[] Q, double[] S, int start)
        {
            Graphics g = p.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            p.Invalidate();
            p.Controls.Clear();
            double min1 = P.Min();
            double max1 = P.Max();
            double min2 = Q.Min();
            double max2 = Q.Max();
            double min3 = S.Min();
            double max3 = S.Max();
            int n = P.Length;
            double[] norm = new double[6] {Math.Abs(min1), max1, Math.Abs(min2), max2, Math.Abs(min3), max3};
            Norm(norm.Min(), norm.Max(), P, n, 495);
            Norm(norm.Min(), norm.Max(),Q, n, 495);
            Norm(norm.Min(), norm.Max(), S, n, 495);

            DrawAxis(g, p, norm.Max(), norm.Min(), n, start, 495);
            WriteAxis(p, "Вт", "", "    t, с", 495, -50);
            //рисуем график активной мощности
            for (int i = 0; i < n-1; i++)
            {
                g.DrawLine(new Pen(Color.Blue, 2.0f), 40 + (float)578 / (n-1) * i, 495 - (float)P[i], 40 + (float)578 / (n - 1) * (i + 1), 495 - (float)P[i + 1]);
            }
            //рисуем график реактивной мощности
            for (int i = 0; i < n-1; i++)
            {
                g.DrawLine(new Pen(Color.Green, 2.0f), 40 + (float)578 / (n - 1) * i, 495 - (float)Q[i], 40 + (float)578 / (n - 1) * (i + 1), 495 - (float)Q[i + 1]);
            }
            //рисуем график полной мощности
            for (int i = 0; i < n-1; i++)
            {
                g.DrawLine(new Pen(Color.Red, 2.0f), 40 + (float)578 / (n - 1) * i, 495 - (float)S[i], 40 + (float)578 / (n - 1) * (i + 1), 495 - (float)S[i + 1]);
            }
            //Легенда
            g.DrawLine(new Pen(Color.Blue, 3.0f), 20, 525, 45, 525);
            Label l4 = new Label();
            l4.Text = Convert.ToString("Активная мощность P(t)");
            l4.Location = new Point(40, 520);
            l4.MaximumSize = new Size(800, 20);
            l4.AutoSize = true;
            l4.Font = new Font("Arial", 10);
            p.Controls.Add(l4);

            g.DrawLine(new Pen(Color.Green, 3.0f), 240, 525, 260, 525);
            Label l5 = new Label();
            l5.Text = Convert.ToString("Реактивная мощность Q(t)");
            l5.Location = new Point(265, 520);
            l5.AutoSize = true;
            l5.MaximumSize = new Size(800, 20);
            l5.Font = new Font("Arial", 10);
            p.Controls.Add(l5);

            g.DrawLine(new Pen(Color.Red, 3.0f), 475, 525, 495, 525);
            Label l = new Label();
            l.Text = Convert.ToString("Полная мощность S(t)");
            l.Location = new Point(500, 520);
            l.AutoSize = true;
            l.MaximumSize = new Size(800, 20);
            l.Font = new Font("Arial", 10);
            p.Controls.Add(l);
        }

        public void DrawAxis (Graphics g, Panel p, double max1, double max2, double min1, double min2, int Xg1, int Xg2, double[] OX)
        {
            //рисуем сетку
            //вертикальная
            for (int i = 1; i < 18; i++)
            {
                g.DrawLine(new Pen(Color.Gray, 1.0f), 40 + 34 * i, 5, 40 + 34 * i, 245);
                Label label = new Label();
                label.Text = Convert.ToString(OX[i]);
                label.Location = new Point(30 + 34 * i, Xg1+4);
                label.MaximumSize = new Size(30, 14);
                label.Font = new Font("Arial", 8);
                p.Controls.Add(label);

                g.DrawLine(new Pen(Color.Gray, 1.0f), 40 + 34 * i, 255, 40 + 34 * i, 495);
                Label label2 = new Label();
                label2.Text = label.Text;
                label2.MaximumSize = new Size(30, 14);
                label2.Font = new Font("Arial", 8);
                label2.Location = new Point(30 + 34 * i, Xg2+4);
                p.Controls.Add(label2);
            }
            //горизонтальная
            double o1 = max1 - min1;
            double o2 = max2 - min2;

            for (int i = 1; i < 9; i++)
            {
                g.DrawLine(new Pen(Color.Gray, 1.0f), 40, 5 + (float)240 / 8 * i, 670, 5 + (float)240 / 8 * i);
                Label label = new Label();
                label.Text = Convert.ToString(max1 - o1 / (double)8 * (double)i);
                label.Location = new Point(0, (int)(5 + 238 / 8 * i));
                label.MaximumSize = new Size(40, 14);
                label.Font = new Font("Arial", 8);
                p.Controls.Add(label);

                g.DrawLine(new Pen(Color.Gray, 1.0f), 40, 253 + (float)240 / 8 * i, 670, 253 + (float)240 / 8 * i);
                Label label1 = new Label();
                label1.Text = Convert.ToString(max2 - o2 / (double)8 * (double)i);
                label1.Location = new Point(0, (int)(253 + 240 / 8 * i));
                label1.MaximumSize = new Size(40, 14);
                label1.Font = new Font("Arial", 8);
                p.Controls.Add(label1);
            }
            //рисуем координатные оси
            //ось вертикальная
            g.DrawLine(new Pen(Color.Black, 1.0f), 40, 5, 40, 245);
            //стрелка вертикальная
            g.DrawLine(new Pen(Color.Black, 1.0f), 40, 5, 30, 15);
            g.DrawLine(new Pen(Color.Black, 1.0f), 40, 5, 50, 15);
            //ось горизонтальная
            g.DrawLine(new Pen(Color.Black, 1.0f), 40, Xg1, 670, Xg1);
            //стрелка горизонтальная
            g.DrawLine(new Pen(Color.Black, 1.0f), 670, Xg1, 660, Xg1-5);
            g.DrawLine(new Pen(Color.Black, 1.0f), 670, Xg1, 660, Xg1+5);
            //ось вертикальная
            g.DrawLine(new Pen(Color.Black, 1.0f), 40, 255, 40, 495);
            // стрелка вертикальная
            g.DrawLine(new Pen(Color.Black, 1.0f), 40, 255, 30, 265);
            g.DrawLine(new Pen(Color.Black, 1.0f), 40, 255, 50, 265);
            //ось горизонтальная
            g.DrawLine(new Pen(Color.Black, 1.0f), 40, Xg2, 670, Xg2);
            g.DrawLine(new Pen(Color.Black, 1.0f), 670, Xg2, 660, Xg2-5);
            g.DrawLine(new Pen(Color.Black, 1.0f), 670, Xg2, 660, Xg2+5);

        }
        
        public void DrawAxis(Graphics g, Panel p, double max, double min, int time, int start, int Ox)
        {
            //рисуем сетку
            //вертикальная
            for (int i = 1; i < 18; i++)
            {
                g.DrawLine(new Pen(Color.Gray, 1.0f), 40 + 34 * i, 5, 40 + 34 * i, 495);
                Label label = new Label();
                label.Text = Convert.ToString(start+ (double)time / (double)17 * (double)i);
                label.Location = new Point(30 + 34 * i, Ox + 4);
                label.MaximumSize = new Size(30, 14);
                //label.BackColor = Color.White;
                label.Font = new Font("Arial", 8);
                p.Controls.Add(label);
            }
            //горизонтальная
            double o1 = max - min;

            for (int i = 1; i < 15; i++)
            {
                g.DrawLine(new Pen(Color.Gray, 1.0f), 40, 5 + (float)490 / 15 * i, 670, 5 + (float)490 / 15 * i);
                Label label = new Label();
                label.Text = Convert.ToString(max - o1 / (double)15 * (double)i);
                label.Location = new Point(0, (int)(5 + 490 / 15 * i));
                label.MaximumSize = new Size(40, 14);
                label.Font = new Font("Arial", 8);
                p.Controls.Add(label);
            }
            //рисуем координатные оси
            //ось вертикальная
            g.DrawLine(new Pen(Color.Black, 1.0f), 40, 5, 40, 495);
            //стрелка вертикальная
            g.DrawLine(new Pen(Color.Black, 1.0f), 40, 5, 35, 15);
            g.DrawLine(new Pen(Color.Black, 1.0f), 40, 5, 45, 15);
            //ось горизонтальная
            g.DrawLine(new Pen(Color.Black, 1.0f), 40, Ox, 670, Ox);
            //стрелка горизонтальная
            g.DrawLine(new Pen(Color.Black, 1.0f), 670, Ox, 660, Ox - 5);
            g.DrawLine(new Pen(Color.Black, 1.0f), 670, Ox, 660, Ox + 5);
        }

        public void WriteAxis(Panel p, string OY1, string OY2, string OX, int xg1, int xg2)
        {
            //подпись осей
            Label l = new Label();
            l.Text = Convert.ToString(OY1);
            l.Location = new Point(5, 0);
            l.MaximumSize = new Size(30, 14);
            l.Font = new Font("Arial", 8);
            p.Controls.Add(l);

            Label l1 = new Label();
            l1.Text = Convert.ToString(OY2);
            l1.Location = new Point(5, 255);
            l1.MaximumSize = new Size(30, 14);
            l1.Font = new Font("Arial", 8);
            p.Controls.Add(l1);

            Label l2 = new Label();
            l2.Text = Convert.ToString(OX);
            l2.Location = new Point(620, xg1-25);
            l2.MaximumSize = new Size(80, 15);
            l2.Font = new Font("Arial", 8);
            p.Controls.Add(l2);

            Label l3 = new Label();
            l3.Text = Convert.ToString(OX);
            l3.Location = new Point(620, xg2-25);
            l3.MaximumSize = new Size(80, 15);
            l3.Font = new Font("Arial", 8);
            p.Controls.Add(l3);
        }
        public void Norm(double min, double max, double[] data, int n, int kNorm)
        {
            //нормирование значений
            double norm;
            if (max > Math.Abs(min))
                norm = max;
            else
                norm = Math.Abs(min);
            for (int i = 0; i < n; i++)
                data[i] = data[i] / norm * kNorm;
        }

        public void Legacy(Graphics g, Panel p, string name1, string name2)
        {
            //легенда
            g.DrawLine(new Pen(Color.Blue, 3.0f), 100, 525, 120, 525);
            Label l4 = new Label();
            l4.Text = Convert.ToString(name1);
            l4.Location = new Point(125, 520);
            l4.MaximumSize = new Size(800, 20);
            l4.AutoSize = true;
            l4.Font = new Font("Arial", 10);
            p.Controls.Add(l4);
            g.DrawLine(new Pen(Color.Green, 3.0f), 400, 525, 420, 525);
            Label l5 = new Label();
            l5.Text = Convert.ToString(name2);
            l5.Location = new Point(425, 520);
            l5.AutoSize = true;
            l5.MaximumSize = new Size(800, 20);
            l5.Font = new Font("Arial", 10);
            p.Controls.Add(l5);
        }
    }
}
