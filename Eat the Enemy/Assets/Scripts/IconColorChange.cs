using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class IconColorChange : MonoBehaviour
{
    public List<Color> colors;

   

    public void greenColor()
    {
        GetComponent<Image>().color = Color.green;
    }
    public void blueColor()
    {
        GetComponent<Image>().color = Color.blue;
    }

    public void redColor()
    {
        GetComponent<Image>().color = Color.red;
    }




}
