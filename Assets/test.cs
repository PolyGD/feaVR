using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class test : MonoBehaviour {

   public ZombieScript zombie;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
      if (Input.GetKeyDown (KeyCode.Space)) {
         zombie.kill ();
         print ("Kill");
      }
	}
}
