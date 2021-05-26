using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buyItemDollars(ShopItem item) {
        int dinero = GetComponent<NumberController>().numDolars;
        if (dinero>=item.price)
        {
            GetComponent<NumberController>().numDolars -= item.price;
            switch (item.itemID) {
                case 0:
                    GetComponent<GachaController>().numTicketsSkins += item.quantity;
                    break;
                case 1:
                    GetComponent<GachaController>().numTicketsPowerUps += item.quantity;
                    break;
                case 2:
                    GetComponent<GachaController>().numTicketsPassive += item.quantity;
                    break;
            }
        }
    }

    public void buyItemHardCurrency(ShopItem item)
    {
        int dinero = GetComponent<NumberController>().dogeCoins;
        if (dinero >= item.price)
        {
            GetComponent<NumberController>().dogeCoins -= item.price;
            switch (item.itemID)
            {
                case 2:
                    GetComponent<NumberController>().numDolars += item.quantity;
                    break;
                case 3:
                    GetComponent<NumberController>().currentBits += item.quantity;
                    break;
            }
        }
    }
}
