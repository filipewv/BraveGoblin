using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
    public GameController game;
    public GameObject controller;
    public GameObject clickParticle;
    public AudioClip destroyed, collide, collidePlayer;
    private float audioClipL;
	// Use this for initialization
	void Start () {
        controller = GameObject.FindGameObjectWithTag("Controller");
        game = controller.GetComponent<GameController>();
        Physics2D.IgnoreLayerCollision(8, 9);
        audioClipL = GetComponent<AudioSource>().clip.length;

    }

	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown(){
        if (!game.paused)
        {
            GetComponent<AudioSource>().clip = destroyed;
            GetComponent<AudioSource>().volume = 1f;
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<Renderer>().enabled = false;
            GetComponent<AudioSource>().Play();
            game.totalClicks++;
            //clickParticle.GetComponent<ParticleSystem>().Play();
            Instantiate(clickParticle, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);
            Destroy(gameObject, audioClipL);
            //Invoke ("DestroyObject", 0.5f);            
            //DestroyObject();
        }
	}


	void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.relativeVelocity.magnitude > 1 && coll.gameObject.name != "Player")
        {
            GetComponent<AudioSource>().clip = collide;
            GetComponent<AudioSource>().volume = 0.1f;
            GetComponent<AudioSource>().Play();
        }else if (coll.relativeVelocity.magnitude > 2 && coll.gameObject.name == "Player")
        {
            GetComponent<AudioSource>().clip = collidePlayer;
            GetComponent<AudioSource>().volume = 0.1f;
            GetComponent<AudioSource>().Play();
        }
    }

	void DestroyObject(){
        //clickParticle.GetComponent<ParticleSystem>().Pause();
        Destroy (this.gameObject);
	}

}
