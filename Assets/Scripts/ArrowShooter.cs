using UnityEngine;
using System.Collections;

public class ArrowShooter : MonoBehaviour {
    public Animator anim;
    public Transform arrow;
    public Arrow arrowScript;
    public bool toLeft;
	// Use this for initialization
	void Start () {
        Invoke("ShootArrow",1);
        if (toLeft)
        {
            this.transform.localScale *= -1;      
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void ShootArrow()
    {
        if (toLeft)
        {
            Transform newArrow = Instantiate(arrow, new Vector3(this.transform.position.x - 0.3f, this.transform.position.y, this.transform.position.z), this.transform.rotation) as Transform;
            arrowScript = newArrow.GetComponent<Arrow>();
            newArrow.transform.localScale *= -1;
        }
        else
        {
            Transform newArrow = Instantiate(arrow, new Vector3(this.transform.position.x + 0.3f, this.transform.position.y, this.transform.position.z), this.transform.rotation) as Transform;
            arrowScript = newArrow.GetComponent<Arrow>();
        }
        arrowScript.left = toLeft;
        Invoke("ShootArrow", 1);
    }


}
