using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IsSus.Sorting
{
    public class IndividualGnome : MonoBehaviour
    {
        //Get reference to the colour sort
        public ColourSorting sort;
        private Material myMat;

        // Start is called before the first frame update
        void Start()
        {
            sort.GetComponent<ColourSorting>();
            myMat = gameObject.GetComponent<Renderer>().material;
        }

        // Update is called once per frame
        void Update()
        {
            //Check the material on the gnome and update the rest of the gnomes to match IT WORKS!
            if (Input.GetKey(KeyCode.Space))
            {
                StartCoroutine(ColourTransition());
            }
        }

        IEnumerator ColourTransition()
        {
            sort.CheckColour(myMat.color);
            yield return new WaitForSeconds(1f);
        }
    }
}
