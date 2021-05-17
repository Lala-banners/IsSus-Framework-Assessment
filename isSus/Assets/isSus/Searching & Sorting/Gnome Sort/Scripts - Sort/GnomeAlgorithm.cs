using UnityEngine;
using System;
using System.Collections.Generic;

namespace IsSus.Sorting
{
    public static class GnomeAlgorithm 
    {
        /* GNOME SORT
         * Also called the stupid sort
         * Is based on the concept of a garden gnome sorting flower pots
         * 1) If you are at the start of the array go to the right
         * 2) If the current array element is larger or equal to the previous, then go to the right
         * 3) If the current array element is smaller than the previous, swap the two and go backwards
         * Repeat steps 2 and 3 until the end of the array
         */

        /// <summary>
        /// This function is the application of the Gnome sort algorithm.
        /// </summary>
        /// <param name="array">The array of numbers that will be sorted.</param>
        /// <param name="totals">The total number of elements in the array.</param>
        public static void GnomeSort(int[] arr, int length)
        {
            int index = 0;

            while (index < length)
            { //If there is no pot next to the gnome, he is done.
                if (index == 0) //If the gnome is at the start of the line...
                {
                    index++;//Gnome steps forward
                }

                //If the pots next to the gnome are in the correct order...
                if (arr[index] >= arr[index - 1])
                {
                    index++;//he goes to the next pot
                }
                else //If the pots are in the wrong order, he switches them.
                {
                    int temp = 0;
                    temp = arr[index];
                    arr[index] = arr[index - 1];
                    arr[index - 1] = temp;
                    index--;
                }
            }
            return;
        }
    }
}
