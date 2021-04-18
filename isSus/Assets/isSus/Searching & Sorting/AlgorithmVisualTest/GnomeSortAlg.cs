using UnityEngine;
using System;

namespace IsSus.Sorting
{
    public class GnomeSortAlg : IComparable
    {
        /* GNOME SORT
         * Also called the stupid sort
         * Is based on the concept of a garden gnome sorting flower pots
         * 1) If you are at the start of the array go to the right
         * 2) If the current array element is larger or equal to the previous, then go to the right
         * 3) If the current array element is smaller than the previous, swap the two and go backwards
         * Repeat steps 2 and 3 until the end of the array
         */

        private void Start()
        {
            ApplyGnomeSort();
        }

        private static void ApplyGnomeSort()
        {
            int[] array = { 34, 2, 10, -9 }; //The array of numbers to be sorted
            GnomeSort(array, array.Length);
            Debug.Log("Sorted sequence after applying Gnome Sort");

            for (int i = 0; i < array.Length; i++)
            {
                Debug.Log(array[i] + " ");
            }
        }

        /// <summary>
        /// This function is the application of the Gnome sort algorithm.
        /// </summary>
        /// <param name="array">The array of numbers that will be sorted.</param>
        /// <param name="totals">The total number of elements in the array.</param>
        private static void GnomeSort(int[] array, int totals)
        {
            int index = 0;

            while (index < totals)
            {
                // If you are at the start of the array go to the right
                if (index == 0)
                    index++;

                // If the current array element is larger or equal to the previous, then go to the right
                if (array[index] >= array[index - 1])
                    index++;
                // Else if the current array element is smaller than the previous, swap the two and go backwards
                else
                {
                    int temp = 0; //Use a temporary variable to hold the current array element that will be swapped with another
                    temp = array[index];             //Swap the current with the previous 
                    array[index] = array[index - 1];
                    array[index - 1] = temp;
                    index--; //Go backwards
                }
            }
            return;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
