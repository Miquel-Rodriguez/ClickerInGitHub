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
            secondStop.SetActive(true);
            secondStop2.SetActive(true);
            secondStop3.SetActive(true);
        }

        if (secondStop.activeInHierarchy && PcPanel.activeInHierarchy)
        {
            Destroy(secondStop);
            Destroy(secondStop2);
            Destroy(secondStop3);
        }

        if (shop.activeInHierarchy && shopStop.activeInHierarchy)
        {
            Destroy(shopStop);
            Destroy(shopStop2);
            Destroy(shopStop3);
            Destroy(shopStop4);
        }
    }
}
