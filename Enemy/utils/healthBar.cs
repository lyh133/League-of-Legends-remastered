using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Image barImage;


    // Update is called once per frame
    public void setHealth(float normal){
    	barImage.fillAmount = normal;
    }
}
