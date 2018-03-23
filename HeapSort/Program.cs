using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeapSort
{
    class Program
    {
        static class HeapSort<T> where T : IComparable
        {
            static void heapify(T[] arr, int size, int i)
            {
                int max = i;
                int leftSon = 2 * i + 1; 
                int rightSon = 2 * i + 2;

                if (leftSon < size && arr[leftSon].CompareTo(arr[max]) > 0)
                {
                    max = leftSon;
                }
                if (rightSon < size && arr[rightSon].CompareTo(arr[max]) > 0)
                {
                    max = rightSon;
                }
                if (arr[max].CompareTo(arr[i]) != 0)
                {
                    swap(ref arr[max], ref arr[i]);
                    heapify(arr, size, max);
                }
            }

            static void swap(ref T a, ref T b)
            {
                T swapper = a;
                a = b;
                b = swapper;
            }

            public static void sort(T[] arr)
            {
                int size = arr.Length;
                for (int i = size / 2 - 1; i >= 0; i--)
                {
                    heapify(arr, size, i);
                }

                for (int i = size - 1; i >= 0; i--)
                {
                    swap(ref arr[i], ref arr[0]);

                    heapify(arr, i, 0);
                }
            }
        }

       static void bubbleSort( int[] arr)
        {
            int temp = 0;

            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }

        }

        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            Random rand = new Random();

            int[] arr1 = new int[15];
            int[] arr2 = new int[15];

            for (int i = 0; i < 15; i++)
            {
                arr1[i] = rand.Next(0, 15);
                arr2[i] = rand.Next(0, 15);
                Console.Write(arr1[i] + "  ");
            }
            Console.WriteLine("");

            watch.Reset();
            watch.Start();
            HeapSort<int>.sort(arr1);
            watch.Stop();
            Console.WriteLine("HeapSort took: " + watch.Elapsed);

            watch.Reset();
            watch.Start();
            bubbleSort(arr2);
            watch.Stop();
            Console.WriteLine("Bubble sort took: " + watch.Elapsed);
            
            foreach (int a in arr1)
            {
                Console.Write(a + "  ");
            }
            Console.WriteLine("");

            int[] bigArr1 = new int[500];
            int[] bigArr2 = new int[500];
            
            for (int i = 0; i < 500; i++)
            {
                bigArr1[i] = rand.Next(0, 500);
                bigArr2[i] = rand.Next(0, 500);
                Console.Write(bigArr1[i] + "  ");
            }
            Console.WriteLine("");
            Console.WriteLine("");

            watch.Reset();
            watch.Start();
            HeapSort<int>.sort(bigArr1);
            watch.Stop();
            Console.WriteLine("HeapSort took: " + watch.Elapsed);

            watch.Reset();
            watch.Start();
            bubbleSort(bigArr2);
            watch.Stop();
            Console.WriteLine("Bubble sort took: " + watch.Elapsed);
            
            for (int i = 0; i < 500; i++)
            {
                Console.Write(bigArr1[i] + "  ");
            }


            int[] veryBig1 = new int[50000];
            int[] veryBig2 = new int[50000];

            for (int i = 0; i < 50000; i++)
            {
                veryBig1[i] = rand.Next(0, 50000);
                veryBig2[i] = rand.Next(0, 50000);
            }
            Console.WriteLine("");
            Console.WriteLine("");

            watch.Reset();
            watch.Start();
            HeapSort<int>.sort(veryBig1);
            watch.Stop();
            Console.WriteLine("HeapSort took: " + watch.Elapsed);

            watch.Reset();
            watch.Start();
            bubbleSort(veryBig2);
            watch.Stop();
            Console.WriteLine("Bubble sort took: " + watch.Elapsed);
        }
    }
}
