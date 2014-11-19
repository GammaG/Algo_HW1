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
         int numOfLoops;
         Boolean clearDiagramm = false;
         ulong x = 0;
         List<ulong> nList;

        public Form1()
        {
            InitializeComponent();

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

                if (nList == null)
                {
                    textBox_Results.AppendText("Please generate X and List<n> first!\n");
                    return;
                }
               

                List<long> listCPUTimes = new List<long>();
               
               
                Stopwatch timer = new Stopwatch();   //other way to initialize: Stopwatch timer = Stopwatch.StartNew();
                String mode = "";
                for (int i = 0; i < numOfLoops; i++)
                {
                    
                    timer.Reset();
                    timer.Start();

                    double num;

                    switch (comboBox_Method.SelectedIndex)
                    {
                        case 0:
                          num =  func1(x, nList[i]);
                            mode = "iterative exponentiation";
                            break;
                        case 1:
                            num = func2(x, nList[i]);
                            mode = "recursive exponentiation";
                            break;
                        case 2:
                            num = func3(x, nList[i]);
                            mode = "faster recusive exponentiation";
                            break;
                        default:
                            return;
                    }

                    timer.Stop();
                    listCPUTimes.Add(timer.ElapsedTicks);
                    Console.WriteLine(num);
                    int tI = i;
                    tI++; 
                    textBox_Results.AppendText("\r\n Iteration " + tI.ToString()  + ", CPU-time(ticks):" + timer.ElapsedTicks +" for n = "+nList[i]);
                }

                      
                //Get Mean and SD
                double meanCPUTicks = getMean(listCPUTimes);
                double varianceCPUTicks = getVariance(listCPUTimes);
                double standardDeviationCPUTicks = Math.Sqrt(varianceCPUTicks);

                textBox_Results.AppendText("\r\n Mean CPU-time(ticks):" + meanCPUTicks);
                textBox_Results.AppendText("\r\n Standard Deviation CPU-time(ticks):" + standardDeviationCPUTicks);


                //add data to chart
                String name = "StandardDeviation for\n"+mode;

                chart1.Titles.Clear();
                chart1.Titles.Add("CPUTime vs (x+n)/2");

                if (clearDiagramm)
                {
                    chart1.Series.Clear();
                }


                if (!chart1.Series.IsUniqueName(mode))
                {
                    chart1.Series.Remove(chart1.Series[mode]);
                    chart1.Series.Remove(chart1.Series[name]);
                }
                else if (!chart1.Series.IsUniqueName(mode))
                {
                    chart1.Series.Remove(chart1.Series[mode]);
                }

        
                chart1.Series.Add(mode);
               
                chart1.Series[mode].ChartType = SeriesChartType.Point;
               
                for (int i = 0; i < numOfLoops; i++)
                {
                    ulong x = (this.x + nList[i])/2;
                  
                    long y;
                    
                        y = listCPUTimes[i];
                                           
                    chart1.Series[mode].Points.AddXY(Convert.ToInt32(x),y);
                
                }
               
               
                    chart1.Series.Add(name);
                    chart1.Series[name].ChartType = SeriesChartType.ErrorBar;
                    chart1.Series[name]["ErrorBarSeries"] = mode + ":Y1";
                    chart1.Series[name]["ErrorBarType"] = "StandardDeviation";
               

                clearDiagramm = false;
                
            }
            catch (ArgumentOutOfRangeException ex)
            {
                textBox_Results.AppendText("\n"+ex.Message);
                
            }

            catch (Exception ex)
            {
                textBox_Results.AppendText("\nYour input is wasn't valid!");
                Console.WriteLine("\n"+ex);
                
            }
        }

        private static List<ulong> generateFactors(List<ulong> a, List<ulong> b){
            List<ulong> list = new List<ulong>();
            for(int i= 0; i < a.Count; i++){

                list[i] = (a[i] + b[i]) / 2;
            }

            return list;
        }
        

        

        private static long getMax(List<long> listCPUTimes)
        {
            long max = 0;
            foreach (long t in listCPUTimes)
            {
                if (t > max)
                {
                    max = t;
                }
            }
            return max;
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

        public static List<ulong> genRandomList(int min, int max, int count)
        {
            List<ulong> randomList = new List<ulong>();
            Random random = new Random();
            for (int i = 0; i < count; ++i)
            {
                randomList.Add(Convert.ToUInt64( random.Next(min, max + 1)));
            }
            return randomList;
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
     

        }

        private void GenBtnXN(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(numericUpDown_a.Value);
                int b = Convert.ToInt32(numericUpDown_b.Value);
                numOfLoops = (int)numericUpDown_loops.Value;

                ulong l_a = Convert.ToUInt64(a);
                ulong l_b = Convert.ToUInt64(b);

                x = genRandomList(a, b, 1)[0];
                nList = genRandomList(a, b, numOfLoops);

                textBox_Results.AppendText("new x and List<n> has been generated.\n");
                textBox_Results.AppendText("x = "+x+"\n");
                String txt = "List<n> = {";
                foreach(ulong n in nList){
                    txt += n + ", ";
                }
                txt = txt.Substring(0, txt.Length - 2);
                txt += "}\n";
                textBox_Results.AppendText(txt);
                XNLabel.Text = "x = "+x+"\nList<n> count = "+nList.Count;
                clearDiagramm = true;

            }
            catch (Exception ex)
            {
                textBox_Results.AppendText("\nYour input is wasn't valid!");
                Console.WriteLine("\n" + ex);

            }


        }

     }
}
