using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearch
{
	class Program
	{
		static int[] InitArray(int N, int minValue, int maxValue)
		{
			if (N < 1) return new int[0];

			if (minValue > maxValue) return new int[N];

			Random rnd = new Random();
			int[] array = new int[N];

			for (int i = 0; i < array.Length; i++)
				array[i] = rnd.Next(minValue, maxValue + 1);

			return array;
		}

		static void OutputArray(int[] array)
		{
			Console.WriteLine("Массив:");

			foreach (int num in array)
				Console.Write(num + " ");

			Console.WriteLine();
		}

		static int[] QuickSort(int[] array)
		{
			if (array.Length <= 1)
				return array;

			Random rnd = new Random();
			int randomIndexElement = rnd.Next(array.Length);

			List<int> leftPart = new List<int>();
			List<int> middlePart = new List<int>();
			List<int> rightPart = new List<int>();

			foreach (int element in array)
			{
				if (element < array[randomIndexElement]) leftPart.Add(element);
				else if (element > array[randomIndexElement]) rightPart.Add(element);
				else middlePart.Add(element);
			}

			int[] left = leftPart.ToArray();
			int[] middle = middlePart.ToArray();
			int[] right = rightPart.ToArray();

			return QuickSort(left).Concat(middle).ToArray().Concat(QuickSort(right)).ToArray();
		}

		static int BinarySearchIndex(int[] array, int value, int minIndex, int maxIndex)
		{
			if (minIndex > maxIndex)
				return -1;

			int middleIndex = minIndex + (maxIndex - minIndex) / 2;

			if (value == array[middleIndex]) return middleIndex;
			else if (value < array[middleIndex]) return BinarySearchIndex(array, value, minIndex, middleIndex - 1);
			else return BinarySearchIndex(array, value, middleIndex + 1, maxIndex);
		}

		static void Main(string[] args)
		{
			int[] array = InitArray(20, -10, 10);
			OutputArray(array);

			array = QuickSort(array);
			OutputArray(array);

			int element = 9;
			Console.WriteLine($"Поиска элемента: {element} => индекс элемента: {BinarySearchIndex(array, element, 0, array.Length - 1)}");
		}
	}
}
