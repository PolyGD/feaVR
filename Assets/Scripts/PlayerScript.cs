using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

   public float speed=10f;     

	// Update is called once per frame
	void Update () {

      float vertical = Input.GetAxis("Vertical");
      float horizontal = Input.GetAxis("Horizontal");   
      if (Mathf.Abs(vertical)>0.01){
         Vector3 offset = Camera.main.transform.forward * vertical * speed* Time.deltaTime;
         offset.y = 0;
         if(offset.magnitude != 0) {

            offset /= Mathf.Sqrt(offset.magnitude);
            transform.position = transform.position + offset;
         }
      }
      if (Mathf.Abs(horizontal)>0.01){
         Vector3 offset = Camera.main.transform.right * horizontal * speed* Time.deltaTime;
         offset.y = 0;
         if(offset.magnitude != 0) {
               
            offset /= Mathf.Sqrt(offset.magnitude);
            transform.position = transform.position + offset;
         }
      }

	}
}
