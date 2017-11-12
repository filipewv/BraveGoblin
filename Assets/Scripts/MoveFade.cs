using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFade : MonoBehaviour {
    public float speed, timeVisible, fadePerSecond;
    private bool fade = false;
	// Use this for initialization
	void Start () {
        		
	}

    private void Awake()
    {
        Invoke("FadeObj", timeVisible);
    }

    void FadeObj()
    {
        fade = true; 
    }
    // Update is called once per frame
    void Update () {
        transform.GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
        if (fade)
        {
            var material = GetComponent<Renderer>().material;
            var color = material.color;

            material.color = new Color(color.r, color.g, color.b, color.a - (fadePerSecond * Time.deltaTime));
        }
    }
}
