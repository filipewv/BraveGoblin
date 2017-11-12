using UnityEngine;
using System.Collections;
using System;

public class TimeController : MonoBehaviour {
    public Main main;
    public GameObject mainContainer;
    public bool getNewTime, gameStart;
    public DateTime currentDate;
    public DateTime oldDate;
    public PlayerStatus playerStatus;
    public GameObject contDb;

    void Start()
    {
        //TimeVerify();
    }

    public void TimeVerify()
    {
        currentDate = System.DateTime.Now;

        long temp = Convert.ToInt64(PlayerPrefs.GetString("sysString"));
        TimeSpan lifeTime = new TimeSpan(0, 0, 0, 1, 0);
        DateTime oldDate = DateTime.FromBinary(temp);

        TimeSpan difference = currentDate.Subtract(oldDate);
        Debug.Log("Difference: " + difference);
        if (difference > lifeTime && !gameStart)
        {
            gameStart = true;
            playerStatus.life = playerStatus.maxLife;
            getNewTime = true;
            mainContainer = GameObject.FindGameObjectWithTag("Main");
            main = mainContainer.GetComponent<Main>();
            main.RetrieveStatus();
        }
    }

    void OnApplicationQuit()
    {
        //Save the current system time as a string in the player prefs class
        //if (getNewTime)
        //{
        //    gameStart = false;
        //    PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());
        //    print("Saving this date to prefs: " + System.DateTime.Now);
        //}
    }
}
