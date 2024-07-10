using System;
using System.Numerics;
using MathNet.Numerics.IntegralTransforms;

namespace Дз1
{
    class CountGraphs
    {
        public double[] CountUktIkt(int k, double[] mas)
        {
            double[] result = new double[80];
            double n = k / 2;
            Array.Copy(mas, (int)Math.Ceiling(n) * 80, result, 0, 80);
            return result;
        }

        public double[] CountSpectrium(int k, double[] mas)
        {
            // Создание массива данных
            double[] data = new double[80];
            double n = k / 2;
            Array.Copy(mas, (int)Math.Ceiling(n) * 80, data, 0, 80);
            
            //Преобразование в комплексный
            Complex[] signal = new Complex[data.Length];
            for (var i = 0; i < 80; i++)
            {
                var value = data[i];
                Complex c1 = new Complex(value, 0);
                signal[i] = c1;
            }
            // Преобразование Фурье
            Fourier.Forward(signal);
            //расчет гармоник
            for (var i = 0; i < 80; i++)
            {
                data[i] = signal[i].Magnitude;
            }
            return data;
        }

        public double[] CountFreq()
        {
            // Создание массива данных
            double[] data = new double[80];
            //Расчет частоты
            for (var i = 0; i < 80; i++)
            {
                data[i] = (i) * 800 / 80;
            }
            return data;
        }

        public double[] CountPt(int k, double[] I, double[] U)
        {
            double[] It = CountUktIkt(k, I);
            double[] Ut = CountUktIkt(k, U);
            double[] Pt = new double[80];
            for(int i = 0;i <80;i++)
                Pt[i] = It[i]*Ut[i];
            return Pt;
        }

        public double[] CountP(int t1,int t2, double[] I, double[] U)
        {
            int t = t2 - t1;
            double[] It = new double[t*800];
            double[] Ut = new double[t * 800];
            Array.Copy(I, t1*800, It, 0, t*800);
            Array.Copy(U, t1*800, Ut, 0, t*800);
            double[] res = new double[t];
            for(int i = 0; i <t; i++)
            {
                for (int j = 0; j < 800; j++)
                    res[i] += Ut[j+i*800] * It[j+i*800];
                res[i] = res[i] / 800;
            }
              
            return res;
        }
        public double[] CountS(int t1, int t2, double[] I, double[] U)
        {
            int t = t2 - t1;
            double[] It = new double[t * 800];
            double[] Ut = new double[t * 800];
            Array.Copy(I, t1 * 800, It, 0, t * 800);
            Array.Copy(U, t1 * 800, Ut, 0, t * 800);
            double[] Id = new double[t];
            for (int i = 0; i < t; i++)
            {
                for (int j = 0; j < 800; j++)
                    Id[i] += It[j + i * 800] * It[j + i * 800];
                Id[i] = Math.Sqrt(Id[i] / 800);
            }

            double[] Ud = new double[t];
            for (int i = 0; i < t; i++)
            {
                for (int j = 0; j < 800; j++)
                    Ud[i] += Ut[j + i * 800] * Ut[j + i * 800];
                Ud[i] = Math.Sqrt(Ud[i] / 800);
            }
            double[] res = new double[t];
            for (int i = 0; i < t; i++)
                res[i] = Ud[i] * Id[i];
            return res;
        }
        public double[] CountQ(double[] P, double[] S)
        {
            int n = P.Length;
            double[] Q = new double[n];
            for(int i = 0; i < n; i++)
            {
                Q[i] = Math.Pow(S[i], 2) - Math.Pow(P[i], 2);
                Q[i] = Math.Sqrt(Q[i]);
            }
                
            return Q;
        }
    } 
}