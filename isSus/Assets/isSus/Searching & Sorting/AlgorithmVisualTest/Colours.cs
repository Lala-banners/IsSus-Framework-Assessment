using System;
using System.Collections.Generic;
using UnityEngine;

public class Colours : IComparable
{
    //List of colours to compare
    public List<Color> colours = new List<Color>()
    {
        Color.red,
        Color.blue,
        Color.yellow,
        Color.green,
    };

    protected float currentCol;

    //COMPARE GNOMES BY COLOURS!
    public int CompareTo(object obj)
    {
        if (obj == null)
            return 1;

        //Write out comparator
        Colours otherCol = obj as Colours;

        if (otherCol != null)
        {
            //Compare the colours
            if (this.currentCol > otherCol.currentCol)
            {
                return 1;
            }

            return 0;
        }
        else
        {
            //We couldn't cast the object to a colour so throw an exception
            throw new ArgumentException("Object is NOT a Colour");
        }
    }

    public Colours(float _col)
    {
        currentCol = _col;
    }

    public override string ToString()
    {
        return currentCol.ToString();
    }
}
