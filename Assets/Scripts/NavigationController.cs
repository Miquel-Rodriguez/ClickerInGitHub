using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigationController : MonoBehaviour
{

    [SerializeField] public int initalPanel;

    [SerializeField] GameObject[] panels;
    [SerializeField] GameObject ClickPanel;
    [SerializeField] GameObject PcPanel;

    private void Start()
    {
        if (initalPanel == 0)
        {
            ClickPanel.SetActive(true);
            PcPanel.SetActive(false);
        }
        else {
            PcPanel.SetActive(true);
            ClickPanel.SetActive(false);
        }
        


        if(panels != null)
        {
            foreach (GameObject panel in panels)
            {
                panel.SetActive(false);
             
            }
        }
        
    }


    public void DesactivatePanelArray(GameObject thispa)
    {
        foreach (GameObject panel in panels)
        {
            
                if (!panel.name.Equals(thispa.name))
                {
                    panel.SetActive(false);
                }
            
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
