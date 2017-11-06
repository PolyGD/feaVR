using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollScript : MonoBehaviour {

   Transform target;
   Vector3 initialPos;
   float lastSeen;

	// Use this for initialization
	void Start () {
      target = Camera.main.transform;
      initialPos = transform.position;
	}
	
	// Update is called once per frame
   void Update () {
      if (!IsInView()) {
         if (Time.time - lastSeen > 2) {
            Vector3 targetPostition = new Vector3 (target.position.x, this.transform.position.y, target.position.z);
            this.transform.LookAt (targetPostition);
         }
      } else {
         lastSeen = Time.time;
      }
	}

   private bool IsInView()
   {
      Vector3 pointOnScreen = Camera.main.WorldToScreenPoint(this.GetComponentInChildren<Renderer>().bounds.center);

      //Is in front
      if (pointOnScreen.z < 0)
      {
         return false;
      }

      //Is in FOV
      if ((pointOnScreen.x < -30) || (pointOnScreen.x > Screen.width + 30) ||
         (pointOnScreen.y < -30) || (pointOnScreen.y > Screen.height + 30))
      {
         return false;
      }

      return true;
   }
}
