using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Timers;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество элементов массива");
        Console.Write("A=");
        int size = int.Parse(Console.ReadLine());
        Console.WriteLine("Количество элементов массива:A={0}", size);
        int[] arrOrig = new int[size];
        int[] arr1 = new int[size];
        int[] arr2 = new int[size];
        int[] arr3 = new int[size];
        FillArray(arrOrig);
        SortShell(arr1);
        Sort(arr2);
        QuickSort(0, arr1.Length - 1, arr3);

    }

    static void FillArray(int[] a)
    {
        Random rand = new Random();
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = rand.Next(1000);
        }


    }
    static void Sort(int[] inputArray)
    {
        Stopwatch timer = new();
            timer.Start();
        Array.Sort(inputArray);
            timer.Stop();
        TimeSpan ts = timer.Elapsed;
        string elapsedTime = String.Format("Время выполнения Sort {0}", ts);
        Console.WriteLine(elapsedTime);
        

    }




    static void SortShell(int[] inputArray)          //сорт Шелла
    {
        Stopwatch timer = new();
        timer.Start();


        int temp;
        int i, j;
        int incr = inputArray.Length / 2;

        while (incr > 0)
        {
            incr /= 2;
            for (i = incr; i < inputArray.Length; i++)
            {
                j = i - incr;
                while (j >= 0)
                {
                    if (inputArray[j] > inputArray[j + incr])
                    {
                        temp = inputArray[j];
                        inputArray[j] = inputArray[j + incr];
                        inputArray[j + incr] = temp;
                        j -= incr;
                    }
                    else
                    {
                        j = -1;
                    }
                }
            }

        }
        timer.Stop();
        TimeSpan ts = timer.Elapsed;
        string elapsedTime = String.Format("Время выполнения Shell Sort {0}", ts);
        Console.WriteLine(elapsedTime);
    }

    //QuickSort
    static int FindPivot(int i, int j, int[] inputArray) //поиск опорного элемента
    {
        int key = inputArray[i];
        for (int k = i + 1; k <= j; k++)
        {
            if (inputArray[k] > key)
            {
                return k;
            }
            else if (inputArray[k] < key)
            {
                return i;
            }
        }
        return -1;
    }
    static int Partition(int i, int j, int pivot, int[] inputArray) //перестановка 
    {
        int temp;
        int left = i;
        int right = j;
        do
        {
            temp = inputArray[left]; inputArray[left] = inputArray[right]; inputArray[right] = temp;
            while (inputArray[left] < pivot)
            {
                left++;
            }
            while (inputArray[right] >= pivot)
            {
                right--;
            }

        }
        while (left <= right);
        return left;
    }
    static void QuickSort(int i, int j, int[] inputArray)  //алгоритм
    {
        Stopwatch timer = new();
        timer.Start();
        int index = FindPivot(i, j, inputArray);
        if (index != -1)
        {
            int pivot = inputArray[index];
            int k = Partition(i, j, pivot, inputArray);
            QuickSort(i, k - 1, inputArray);
            QuickSort(k, j, inputArray);
        }
        timer.Stop();
        TimeSpan ts = timer.Elapsed;
        string elapsedTime = String.Format("Время выполнения Quick Sort {0}", ts);
        Console.WriteLine(elapsedTime);

    }



}