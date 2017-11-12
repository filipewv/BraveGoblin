using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {
    //public TimeController timeGame;
    public GameObject MainMenu, Shop, Options, Map, statusContainer;
    public Text currentLife, currentMoney, currentShield, currentLevel;
    public Transform xpBar;
    public Player player;
    public PlayerStatus playerStatus;
    public SaveInformation saveInformation;
    private Transform containerStatus;
    public Transform PlayerStatusPrefab;


    void Awake()
    {
        statusContainer = GameObject.FindGameObjectWithTag("Status");
        if (statusContainer == null)
        {
            containerStatus = Instantiate(PlayerStatusPrefab, new Vector3(0, 0, 0), transform.rotation) as Transform;
            statusContainer = GameObject.FindGameObjectWithTag("Status");
        }
        playerStatus = statusContainer.GetComponent<PlayerStatus>();
        saveInformation = statusContainer.GetComponent<SaveInformation>();
        saveInformation.Load();
        
    }
    void Start()
    {
        //timeGame.TimeVerify();
        RetrieveStatus();
	}

    public void ResetAllSaves()
    {
        playerStatus.StartInformation();
    }

    public void RetrieveStatus(){
        if (playerStatus.life < 0) {
            playerStatus.life = 0;
        }
        currentLife.text = playerStatus.life.ToString();
        currentMoney.text = playerStatus.money.ToString();
        currentShield.text = playerStatus.diamonds.ToString();
        currentLevel.text = playerStatus.lvl.ToString();
        if (playerStatus.xp > 0)
        {
            Debug.Log(playerStatus.xp);
            Debug.Log(playerStatus.nextLvl);
            xpBar.localScale = new Vector2((playerStatus.xp * 1.20615f / playerStatus.nextLvl), 0.2277941f);
        }
    }

    void ResetAll()
    {
        MainMenu.SetActive(false);
        Shop.SetActive(false);
        Options.SetActive(false);
        Map.SetActive(false);
    }

    public void RateGame()
    {
#if UNITY_ANDROID
        Application.OpenURL("http://play.google.com/store/apps/details?id=com.Brightroar.BraveGoblin");
#elif UNITY_IPHONE
            Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_ID");
#endif
    }
    public void LoadMenuGame()
    {
        Application.LoadLevel("MainMenu");
    }
    public void AbleMain()
    {
        ResetAll();
        MainMenu.SetActive(true);
    }

    public void AbleShop()
    {
        ResetAll();
        Shop.SetActive(true);
    }

    public void AbleOptions(){
        ResetAll();
        Options.SetActive(true);
    }

    public void PlayGame()
    {
        ResetAll();
        Map.SetActive(true);
    }

    public void BackMenu()
    {
        ResetAll();
        MainMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
