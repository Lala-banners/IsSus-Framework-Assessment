using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IsSus.Sorting
{
    public class ColourSorting : MonoBehaviour
    {
        #region Public
        public int gnomeAmount = 10;
        public int maxCubeHeight = 10;
        public GameObject[] gnomes;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            InitialiseCubes();
            GnomeSort(gnomes, gnomes.Length); //Sort the cubes in the GO array within the number of cubes 
        }

        //Sorting algorithm test - Gnome Sort - will need to change params to be GO instead of ints

        /// <summary>
        /// This function is the application of the Gnome sort algorithm.
        /// </summary>
        /// <param name="goArray">The array of gameObjects that will be sorted.</param>
        /// <param name="totals">The total number of gameObjects in the array.</param>
        private static void GnomeSort(GameObject[] goArray, int totals)
        {
            int index = 0; //current game object index
            Vector3 tempPosition;

            while (index < totals)
            {
                // If you are at the start of the array go to the right
                if (index == 0)
                    index++;

                // If the current gameObject's height is larger or equal to the previous, then go to the right
                if (goArray[index].transform.localScale.y >= goArray[index - 1].transform.localScale.y)
                    index++;
                // Else if the current array element is smaller than the previous, swap the two and go backwards
                else
                {
                    GameObject temp; //Use a temporary GameObject to hold the current array GO that will be swapped with another
                    temp = goArray[index];             //Swap the current with the previous 
                    goArray[index] = goArray[index - 1];
                    goArray[index - 1] = temp;
                    index--; //Go backwards to previous game object

                    //Add in the physical swapping of the cubes
                    tempPosition = goArray[index].transform.localPosition;

                    goArray[index].transform.localPosition
                        = new Vector3(goArray[index - 1].transform.localPosition.x,
                        tempPosition.y,
                        tempPosition.z);

                    goArray[index - 1].transform.localPosition
                        = new Vector3(tempPosition.x,
                        goArray[index - 1].transform.localPosition.y,
                        goArray[index - 1].transform.localPosition.z);
                }
            }
            return;
        }

        public void InitialiseCubes()
        {
            gnomes = new GameObject[gnomeAmount]; //Make new array of cubes to have the max height

            for (int i = 0; i < gnomeAmount; i++)
            {
                int random = Random.Range(1, maxCubeHeight + 1); //To generate numbers up to the max 
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube); //create cube
                cube.transform.localScale = new Vector3(0.9f, random, 1); //generate cubes of different heights (in the same position)
                cube.transform.position = new Vector3(i, random / 2.0f, 0); //Cubes are lined up next to each other
                cube.transform.parent = transform; //set this GO as the parent holder of the cubes
                gnomes[i] = cube; //assign each cube to the array in the order they are generated
            }

            //Setting new position of the cube container to match the camera view
            transform.position = new Vector3(-gnomeAmount / 2f, -maxCubeHeight / 2.0f, 0);
        }
    }
}