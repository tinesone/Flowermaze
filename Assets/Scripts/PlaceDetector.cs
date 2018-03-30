using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detect : MonoBehaviour {

    public GameObject Tile;


	// Use this for initialization
	void Start () {
        for (int vector = 1; vector <= 100; vector++) {
            Instantiate(Tile, new Vector3(vector, 0, 0), transform.rotation);
            Instantiate(Tile, new Vector3(0, vector, 0), transform.rotation);
            Instantiate(Tile, new Vector3(vector * -1, 0, 0), transform.rotation);
            Instantiate(Tile, new Vector3(0, vector * -1, 0), transform.rotation);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}