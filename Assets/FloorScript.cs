using UnityEngine;
using System.Collections;

public class FloorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Camera.main.GetComponent<MainScript>().UpdateScore(true);
            Destroy(col.gameObject);
        }
    }
}
