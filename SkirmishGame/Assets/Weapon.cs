using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Unit ThisUnit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //var weapon = collision.gameObject.GetComponent<Weapon>();

        //if (weapon != null)
        //{
        
        //    ThisUnit.healthScript.CurrentHealth -= weapon.Damage;
        //}

        var collidedUnit = collision.gameObject.GetComponentInParent<Unit>();
        
        if (collidedUnit != ThisUnit)
        {
            //Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}");

            var unitBodyPart = collision.gameObject.GetComponent<UnitBodyPart>();
            if (unitBodyPart != null)
            {


                //Debug.Log($"weapon impulse magnitude: {collision.impulse.magnitude}");
                unitBodyPart.TakeDamage(collision.impulse.magnitude);
            }

            //collidedUnit.healthScript.CurrentHealth--;
        }
        else
        {
            //Debug.Log($"{gameObject.name} collided itself");
        }


    }

    public double Damage { get; set; } = 2.0f;
}
