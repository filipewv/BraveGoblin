using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveInformation : MonoBehaviour{
    public static PlayerStatus playerStatus;
    public GameObject playerContainer;

    public static SaveInformation Instance { get; set; }
    public GameInformation state;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        Instance = this;
        playerContainer = GameObject.FindGameObjectWithTag("Status");
        playerStatus = playerContainer.GetComponent<PlayerStatus>();
        Load();

        Debug.Log(Helper.Serialize<GameInformation>(state));
    }
    void Start()
    {
    }

    // Save the state of SaveState
    public void Save()
    {
        state.PlayerArmor = playerStatus.armor;
        state.PlayerLevel = playerStatus.lvl;
        state.PlayerDiamonds = playerStatus.diamonds;
        state.PlayerGold = playerStatus.money;
        state.PlayerLife = playerStatus.life;
        state.PlayerMaxLife = playerStatus.maxLife;
        state.PlayerXP = playerStatus.xp;
        state.PlayerNivel = playerStatus.nivel;
        state.PlayerStart = 1;
        state.PlayerNextLvl = playerStatus.nextLvl;
        state.PlayerStars = playerStatus.Stars;
        PlayerPrefs.SetString("save", Helper.Serialize<GameInformation>(state));
    }

    // Load the last SaveState
    public void Load()
    {
        //Verify if already have a save
        if (PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<GameInformation>(PlayerPrefs.GetString("save"));
            playerStatus.armor = state.PlayerArmor;
            playerStatus.lvl = state.PlayerLevel;
            playerStatus.diamonds = state.PlayerDiamonds;
            playerStatus.money = state.PlayerGold;
            playerStatus.life = state.PlayerLife;
            playerStatus.maxLife = state.PlayerMaxLife;
            playerStatus.xp = state.PlayerXP;
            playerStatus.nivel = state.PlayerNivel;
            playerStatus.playerStart = state.PlayerStart;
            playerStatus.nextLvl = state.PlayerNextLvl;
            playerStatus.Stars = state.PlayerStars;
        }
        else
        {
            state = new GameInformation();
            Save();
            Debug.Log("No save file has found, creating a new one");
        }
    }
    

}
