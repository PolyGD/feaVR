using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetScript : MonoBehaviour {

   public int health = 100;


	// Use this for initialization
   void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}


   public void damage(int damage) {
      health -= damage;
      if (health <= 0) {
         this.kill ();
      }
   }

   public virtual void kill() {
   
   }
}
