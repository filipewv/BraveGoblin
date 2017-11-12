using UnityEngine;
using System.Collections;

public class Chest : MonoBehaviour {
    public GameObject OpenParticle, BrokenParticle;
	
	// Update is called once per frame
	void Update () {
	
	}

    private void DestroyIt()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && !Player.PlayerInstance.dead)
        {
            Debug.Log("Colidiu com player");
            Instantiate(OpenParticle, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);
        }
        else if (other.gameObject.tag == "Death")
        {
            Instantiate(BrokenParticle, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.identity);
            Invoke("DestroyIt", .5f);            
        }
    }
}
