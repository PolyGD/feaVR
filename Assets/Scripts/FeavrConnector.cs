using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FeavrConnector : MonoBehaviour {

   private class Test
   {
      public bool[] lamps;
   }

   public static int bpm;
   public FeavrController player;
   private string commandEvent;
   public Light[] lights;

   private bool multiplayer = true;

   float time;
   private int iter = 0;

	// Use this for initialization
	void Start () {
      bpm = -1;
      time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

      if (Time.time - time > 0.2) {

         if (!multiplayer) {
            iter++;
            if (iter % 40 == 0) {
               iter = 0;
               for (int i = 0; i < lights.Length; i++) {
                  if (Random.value > 0.3) {
                     lights [i].intensity = 1;
                  } else {
                     lights [i].intensity = 0;
                  }
               }

               Test t = new Test ();
               t.lamps = new bool[3];
               t.lamps [0] = true;

               string tstring = JsonUtility.ToJson (t);
               print(tstring);

               string msg = "{\"lamps\":[true,false,false]}";
                  
               Test test = JsonUtility.FromJson<Test> (msg);
               Debug.Log (JsonUtility.ToJson(test));

                 

            }
         } else {
            try {
               using (AndroidJavaClass cls_UnityPlayer = new AndroidJavaClass ("quinteiro.nathan.feavr.Unity.FeavrReceiver")) {
                  bpm = cls_UnityPlayer.CallStatic<int> ("getBPM");
                  cls_UnityPlayer.CallStatic ("setPosition", player.gameObject.transform.position.x, player.gameObject.transform.position.z);

                  commandEvent = cls_UnityPlayer.CallStatic<string> ("getEvent");
                  if(commandEvent != null) {
                     //multiplayer = false;

                     Test test = JsonUtility.FromJson<Test> (commandEvent);
                     for(int i = 0; i < test.lamps.Length; i++) {
                        if (test.lamps[i]) {
                           lights [i].intensity = 1;
                        } else {
                           lights [i].intensity = 0;
                        }
                     }
                  }

               }
            } catch {
               bpm = -100;
            }
         }
      }
	}
}
