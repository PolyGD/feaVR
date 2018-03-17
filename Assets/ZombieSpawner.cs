using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour {

   public GameObject Zombie;
   float lastSpawnTime;
   public float spawnTime = 5;

	// Use this for initialization
	void Start () {
      lastSpawnTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
      if (Time.time > lastSpawnTime + spawnTime) {
         lastSpawnTime = Time.time;
         spawnZombie ();
      }
	}

   void spawnZombie() {
      GameObject newZombie = Instantiate (Zombie);
   }
}
