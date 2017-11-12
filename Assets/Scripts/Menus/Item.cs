using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Item : MonoBehaviour {
    public BuyItem buy;
    public string name;
    public int price, diamond, lvl, life, regen, type;
    public bool purchased;
    public int itemNumber;

    public void SendItem()
    {
        buy.itemNumber = itemNumber;
        Debug.Log(itemNumber);
        //renderer.material.color = Color.red;
        //this.GetComponent<Button>().interactable = false;
    }

    void Update()
    {
        if (purchased && this.GetComponent<Button>().interactable)
        {
            this.GetComponent<Button>().interactable = false;
        }
    }

    public void PurchaseOnline()
    {
        if (itemNumber == 10)
        {
            IAPManager.Instance.BuyConsumable("PACK_DIAMONDS_5");
        }
        else if (itemNumber == 11)
        {
            IAPManager.Instance.BuyConsumable("PACK_DIAMONDS_20");
        }
        else if (itemNumber == 12)
        {
            IAPManager.Instance.BuyConsumable("PACK_DIAMONDS_50");
        }
    }

}
