using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {
    private SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public Animator anim;
    public AudioSource audio;
    public AudioClip bip, explosion;
    public GameObject explodeParticle;
    private BoxCollider2D BoxCollider;
    private CircleCollider2D CircleCollider;

    public bool ball;
    public float Radius = 5.0F;
    public float Power = 10.0F;
    private int countBomb;
    private bool armed, exploding;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        audio.clip = bip;
	}

    void OnMouseDown()
    {
        if (!armed)
        {
            armed = true;
            BombTimer();
            audio.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && countBomb == 0 && !armed)
        {
            armed = true;
            audio.Play();
            BombTimer();
        }
    }

    public static void AddExplosionForce(Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
    {
        var dir = (body.transform.position - expPosition);
        float calc = 1 - (dir.magnitude / expRadius);
        if (calc <= 0)
        {
            calc = 0;
        }

        body.AddForce(dir.normalized * expForce * calc);
    }

    void BombTimer()
    {
        anim.SetBool("armed", true);
        if (countBomb == 3)
        {
            audio.clip = explosion;
            ExplodeBomb();
            //Invoke("ExplodeBomb", .6f);
        }
        else
        {
            Invoke("BombTimer", .5f);
            countBomb++;
        }
    }
 
    void ExplodeBomb()
    {
        audio.Play();

        Instantiate(explodeParticle, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);
        AddExplosionForce(GetComponent<Rigidbody2D>(), Power * 100, new Vector2(Screen.width / 2, 0 ), Radius);
        exploding = true;
        rb.gravityScale = 0;
        rb.velocity = new Vector2(0,0);
        GetComponent<Renderer>().enabled = false;
        Destroy(gameObject, explosion.length);
        Invoke("selfDestroy", 0.2f);
        if (ball)
        {
            CircleCollider = this.gameObject.GetComponent<CircleCollider2D>();
            CircleCollider.radius = 1f;
        }
        else
        {
            BoxCollider = this.gameObject.GetComponent<BoxCollider2D>();
            //BoxCollider.size = new Vector2(2f, 2f);
        }
    }

    void selfDestroy()
    {
        GetComponent<Rigidbody2D>().simulated = false;
        //Destroy(this.gameObject);
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (exploding && coll.gameObject.tag != "Background")
        {
            Destroy(coll.gameObject);
        }
    }
}
