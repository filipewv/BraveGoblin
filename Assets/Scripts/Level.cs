using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
    public Player player;
    public PlayerStatus playerStatus;
    public GameObject padlock, star1, star2 , star3, stars, statusContainer;
    private bool locked = true;
    public int nivel;

	// Use this for initialization
	void Start () {
        statusContainer = GameObject.FindGameObjectWithTag("Status");
        playerStatus = statusContainer.GetComponent<PlayerStatus>();
        if (nivel <= playerStatus.nivel)
        {
            locked = false;
            padlock.SetActive(false);
            stars.SetActive(true);
            StarNumbers();
        }
        else
        {
            stars.SetActive(false);
        }
	}

    public void playLevel(int level)
    {
        if (level <= playerStatus.nivel + 1 && playerStatus.life > 0)
        {
            Application.LoadLevel("level-" + level);
        }
    }

    void StarNumbers()
    {
        if (playerStatus.Stars[nivel] >= 1)
        {
            star1.SetActive(true);
        }
        if (playerStatus.Stars[nivel] >= 2)
        {
            star2.SetActive(true);
        }
        if (playerStatus.Stars[nivel] >= 3)
        {
            star3.SetActive(true);
        }
        if (playerStatus.Stars[nivel] == 0)
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
        }
    }
}
