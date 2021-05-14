using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenText : MonoBehaviour
{
    public float delay = 0.1f;
    public string[] fullText;
    private string currentText = "";
    bool qadaws = false;
    int aux1 = 0;
    int aux2 = 0;

    IEnumerator showText()
    {
        for (int i = aux1; i<fullText[0].Length; i++)
        {  
            if (i < fullText[0].Length)
            {
                currentText = fullText[aux2].Substring(0, i);
                this.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
                aux1++;
                break;
            }
            else
            {
                currentText = fullText[aux2 + 1].Substring(0, i);
                this.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
                aux1++;
                break;
            }
           

        }
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
           StartCoroutine(showText());
          
            
        }
        
    }
}
