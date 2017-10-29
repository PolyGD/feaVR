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
         try {
            using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass ("quinteiro.nathan.feavr.Unity.FeavrReceiver")) {
               int bpm = cls_UnityPlayer.CallStatic<int> ("getVal");
               text.text = "BPM: " + bpm + "  " + + Random.Range(0,10);   
            }
         } catch {
            text.text = "Impossible" + Random.Range(0,10);
         }
      }
	}
}
