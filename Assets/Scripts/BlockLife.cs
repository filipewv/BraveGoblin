using UnityEngine;
using System.Collections;

public class BlockLife : MonoBehaviour {
	public Sprite animation1, animation2, animation3;
	public int life = 3;

	private SpriteRenderer spriteRenderer; 
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		ChangeSprite ();
	}

	// Change sprite
	void ChangeSprite (){
		switch (life) {
		case 3:
			spriteRenderer.sprite = animation1;
			break;
		case 2:
			spriteRenderer.sprite = animation2;
			break;
		case 1:
			spriteRenderer.sprite = animation3;
			break;
		case 0:
			Destroy (this.gameObject);
			break;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.relativeVelocity.magnitude > 15){
			life -= 2;
		} else if(coll.relativeVelocity.magnitude > 10){
			life --;
		}
    }
}
