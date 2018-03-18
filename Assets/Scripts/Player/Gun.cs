using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public int damage = 10;
    public float range = 100f;

    public Camera fpsCam;
    public GameObject bulletCreator;
    public GameObject socketCreator;

    public GameObject bullet;
    public GameObject socket;

    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
            CreateBullet();
        }
    }

    void Shoot() {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) {
            TargetScript target;
            if ((target = hit.transform.GetComponent<TargetScript>()) != null) {
                target.damage(damage);
            }
        }
    }

    void CreateBullet() {
        GameObject createdSocket = Instantiate(socket, socketCreator.transform);
        Vector3 socketDirection = (createdSocket.transform.up * 2 + createdSocket.transform.right);
        createdSocket.GetComponent<Rigidbody>().AddForce(socketDirection, ForceMode.Impulse);
        Destroy(createdSocket, 15f);

        GameObject createdBullet = Instantiate(bullet, bulletCreator.transform);
        Vector3 bulletDirection = (createdBullet.transform.forward * 5);
        createdBullet.GetComponent<Rigidbody>().AddForce(bulletDirection, ForceMode.Impulse);
        Destroy(createdBullet, 10f);
    }
}
