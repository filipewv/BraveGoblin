using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController Instantiate { set; get; }

    public Player player;
    public PlayerStatus status;
    public SaveInformation saveInformation;
    public GameObject statusContainer;
    public AudioClip star,success;
    public AudioSource audio;

    public GameObject Shop;
    public Transform PlayerStatus;
    public Canvas score, pause;
    public Text goldText, xpText, playerLevel;
    public Image star1, star2, star3;
    public Transform xpBar;
    public int nivel;
    public int totalClicks, perfectClicks;
    public int gold, xp;
    private int currentLevel,starCount,qntStars;
    private float xpBarMaxSize;
    public bool updateXpBar,paused;
    private ArrayList stars;
    private Transform containerStatus;

    public void Awake()
    {
        Instantiate = this;
    }

    void Start () {
        //if (!status.inScene)
        //{
        //    containerStatus = Instantiate(PlayerStatus, new Vector3(0, 0, 0), transform.rotation) as Transform;            
        //}
        statusContainer = GameObject.FindGameObjectWithTag("Status");
        status = statusContainer.GetComponent<PlayerStatus>();
        saveInformation = statusContainer.GetComponent<SaveInformation>();
        //status.inScene = true;
        currentLevel = Application.loadedLevel;
        score.enabled = false;
        star1.enabled = false;
        star2.enabled = false;
        star3.enabled = false;
        audio.GetComponent<AudioSource>();
	}

    public void NextNivel()
    {
        if (status.life > 0)
        {
            Application.LoadLevel(currentLevel + 1);
        }
    }

    public void RestartLevel(){
        StoreInformation();
        saveInformation.Save();
        Debug.Log("restarting level");
        if (status.life > 0)
        {
            Application.LoadLevel(currentLevel);
        }
        else
        {
            Application.LoadLevel("MainMenu");
        }
    }

    public void FinalScore()
    {
        audio.clip = success;
        audio.Play();
        if (status.nivel <= nivel)
        {
            status.nivel = nivel + 1;
        }
        if (totalClicks <= perfectClicks)
        {
            starCount = 3;
            RefreshGame();
        }
        else if (totalClicks > perfectClicks && totalClicks <= perfectClicks * 2)
        {
            gold = (gold * 70) / 100;
            xp = (xp * 70) / 100;
            starCount = 2;
            RefreshGame();
        }
        else
        {
            gold = (gold * 40) / 100;
            xp = (xp * 40) / 100;
            starCount = 1;
            RefreshGame();            
        }
        if (status.xp >= status.nextLvl)
        {
           status.LevelUp();
        }
        score.enabled = true;
        playerLevel.text = status.lvl.ToString();
        xpBar.localScale = new Vector2 (0, xpBar.localScale.y);
        xpBarMaxSize = (status.xp * 2.126539f / status.nextLvl);
        Debug.Log("Max Size> " + xpBarMaxSize + "  local size : " + xpBar.localScale);
        updateXpBar = true;


        StoreInformation();
        saveInformation.Save();
        //ChangeNivel();
    }

    public void ScalateBar()
    {
        if (xpBar.localScale.x < xpBarMaxSize)
        {
            Debug.Log("Max Size> " + xpBarMaxSize + "  local size : " + xpBar.localScale );
            //1.06
            xpBar.localScale = new Vector2(xpBar.localScale.x + 0.01f, xpBar.localScale.y);
        }
        else
        {
            updateXpBar = false;
        }
    }
    void Update ()
    {
        if (updateXpBar)
        {
           ScalateBar();
        }
    }

    public void PauseGame()
    {
        pause.enabled = true;
        paused = true;
        Time.timeScale = 0F;
    }

    public void ContinueGame()
    {
        pause.enabled = false;
        paused = false;
        Time.timeScale = 1F;
    }

    public void ExitGame()
    {
        paused = false;
        Time.timeScale = 1F;
        StoreInformation();
        saveInformation.Save();
        Application.LoadLevel("MainMenu");
    }

    public void ShopGame()
    {
        Shop.SetActive(true);
        //Application.LoadLevel("Shop");
    }

    void RefreshGame()
    {
        status.money += gold;
        goldText.text = gold.ToString();
        xpText.text = "+ "+ xp;
        status.xp += xp;
        if (status.xp >= status.nextLvl)
        {
            status.LevelUp();
        }
        saveInformation.Save();
        Invoke("Stars", 1f);
    }

    void Stars()
    {
        qntStars += 1;
        audio.clip = star;
        audio.Play();
        if (qntStars < starCount)
        {
            Invoke("Stars",0.5f);
        }
        if (qntStars == 1)
        {
            star1.enabled = true;
        }
        if (qntStars == 2)
        {
            star2.enabled = true;
        }
        if (qntStars == 3)
        {
            star3.enabled = true;
        }

        if (status.Stars[nivel] != null)
        {
            status.Stars[nivel] = starCount;
        }
        else
        {
        }

        if (starCount == 1)
            status.Stars[nivel] = 1;
        if (starCount == 2)
            status.Stars[nivel] = 2;
        if (starCount == 3)
            status.Stars[nivel] = 3;
    }

    void OnApplicationQuit()
    {
        //StoreInformation();
        //saveInformation.Save();
    }
	
	private void StoreInformation(){
        //status.getData();
        //GameInformation.PlayerLevel = status.lvl;
        //GameInformation.PlayerGold = status.money;
        //GameInformation.PlayerDiamonds = status.diamonds;
        //GameInformation.PlayerLife = status.life;
        //GameInformation.PlayerMaxLife = status.maxLife;
        //GameInformation.PlayerXP = status.xp;
        //GameInformation.PlayerNivel = status.nivel;
        //GameInformation.PlayerArmor = status.armor;
        //GameInformation.PlayerNextLvl = status.nextLvl;
        //GameInformation.PlayerStars = status.Stars;
    }

}
