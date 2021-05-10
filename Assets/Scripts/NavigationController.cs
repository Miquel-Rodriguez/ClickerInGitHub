using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour
{


    [SerializeField] GameObject[] panels;
    [SerializeField] GameObject ClickPanel;
    [SerializeField] GameObject PcPanel;

    private void Start()
    {
      
           
           
       
        


        if(panels != null)
        {
            foreach (GameObject panel in panels)
            {
                panel.SetActive(false);
             
            }
        }

        ClickPanel.SetActive(true);

    }


    public void DesactivatePanelArray(GameObject thispa)
    {
        foreach (GameObject panel in panels)
        {

            if (!panel.name.Equals(thispa.name) && !panel.name.Equals(ClickPanel.name) && !panel.name.Equals(PcPanel.name))
            {
                panel.SetActive(false);
            }
            else thispa.SetActive(true);
            
        }
    }

    public void ChangeStatePanel(GameObject canvas)
    {
        if (canvas.activeSelf)
        {
            canvas.SetActive(false);
        }else canvas.SetActive(true);

    }

    public void ChangeScene(int numScene)
    {
        SceneManager.LoadScene(numScene);
    }




}
