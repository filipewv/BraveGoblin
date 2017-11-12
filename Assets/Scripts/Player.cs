using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class Player : MonoBehaviour {
    public static Player PlayerInstance { set; get; }
    public GameController game;
    public PlayerStatus status;
    public GameObject statusContainer;
    public AudioSource audio;
    public AudioClip death, chest;
    public Animator anim;
    public BuyItem buyItem;
    public Sprite armor1, armor2,armor3,armor4,armor5;
    public int[] Stars;
   // public int money, life, diamonds, level, nextLevel, maxLife, nivel, armor;
    public float xp;
    public Text txtLife, txtGold;
    private bool hookedToSomething, finished = false;
    public bool dead = false;

	// Use this for initialization
	void Start () {
        statusContainer = GameObject.FindGameObjectWithTag("Status");
        status = statusContainer.GetComponent<PlayerStatus>();
        RefreshLife();
        Blink();
        audio = this.gameObject.GetComponent<AudioSource>();

        if (status.armor == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = armor1;
        }
        else if (status.armor == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = armor2;
        }
        else if (status.armor == 3)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = armor3;
        }
        else if (status.armor == 4)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = armor4;
        }
        else if (status.armor == 5)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = armor5;
        }
	}
	
	// Update is called once per frame
	void Awake() {
        PlayerInstance = this;
    }
  
    void FinishedLevel()
    {
        game.FinalScore();
        //Destroy(this.gameObject);
        //game.FinalScore();
    } 

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "Goal" && !dead) {
            //GetChest(this.gameObject);
            //game.FinalScore();
            audio.clip = chest;
            if (!audio.isPlaying)
            {
                audio.Play();
            }
            Invoke("FinishedLevel", .7f);
            finished = true;
            coll.gameObject.GetComponent<Rigidbody2D>().simulated = false;
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            Debug.Log("Tocou no bau");

		}
		if (coll.gameObject.tag == "Death" && !finished && !dead) {
            dead = true;
            anim.SetTrigger("Death");
            status.life--;
            audio.clip = death;
            if (!audio.isPlaying)
            {
                audio.Play();                
            }        
            RefreshLife();
            if (status.life > 0)
            {
                //gameObject.GetComponent<Rigidbody2D>().simulated = false;
                GameObject deathBlood = Instantiate(Resources.Load("PlayerDeath")) as GameObject;
                deathBlood.transform.parent = transform;
                deathBlood.transform.localPosition = new Vector3(0, .5f, -1f);
                GameObject heartLost = Instantiate(Resources.Load("HeartLost")) as GameObject;
                heartLost.transform.parent = transform;
                heartLost.transform.localPosition = new Vector3(0, .5f, -1f);
                //Instantiate( Resources.Load("PlayerDeath"), new Vector3(transform.position.x, transform.localPosition.y + .5f, -1f), transform.rotation);
                //Instantiate(clickParticle, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);
                //Instantiate(Resources.Load("PlayerDeath"), new Vector3(transform.position.x, transform.position.y - .5f, transform.position.z), transform.rotation, transform);                
                Invoke("DeathRestart", 1.5f);
            }else if (status.life <= 0){
                status.life = 0;
                GameObject adReward = Instantiate(Resources.Load("AdReward")) as GameObject;
                adReward.GetComponent<InGameShop>().openAd();
            }
            else
            {
                //game.RestartLevel();
                Debug.Log("Something is wrong on player death function");
                //Application.LoadLevel("MainMenu");
            }
        }
	}

    public void DeathRestart()
    {
        game.RestartLevel();
    }

    void Blink()
    {
        anim.SetTrigger("Blink");
        Invoke("Blink", 3);
    }

    public void RefreshLife()
    {
        txtGold.text = status.money.ToString();
        txtLife.text = status.life.ToString();
    }
}
