using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBodyPart : MonoBehaviour
{
    public Unit ThisUnit { get; set; }

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
        Debug.Log($"{gameObject.name} collided with {collision.gameObject.name}");


        var weapon = collision.gameObject.GetComponent<Weapon>();

        if(weapon != null)
            ThisUnit.healthScript.CurrentHealth -= weapon.Damage;
    }

    
}
