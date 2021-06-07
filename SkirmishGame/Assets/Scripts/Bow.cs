using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

public class Bow : MonoBehaviour
{

    public GameObject arrowPrefab;
    public float reloadTime = 2f;
    public float launchForce = 100f;
    public float muzzleDistance = 3f;


    private float reloadTimeStamp = 0f;
    private bool canShoot = true;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!canShoot)
        {
            if (Time.time - reloadTimeStamp > reloadTime)
                canShoot = true;
        }
        else
        {
            Shoot();
        }

    }


    public void Shoot()
    {
        if (!canShoot)
            return;

        reloadTimeStamp = Time.time;
        canShoot = false;

        UnityEngine.Vector3 launchPosition = transform.position + transform.forward * muzzleDistance;

        GameObject arrow = Instantiate(arrowPrefab, launchPosition, Quaternion.identity);

        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.AddForce(rb.transform.forward * launchForce);


    }


}
