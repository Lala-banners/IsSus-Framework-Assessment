using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IsSus.Sorting
{
    public class ColourSorting : MonoBehaviour
    {
        #region Public
        [Header("Changing Colours")]
        public GameObject gnomePrefab;
        public GameObject[] gnomes;

        //List of colours
        private Color[] colours = { Color.green, Color.red, Color.yellow, Color.blue };

        [Header("Shared Material")]
        [SerializeField] private Material sharedMaterial;
        #endregion

        private void Start()
        {
            int[] array = { 84, 61, 15, 2, 7, 55, 19, 40, 78, 33 };

            GnomeAlgorithm.GnomeSort(array, array.Length);

            print(array.ToString());
        }

        public void SetColour()
        {
            // To change colours of all gnomes
            int random;
            Color tempCol;

            //Changing specific gnome material colours
            gnomePrefab.GetComponent<MeshRenderer>().material.color = colours[Random.Range(0, colours.Length)];

            //Changing all gnome colours
            for (int i = 0; i < colours.Length; i++)
            {
                random = Random.Range(i, colours.Length);
                gnomes[i].GetComponent<Renderer>().material.color = colours[random];
                tempCol = colours[i];
                colours[i] = colours[random];
                colours[random] = tempCol;
            }
        }

        /// <summary>
        /// Check if the current colour is the same as the prefab,
        /// if it is then there is a match!
        /// </summary>
        public void CheckColour(Color _colour)
        {
            //If any of the current colours is the same as the prefab
            if(_colour == gnomePrefab.GetComponent<Renderer>().material.color)
            {
                //Yay! They match
                print("Matched!");

                //Make the material stay and not randomise
                gnomePrefab.GetComponent<Renderer>().material.color = _colour;
            }
            else
            {
                //Randomise colours again
                SetColour();
                print("Not Matched");
            }
        }

        #region Need to fix
        //Sorting algorithm test - Gnome Sort - will need to change params to be GO instead of ints

        /// <summary>
        /// This function is the application of the Gnome sort algorithm.
        /// </summary>
        /// <param name="gnomeObj">The array of gameObjects/colours that will be sorted.</param>
        /// <param name="total">The total number of gameObjects in the array.</param>
        //private static void GnomeSort(GameObject[] gnomeObj, int total)
        //{
        //    int index = 0; //current game object index
        //    Vector3 tempPosition;

        //    while (index < total)
        //    {
        //        // If you are at the start of the array go to the right
        //        if (index == 0)
        //            index++;

        //        // If the current gameObject's height is larger or equal to the previous, then go to the right
        //        if (gnomeObj[index].transform.localScale.y >= gnomeObj[index - 1].transform.localScale.y)
        //        {
        //            index++;
        //        }
        //        // Else if the current array element is smaller than the previous, swap the two and go backwards
        //        else
        //        {
        //            GameObject temp; //Use a temporary GameObject to hold the current array GO that will be swapped with another
        //            temp = gnomeObj[index];             //Swap the current with the previous 
        //            gnomeObj[index] = gnomeObj[index - 1];
        //            gnomeObj[index - 1] = temp;
        //            index--; //Go backwards to previous game object

        //            //Add in the physical swapping of the cubes
        //            tempPosition = gnomeObj[index].transform.localPosition;

        //            gnomeObj[index].transform.localPosition
        //                = new Vector3(gnomeObj[index - 1].transform.localPosition.x,
        //                tempPosition.y,
        //                tempPosition.z);

        //            gnomeObj[index - 1].transform.localPosition
        //                = new Vector3(tempPosition.x,
        //                gnomeObj[index - 1].transform.localPosition.y,
        //                gnomeObj[index - 1].transform.localPosition.z);
        //        }
        //    }
        //    return;
        //}
        #endregion
    }
}
