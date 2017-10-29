using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubescript : MonoBehaviour {

   bool go = true;
   Vector3 pos;

	// Use this for initialization
	void Start () {
      pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
      if (go) {
         transform.position += Vector3.up * Time.deltaTime;
         if (Vector3.Distance (transform.position, pos) > 2) {
            go = false;
         }
      } else {
         transform.position -= Vector3.up * Time.deltaTime;
         if (Vector3.Distance (transform.position, pos) < 0.5) {
            go = true;
         }
      }
	}
}
