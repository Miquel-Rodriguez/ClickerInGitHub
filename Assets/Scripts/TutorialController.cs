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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (firstStop.activeInHierarchy && Input.GetMouseButtonDown(0))
        {
            firstStop.SetActive(false);
        }

        if (bits.currentBits == 12)
        {
            if (aux == false)
            {
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
        }

        if (shop.activeInHierarchy && shopStop.activeInHierarchy)
        {
            shopStop.SetActive(false);
            shopStop2.SetActive(false);
            shopStop3.SetActive(false);
            shopStop4.SetActive(false);
        }
    }
}
