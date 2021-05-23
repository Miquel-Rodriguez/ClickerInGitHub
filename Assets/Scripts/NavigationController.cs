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
    [SerializeField] AudioManager audioManager;

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

    private void Update()
    {
       
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
    }


    public void DesactivatePanelArray(GameObject thispa)
    {
        foreach (GameObject panel in panels)
        {

            if (!panel.name.Equals(thispa.name) && !panel.name.Equals(ClickPanel.name))
            {
                panel.SetActive(false);
            }
            else thispa.SetActive(true);
            
        }
        audioManager.Play("ButtonClick");
    }

    public void ChangeStatePanel(GameObject canvas)
    {
        if (canvas.activeSelf)
        {
            canvas.SetActive(false);
        }else canvas.SetActive(true);
        audioManager.Play("ButtonClick");
    }

    public void ChangeScene(int numScene)
    {
        audioManager.Play("ButtonClick");
        SceneManager.LoadScene(numScene);
    }




}
