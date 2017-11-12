using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BuyItem : MonoBehaviour
{
    public Item[] item;
    public Player player;
    public PlayerStatus playerStatus;
    public Text diamondPrice, goldPrice;
    public Main mainFunctions;
    public Canvas payMethod;
    public GameObject success, failed, choose;
    public int itemNumber;
    public int paymentType;
    private GameObject bt;
    private GameObject statusContainer;

    void Start()
    {
        statusContainer = GameObject.FindGameObjectWithTag("Status");
        playerStatus = statusContainer.GetComponent<PlayerStatus>();
    }
    public void openPayMethod()
    {
        payMethod.enabled = true;
        choose.SetActive(true);
        goldPrice.text = item[itemNumber].price.ToString();
        diamondPrice.text = item[itemNumber].diamond.ToString();
    }

    public void Purchase(bool canBuy)
    {
        if (!item[itemNumber].purchased && canBuy)
        {
            if (item[itemNumber].type == 1)
            {
                item[itemNumber].purchased = true;
                Armor();
            }
            if (item[itemNumber].type == 2)
            {
                Potion();
            }
            if (mainFunctions != null)
            {
                mainFunctions.RetrieveStatus();
            }
            choose.SetActive(false);
            success.SetActive(true);
        }
    }
    public void Armor()
    {
        playerStatus.maxLife = item[itemNumber].life;
        Potion();
        if (item[itemNumber].itemNumber == 0)
        {
            playerStatus.armor = 2;
        }
        else if (item[itemNumber].itemNumber == 1)
        {
            playerStatus.armor = 3;
        }
        else if (item[itemNumber].itemNumber == 2)
        {
            playerStatus.armor = 4;
        }
        else if (item[itemNumber].itemNumber == 3)
        {
            playerStatus.armor = 5;
        }
        mainFunctions.RetrieveStatus();
    }

    public void Potion()
    {
        if (playerStatus.life < playerStatus.maxLife)
        {
            playerStatus.life += item[itemNumber].regen;
            if (playerStatus.life > playerStatus.maxLife)
            {
                playerStatus.life = playerStatus.maxLife;
            }
            mainFunctions.RetrieveStatus();
        }
    }

    public void paymentMethod(int method)
    {
        if (method == 0 && playerStatus.money >= item[itemNumber].price && playerStatus.lvl >= item[itemNumber].lvl)
        {
            if (playerStatus.life <= playerStatus.maxLife)
            {
                playerStatus.money -= item[itemNumber].price;
                Purchase(true);
            }
            else
            {
                choose.SetActive(false);
                failed.SetActive(true);
                Debug.Log("Falha 1");
            }

        }
        else if (method == 1 && playerStatus.diamonds >= item[itemNumber].diamond && playerStatus.lvl >= item[itemNumber].lvl)
        {
            if (playerStatus.life <= playerStatus.maxLife)
            {
                playerStatus.diamonds -= item[itemNumber].diamond;
                Purchase(true);
            }
            else
            {
                choose.SetActive(false);
                failed.SetActive(true);
                Debug.Log("Falha 2");
            }
        }
        else
        {
            Debug.Log("Falha 3");
            choose.SetActive(false);
            failed.SetActive(true);
        }
    }

    public void closeWindows()
    {
        choose.SetActive(false);
        failed.SetActive(false);
        success.SetActive(false);
        payMethod.enabled = false;
    }
}
