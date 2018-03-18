using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieScript : TargetScript {

   public Animator animator;
   public GameObject player;
   private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
      agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
      agent.destination = player.transform.position; 
	}

   public override void kill() {
      print ("I am dead");
      animator.SetTrigger("dies");
   }
}
