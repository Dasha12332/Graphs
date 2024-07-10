using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace Дз1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }
        int k = 0;
        int kI=0;
        int kU=0;
        double[] U;
        double[] I;
        string filename1;
        string filename2;
        double h;
        double m;
        double c;
        private void buttonReadU_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            filename1 = openFileDialog1.FileName;
            richTextBox1.Text += "Читаем напряжение\n";
            //вызываем метод чтения
            U = Read(filename1);
            kU = k;
        }

        private void buttonDraw_Click(object sender, EventArgs e)
        {
            if (kI != kU)
            {
                MessageBox.Show("Количество циклов измерений в файлах не совпадает или равно 0. Вероятно считаны не верные данные. Проверьте их и повторите попытку");
                return;
            }
        
            if (I == null || U == null||U.Length != I.Length)
            {
                MessageBox.Show("Количество измерений в файлах не совпадает или равно 0. Вероятно считаны не верные данные. Проверьте их и повторите попытку");
                return;
            }

            DrawGraphs dr = new DrawGraphs();
            CountGraphs cg = new CountGraphs();

            if (radioButton1.Checked == true)
            {
                if(!int.TryParse(textBoxk.Text, out var number))
                {
                    MessageBox.Show("Введено не число.");
                    return;
                }
                    
                if (textBoxk.Text == "" || Convert.ToInt32(textBoxk.Text) >= k || Convert.ToInt32(textBoxk.Text) < 0)
                {
                    MessageBox.Show("Номер цикла измерений не введен или введен не верно.");
                    return;
                }
                int knew = Convert.ToInt32(textBoxk.Text);
                double[] Ikt = cg.CountUktIkt(knew, I);
                double[] Ukt = cg.CountUktIkt(knew, U);
                dr.DrawUktIkt(panel1, Ikt, Ukt);
            }

            if (radioButton2.Checked == true)
            {
                if (!int.TryParse(textBoxk.Text, out var number))
                {
                    MessageBox.Show("Введено не число.");
                    return;
                }

                if (textBoxk.Text == "" || Convert.ToInt32(textBoxk.Text) >= k || Convert.ToInt32(textBoxk.Text) < 0)
                {
                    MessageBox.Show("Номер цикла измерений не введен или введен не верно.");
                    return;
                }
                int knew = Convert.ToInt32(textBoxk.Text);
                double[] spI = cg.CountSpectrium(knew, I);
                double[] spU = cg.CountSpectrium(knew, U);
                double[] freq = cg.CountFreq();
                dr.DrawSpectrum(panel1, spI, spU, freq);
                //запись в файл если он не существует
                string path = filename1.Substring(0, filename1.Length - 4) + "_спектр_"+ textBoxk.Text+"_"
                    + filename2.Substring(filename1.Length - 6);
                FileInfo fileInf = new FileInfo(path);
                if (!fileInf.Exists)
                {
                    StreamWriter sw = new StreamWriter(path);
                    for(int i = 0; i<80; i++)
                    {
                        string s = spI[i] + "\t" + spU[i]+"\t"+ freq[i];
                        sw.WriteLine(s);
                    }
                    sw.Close();
                }
            }

            if (radioButton3.Checked == true)
            {
                if (!int.TryParse(textBoxk.Text, out var number))
                {
                    MessageBox.Show("Введено не число.");
                    return;
                }

                if (textBoxk.Text == "" || Convert.ToInt32(textBoxk.Text) >= k || Convert.ToInt32(textBoxk.Text) < 0)
                {
                    MessageBox.Show("Номер цикла измерений не введен или введен не верно.");
                    return;
                }
                int knew = Convert.ToInt32(textBoxk.Text);
                double[] Pt = cg.CountPt(knew, I,U);
                dr.DrawPt(panel1,Pt);
            }

            if (radioButton4.Checked == true)
            {
                string[] strT = textBoxT.Text.Split(';');
                if (strT.Length != 2)
                {
                    MessageBox.Show("Проверьте точно ли введены два числа через символ точка с зяпятой без пробелов");
                    return;
                }

                if (!int.TryParse(strT[0], out int t1)|| !int.TryParse(strT[1], out int t2))
                {
                    MessageBox.Show("Введено не число.");
                    return;
                }

                if (!(t1<t2))
                {
                    MessageBox.Show("Должно быть введено сначала меньшее число");
                    return;
                }

                if (t1<0||t2>h*3600+m*60+c)
                {
                    MessageBox.Show("Проверьте точно ли эксперемент длился в введенный промежуток времени");
                    return;
                }
                
                double[] P = cg.CountP(t1, t2, I, U);
                double[] S = cg.CountS(t1, t2,I, U);
                double[] Q = cg.CountQ(P, S);
                dr.DrawPQS(panel1, P,Q,S, t1);
                //запись в файл если он не существует
                string path = filename1.Substring(0, filename1.Length - 4) + "_PQS_" + strT[0] + "-" + strT[1]+"_"
                    + filename2.Substring(filename1.Length - 6);
                FileInfo fileInf = new FileInfo(path);
                if (!fileInf.Exists)
                {
                    int n = S.Length;
                    StreamWriter sw = new StreamWriter(path);
                    for (int i = 0; i < n; i++)
                    {
                        string s = Convert.ToInt32(strT[0]) + i + "\t" + P[i] + "\t" + Q[i] + "\t" + S[i];
                        sw.WriteLine(s);
                    }
                    sw.Close();
                }
            }
        }

        private void buttonReadI_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            filename2 = openFileDialog2.FileName;
            richTextBox1.Text += "Читаем силу тока\n";
            //вызываем метод чтения
            I = Read(filename2);
            kI = k;
        }

        double[] Read(string filename)
        {
            k = 0;
            richTextBox1.Text += "Считан файл: " + filename + "\n" + "Вычисленное время эксперимента: ";
            // читаем файл через строку
            StreamReader f = new StreamReader(filename);
            string text = "";
            while (!f.EndOfStream)
            {
                string s = f.ReadLine();
                if (k % 2 == 0)
                {
                    text += "\t" + s;
                }
                k++;
            }
            f.Close();
            string[] fileText = text.Split('\t');
            //удаляем пустые элементы из массива
            fileText = fileText.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            //длина массива
            int n = fileText.Length;
            //часы эксперимента
            h = Math.Floor((double)n / 800 / 60 / 60);
            //минуты эксперимента
            m = Math.Floor((n - h * 800 * 60 * 60) / 800 / 60);
            //секунды эсперимента
            c = Math.Floor((n - h * 800 * 60 * 60 - m * 800 * 60) / 800);
            richTextBox1.Text += h + ":" + m + ":" + c + "\nКоличество циклов измерений: " + k+"\n";
            double[] mas = Array.ConvertAll(fileText, s => double.Parse(s));
            return mas;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}