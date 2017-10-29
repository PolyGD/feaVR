using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeavrConnector : MonoBehaviour {

   public static int bpm;

	// Use this for initialization
	void Start () {
      bpm = -1;
	}
	
	// Update is called once per frame
	void Update () {
      try {
         using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass ("quinteiro.nathan.feavr.Unity.FeavrReceiver")) {
            bpm = cls_UnityPlayer.CallStatic<int> ("getVal");
         }
      } catch {
         
      }
	}
}
