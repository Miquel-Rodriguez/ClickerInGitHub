using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] GameObject firstStop;
    [SerializeField] NumberController bits;
    [SerializeField] GameObject secondStop;
    [SerializeField] GameObject secondStop2;
    [SerializeField] GameObject secondStop3;
    [SerializeField] GameObject shopStop;
    [SerializeField] GameObject shopStop2;
    [SerializeField] GameObject shopStop3;
    [SerializeField] GameObject shopStop4;
    [SerializeField] GameObject shop;
    [SerializeField] GameObject PcPanel;
    bool aux = false;


    [SerializeField] GameObject T1;
    [SerializeField] GameObject T2;
    [SerializeField] GameObject T3;
    [SerializeField] GameObject T4;
    [SerializeField] GameObject T5;
    [SerializeField] GameObject T6;
    [SerializeField] GameObject T7;
    [SerializeField] GameObject T8;

    void Awake()
    {
        PlayerPrefs.DeleteAll();
    }

    // Start is called before the first frame update
    void Start()
    {
        T1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (firstStop.activeInHierarchy && Input.GetMouseButtonDown(0))
        {
            firstStop.SetActive(false);
        }

        if (bits.currentBits >= 12)
        {
            if (aux == false)
            {
                T1.SetActive(false);
                secondStop.SetActive(true);
                secondStop2.SetActive(true);
                secondStop3.SetActive(true);
                aux = true;
            }
           
        }

        if (secondStop.activeInHierarchy && PcPanel.activeInHierarchy)
        {
            secondStop.SetActive(false);
            secondStop2.SetActive(false);
            secondStop3.SetActive(false);
            T2.SetActive(true);
        }

        if (shop.activeInHierarchy && shopStop.activeInHierarchy)
        {
            shopStop.SetActive(false);
            shopStop2.SetActive(false);
            shopStop3.SetActive(false);
            shopStop4.SetActive(false);
        }
    }


    public void ActiveInformationPanelTutrial()
    {
        T2.SetActive(false);
        T3.SetActive(true);
    }

    public void ActivePanelGoToGaccha()
    {
        T3.SetActive(false);
        T4.SetActive(true);
    }

    public void ActivePanelGaccha()
    {
        T4.SetActive(false);
        T5.SetActive(true);
    }

    public void DesactiveGacha()
    {
        T5.SetActive(false);
    }

    public void ActiveReturnToMainScreen()
    {
        T6.SetActive(true);
    }

    public void ActiveT7()
    {
        T6.SetActive(false);
        T7.SetActive(true);
    }

    public void ActiveT8()
    {
        T7.SetActive(false);
        T8.SetActive(true);
    }

    public void closeAll()
    {

    }
}
