using UnityEngine;
using System.Collections;

public class Spear : MonoBehaviour {
    public Transform spear;
    public float distance, speed, initialPosition;
    private bool right, stoped;
	// Use this for initialization
	void Start () {
        initialPosition = spear.transform.position.x;
        distance += initialPosition;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        if (!stoped)
        {            
            if (right)
            {
                spear.transform.position -= spear.transform.position.normalized * speed * Time.deltaTime;
            }
            else
            {
                spear.transform.position += spear.transform.position.normalized * speed * Time.deltaTime;
            }
        }
        
	}

    void Move()
    {
        if (spear.transform.position.x > distance)
        {
            right = false;
        }
        else if (spear.transform.position.x < initialPosition)
        {
            right = true;
            if (!stoped)
            {
                stoped = true;
                Invoke("Restart", 1);                
            }
        }

    }

    void Restart()
    {
        spear.transform.position -= spear.transform.position.normalized * speed * Time.deltaTime;
        stoped = false;
    }
}
