using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {
    void OnMouseDown()
    {
        Debug.Log("Clicado no tutorial");
    }
    public void CloseTutorial()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }
}
