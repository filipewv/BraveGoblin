using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {
    public GameObject Armors, Potions, Special;
    public GameObject ShopCanvas, MenuCanvas;

    public void ShowArmors()
    {
        DisableAll();
        Armors.SetActive(true);
    }
    
    public void ShowPotions()
    {
        DisableAll();
        Potions.SetActive(true);
    }
    
    public void ShowSpecial()
    {
        DisableAll();
        Special.SetActive(true);
    }

    public void BackShop()
    {
        ShopCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
    }

    void DisableAll()
    {
        Armors.SetActive(false);
        Potions.SetActive(false);
        Special.SetActive(false);
    }
}
