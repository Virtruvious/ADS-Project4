using System.Diagnostics;

namespace Project4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = { 500, 1000, 2000, 5000, 10000 };

            Stopwatch bubbleSortTimer = new Stopwatch();
            Stopwatch quickSortTimer = new Stopwatch();

            Console.WriteLine("Data Size\tBubble Sort Time\tQuick Sort Time");
            foreach (int size in sizes)
            {
                bubbleSortTimer.Reset();
                quickSortTimer.Reset();

                int[] data = GenerateRandomData(size);

                bubbleSortTimer.Start();
                int[] bubbleSortData = BubbleSort(data);
                bubbleSortTimer.Stop();

                quickSortTimer.Start();
                int[] quickSortData = QuickSort(data, 0, data.Length - 1);
                quickSortTimer.Stop();

                Console.WriteLine(size + "\t\t" + bubbleSortTimer.ElapsedMilliseconds + "ms \t\t\t" + quickSortTimer.ElapsedMilliseconds + "ms");
            }

            //string file = "..\\..\\..\\data.txt";
            //using (StreamWriter sw = File.CreateText(file))
            //{
            //    foreach (int i in data)
            //    {
            //        sw.Write(i + ",");
            //    }
            //}
        }

        static int[] GenerateRandomData(int length)
        {
            int[] data = new int[length];
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                data[i] = random.Next(0, length);
            }

            return data;
        }

        static int[] BubbleSort(int[] input)
        {
            int length = input.Length;
            int temp = 0;

            bool noswap = false;

            while (!noswap)
            {
                noswap = true;
                for (int i = 0; i < length - 2; i++)
                {
                    if (input[i] > input[i + 1])
                    {
                        temp = input[i + 1];
                        input[i + 1] = input[i];
                        input[i] = temp;
                        noswap = false;
                    }
                }
            }

            return input;
        }

        static int[] SwapAlgorithm(int[] input, int pos1, int pos2)
        {
            int temp = input[pos1];
            input[pos1] = input[pos2];
            input[pos2] = temp;
            return input;
        }

        static int PartitionAlgorithm(int[] input, int low, int high)
        {
            int pivot = input[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (input[j] < pivot)
                {
                    i++;
                    input = SwapAlgorithm(input, i, j);
                }
            }

            input = SwapAlgorithm(input, i + 1, high);
            return i + 1;
        }

        static int[] QuickSort(int[] input, int low, int high)
        {
            if (low < high)
            {
                int pi = PartitionAlgorithm(input, low, high);
                QuickSort(input, low, pi - 1);
                QuickSort(input, pi + 1, high);
            }

            return input;
        }

    }
}