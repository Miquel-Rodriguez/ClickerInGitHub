using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyHardCoin : MonoBehaviour
{

    public int numShop;
    [SerializeField] NumberController coins;

   public void buyHardCoin()
    {
        switch (numShop)
        {
            case 1:
                IAPManager.Instance.BuyProduct(ShopProductNames.dogecoinsx2000, ProductBoughtCallback);
                break;
            case 2:
                IAPManager.Instance.BuyProduct(ShopProductNames.dogecoinsx5000, ProductBoughtCallback);
                break;
        }
    }

    private void ProductBoughtCallback(IAPOperationStatus status, string message, StoreProduct product)
    {
        if (status == IAPOperationStatus.Success)
        {//each consumable gives coins in this example
            if (product.productType == ProductType.Consumable)
                coins.dogeCoins += product.value;
        }
        else
        {            //an error occurred in the buy process, log the message for more details
            Debug.Log("Buy product failed: " + message);
        }
    }
}
       

