using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EuclideanAlgorithm

{
   
    public partial class Form1 : Form
    {
       
         private Boolean clearDiagramm = false;
         private ulong x;
         private ulong n;
         private Dictionary<long, int> cpuDictionary = new Dictionary<long, int>();
         private int loops = 0;
         private String modeFirst = "";
     

        public Form1()
        {
            InitializeComponent();
            chart1.Series.Clear();
            comboBox_Method.SelectedIndex = 0;  //Sub
         
        }

      

      

        public static List<ulong> getPrimeNumbers(ulong n)
        {
           
            List<ulong> primeNumbers = new List<ulong>();
            for (ulong i = 2; i <= n; i++)
            {
                
                while (n % i == 0 )
                {
                    
                    primeNumbers.Add(i);
                    n /= i;
                   

                }
            }

            return primeNumbers;
        }

        public static ulong getHistogram(ulong a, ulong b)
        {
            
            List<ulong> primeNumbersA = getPrimeNumbers(a);
            List<ulong> primeNumbersB = getPrimeNumbers(b);
            List<ulong> commonFactors = new List<ulong>();
            foreach (ulong _a in primeNumbersA){
                foreach (ulong _b in primeNumbersB)
                {
                   
                    if (_a == _b & !commonFactors.Contains(_a))
                        commonFactors.Add(_a);
                }
            }

            if (!commonFactors.Any())
            {
                return 0;
            }
            ulong x = 1;
            foreach (ulong factor in commonFactors)
            {
                
                x *= factor;
            }
            return x;
            
        }

        public static ulong getGCDSub(ulong a, ulong b)
        {

         


            if (a == 0)
                return b;

            while (b != 0)
            {
               

                if (a > b)
                    a = a - b;
                else
                    b = b - a;
            }

            return a;
        }


        //iterative exponentiation
        private double func1(double x,double n){
            double res=1;
            while(n>0){
                res*=x;
                n -=1;
            }
        return res;
        }

        //recursive exponentiation
        private double func2(double x,double n){
            if (n==1)
                return x;
            else
        return x*func2(x,n-1);
        }


        //faster recusive exponentiation
        private double func3(double x, double n)
        {
            if (n == 1)
                return x;
            if (n % 2 == 0)
              return  func3(x * x, n / 2);
            return x * func3(x, n - 1);
        }


        /** LOOPS */
        private void button_getHistogram_Click(object sender, EventArgs e)
        {
            try
            {

                if (x == null | n == null)
                {
                    textBox_Results.AppendText("Please set X,N and loops first!\n");
                    return;
                }

                 
                cpuDictionary.Clear();
               
                Stopwatch timer = new Stopwatch();   //other way to initialize: Stopwatch timer = Stopwatch.StartNew();
                String mode = "";
                for (int i = 0; i < loops; i++)
                {

                    timer.Reset();
                    timer.Start();

                    double num;

                    switch (comboBox_Method.SelectedIndex)
                    {
                        case 0:
                            num = func1(x, n);
                            mode = "iterative exponentiation N = "+n;
                            break;
                        case 1:
                            num = func2(x, n);
                            mode = "recursive exponentiation N = "+n;
                            break;
                        case 2:
                            num = func3(x, n);
                            mode = "faster recusive exponentiation N = "+n;
                            break;
                        default:
                            return;
                    }

                    timer.Stop();
                    
                    Console.WriteLine(num);
                    calcResult(timer.ElapsedTicks);
                    


                    int tI = i;
                    tI++;
                    textBox_Results.AppendText("\r\n Iteration " + tI.ToString() + ", CPU-time(ticks):" + timer.ElapsedTicks + " for n = " + n);
                }

                Dictionary<long, double> cpuDic = getProb();
                //cpuDic = normalizeDictionary(cpuDic);
                                
                chart1.Titles.Clear();
                chart1.Titles.Add("Probability vs cpuTime");

                if (clearDiagramm)
                {
                    chart1.Series.Clear();
                }


                if (!chart1.Series.IsUniqueName(mode))
                {
                    chart1.Series.Remove(chart1.Series[mode]);
                  
                }
               
                
                chart1.Series.Add(mode);
               
                //chart1.Series[mode].ChartType = SeriesChartType.Spline;
                chart1.Series[mode].ChartType = SeriesChartType.Column;
                chart1.ChartAreas[0].AxisX.Title = "cpuTime in ms";
                chart1.ChartAreas[0].AxisY.Title = "Probability";


                foreach (long xx in cpuDic.Keys)
                {

                    chart1.Series[mode].Points.AddXY(xx, cpuDic[xx]);

                    
                }

                chart1.Series[mode].Sort(PointSortOrder.Ascending, "X");               
                clearDiagramm = false;

                double mean = chart1.DataManipulator.Statistics.Mean(mode);
                double variance = chart1.DataManipulator.Statistics.Variance(mode, false);


                textBox_Results.AppendText("\r\nMean: " + mean);
                textBox_Results.AppendText("\r\nVariance: " + variance);
                tryTAndFTest(mode);

                
            }
            catch (ArgumentOutOfRangeException ex)
            {
                textBox_Results.AppendText("\r\n" + ex.Message);
                
            }

            catch (Exception ex)
            {
                textBox_Results.AppendText("\r\nYour input is wasn't valid!");
                Console.WriteLine("\r\n" + ex);
                
            }
        }


       

        private void tryTAndFTest(String mode)
        {
            if (modeFirst.Equals("")| modeFirst.Equals(mode))
            {
                modeFirst = mode;
                return;
            }
            

            int countOld = chart1.Series[modeFirst].Points.Count;
            int count = chart1.Series[mode].Points.Count;


            //Adding 0 values if one of the charts has less points. For the tests it is needed to have equal amount of points for the F and T Test. 
            if (countOld < count) {
                for (int i = 0; i < count - countOld; i++){
                   chart1.Series[modeFirst].Points.AddXY(0, 0);
                }

            }
            else if (count < countOld) {
                for (int i = 0; i < countOld - count; i++){
                    chart1.Series[mode].Points.AddXY(0, 0);
                }
            }


            TTestResult resultTTest = chart1.DataManipulator.Statistics.TTestPaired(0.2, 0.05, modeFirst, mode);
            textBox_Results.AppendText("\r\nTTest for " + modeFirst +"\r\nand "+mode+"\r\nis "+ resultTTest.TValue);
            FTestResult resultFTest = chart1.DataManipulator.Statistics.FTest(0.05, modeFirst, mode);
            textBox_Results.AppendText("\r\nFTest for " + modeFirst + "\r\nand " + mode + "\r\nis " + resultFTest.FValue);
            modeFirst = "";
        }

        private void calcResult(long cpuTime)
        {
            if (cpuDictionary.ContainsKey(cpuTime))
            {
                cpuDictionary[cpuTime] = cpuDictionary[cpuTime] + 1;
                return;
            }
            cpuDictionary.Add(cpuTime, 1);
                
        }

        private static List<ulong> generateFactors(List<ulong> a, List<ulong> b){
            List<ulong> list = new List<ulong>();
            for(int i= 0; i < a.Count; i++){

                list[i] = (a[i] + b[i]) / 2;
            }

            return list;
        }


        private long getSum()
        {
            long sum = 0;
            foreach (long t in cpuDictionary.Keys)
            {
                sum += (t*cpuDictionary[t]);
            }
            return sum;
        }



        private Dictionary<long, double> getProb()
        {
            Dictionary<long, double> list = new Dictionary<long, double>();
//            double sum = Convert.ToDouble(getSum());
            double loop = Convert.ToDouble(loops);

            foreach (long key in cpuDictionary.Keys)
            {

                double t = Convert.ToDouble(key);
                list.Add(key, cpuDictionary[key] / loop);
            }
            return list;
        }

        private Dictionary<long, double> normalizeDictionary(Dictionary<long, double> dic)
        {
            Dictionary<long, double> tempDic = new Dictionary<long, double>();
            double max = 0;
            foreach (double t in dic.Values)
            {
                if (t > max)
                {
                    max = t;
                }
            }

            double f = 1 - max;
            foreach (long l in dic.Keys)
            {
                double t = dic[l];
                tempDic.Add(l, t + f); 
            }

            return tempDic;
        }




       

        private static long getMin(List<long> listCPUTimes)
        {
            long min = long.MaxValue;
            foreach (long t in listCPUTimes)
            {
                if (t < min)
                {
                    min = t;
                }
            }
            return min;
        }


        private static long getMedian(List<long> listCPUTimes)
        {
            long d = 0;
            foreach (long t in listCPUTimes)
            {
                d += t;
            }
            return d / listCPUTimes.Count;

        }

        public static double getMean(List<long> resultset)
        {
            ulong number = Convert.ToUInt64(resultset.Count);
            ulong x = 0;
            foreach (ulong time in resultset)
            {
                x += time;
            }

			return x/number;
        }

        public static double getVariance(List<long> resultSet)
        {
            ulong maxValue = 0;
            ulong secondValue = 0;

            foreach (ulong t1 in resultSet){
                if(t1 > maxValue){
                    secondValue = maxValue;
                    maxValue = t1;
                }
            }

			return maxValue-secondValue;
        }

        public static List<int> getHistogram(double start, double end, List<long> data)
        {
			//ToDo: your implementation
            int num_bins = 1;

            List<int> histo = new List<int>(num_bins);

            return histo;
        }

       

        public static double[] getNormalizedHistogram(double start, double end, List<long> data)
        {
                    
            int num_bins = (int)Math.Round(Math.Sqrt(data.Count));

            double[] histo = new double[num_bins];

           
            


            return histo;
        }

        private void numericUpDown_b_ValueChanged(object sender, EventArgs e)
        {

        }

        private void diagramComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearDiagramm = true;
        }

        private void clearD_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
     

        }

       private void setXN(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(numericUpDown_x.Value);
                int b = Convert.ToInt32(numericUpDown_n.Value);
                loops = Convert.ToInt32(numericUpDown_loops.Value);
                
                x = Convert.ToUInt64(a);
                n = Convert.ToUInt64(b);

                textBox_Results.AppendText("x, n and loops has been set.\n");
                textBox_Results.AppendText("x = " + x + "\n");
                textBox_Results.AppendText("n = " + n +"\n");
                textBox_Results.AppendText("loops = " + loops + "\n");
                

            }
            catch (Exception ex)
            {
                textBox_Results.AppendText("\nYour input is wasn't valid!");
                Console.WriteLine("\n" + ex);

            }

        }

       private void clearBtn_Click(object sender, EventArgs e)
       {
           textBox_Results.Clear();
       }

     }
}
