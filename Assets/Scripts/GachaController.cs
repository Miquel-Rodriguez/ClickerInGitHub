using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaController : MonoBehaviour
{
   public void generateNumberRandom()
    {
        int num = Random.Range(0, 100);

        if (num > 0 && num < 71)
        {
            Debug.Log("Objeto común");
        }else if(num > 70 && num < 95)
        {
            Debug.Log("Objeto raro");
        }
        else
        {
            Debug.Log("Objeto legendario");
        }
    }

}
