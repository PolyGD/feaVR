using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   void OnTriggerEnter(Collider other) {
      print ("lol");
      //Destroy(other.gameObject);
      Vector3 pos = other.transform.position;
      pos.y = 0;
      other.transform.position = pos;
   }
}
