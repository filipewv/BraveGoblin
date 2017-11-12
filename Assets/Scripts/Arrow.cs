using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
    public Animator anim;
    public float speed;
    public bool left;

    void Start()
    {
        anim.GetComponent<Animator>();
    }

    void Update()
    {
        if (left)
        {
            transform.GetComponent<Rigidbody2D>().velocity = -Vector2.right * speed;
        }
        else
        {
            transform.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        anim.SetTrigger("broken");
        Invoke("DestroyArrow", .2f);
    }

    void DestroyArrow()
    {
        Destroy(this.gameObject);
    }
}
