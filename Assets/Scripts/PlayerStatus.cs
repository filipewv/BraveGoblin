using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStatus : MonoBehaviour {
    public int playerStart;
    public int life, maxLife, money, diamonds, lvl, armor, nivel;
    public int nextLvl;
    public float xp;
    public int[] Stars;
    public GameObject mainContainer;
    public Main main;
    public TimeController timeController;
    public SaveInformation saveInformation;

    void Awake()
    {
        mainContainer = GameObject.FindGameObjectWithTag("Main");
        main = mainContainer.GetComponent<Main>();
        saveInformation = gameObject.GetComponent<SaveInformation>();
    }
	void Start () {
        DontDestroyOnLoad(this.gameObject);
        saveInformation.Load();
        //LoadInformation.LoadAllInformation();
        if (playerStart == 0)
        {
            StartInformation();
            //LoadInformation.LoadAllInformation();
        }
        //timeController.TimeVerify();
        main.RetrieveStatus();
        //if (xp >= nextLvl)
        //{
        //    LevelUp();
        //    main.RetrieveStatus();
        //}
      //  PrefabUtility.ReplacePrefab(instance, PrefabUtility.GetPrefabParent(instance), ReplacePrefabOptions.ConnectToPrefab);
        if (life < 0)
        {
            life = 0;
        }
	}

    public void LevelUp()
    {
        lvl++;
        xp -= nextLvl;
        nextLvl += nextLvl;
        saveInformation.Save();
    }

    public void StartInformation()
    {
        //GameInformation.PlayerLevel = 0;
        //GameInformation.PlayerGold = 0;
        //GameInformation.PlayerDiamonds = 50;
        //GameInformation.PlayerLife = 5;
        //GameInformation.PlayerMaxLife = 5;
        //GameInformation.PlayerXP = 1f;
        //GameInformation.PlayerNivel = 0;
        //GameInformation.PlayerArmor = 0;
        //GameInformation.PlayerStart = 1;
        //GameInformation.PlayerNextLvl = 1000;
        //GameInformation.PlayerStars = new int[20];
        //SaveInformation.SaveAllInformation();
        lvl = 1;
        money = 0;
        diamonds = 10;
        life = 5;
        maxLife = 5;
        xp = 1;
        nivel = 1;
        nextLvl = 1000;
        Stars = new int[20];        
        saveInformation.Save();
        main.RetrieveStatus();
    }

    public void getData(PlayerStatus status)
    {
        lvl = status.lvl;
        money = status.money;
        diamonds = status.diamonds;
        life = status.life;
        maxLife = status.maxLife;
        xp = status.xp;
        nivel = status.nivel;
        armor = status.armor;
        playerStart = status.playerStart;
        nextLvl = status.nextLvl;
        Stars = status.Stars;
        for (int i = 0; i < GetStars().Length; i++)
        {
            Stars[i] = status.Stars[i];
        }

        //Debug.Log(GameInformation.PlayerStars.Length);
    }

    private int[] GetStars()
    {
        return Stars;
    }
    

    void OnApplicationQuit()
    {
        saveInformation.Save();
        Debug.Log("salvando informações do sistema");
    }
}
