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
        public static void GnomeSort<Color>(Color[] _colours, int totals) where Color : IComparable
        {
            int index = 0;
            Renderer _myRend;

            while (index < totals)
            {
                // If you are at the start of the array go to the right
                if (index == 0)
                {
                    index++;
                }

                // If the current array element is larger or equal to the previous, then go to the right
                //if (_colours[index] >= _colours[index - 1])
                //{
                //    index++;
                //}

                // Else if the current array element is smaller than the previous, swap the two and go backwards
                else
                {
                    Color temp; //Use a temporary variable to hold the current array element that will be swapped with another
                    temp = _colours[index];             //Swap the current with the previous 
                    _colours[index] = _colours[index - 1];
                    _colours[index - 1] = temp;
                    index--; //Go backwards
                }
            }
            return;
        }
    }
}
