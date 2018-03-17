using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextScript : MonoBehaviour {

   public Text text;
   float time;
	// Use this for initialization
	void Start () {
      time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
      if (Time.time - time > 0.2) {
         time = Time.time;

         text.text = "BPM: " + FeavrConnector.bpm + "  " + + Random.Range(0,10);   

      }
	}
}
