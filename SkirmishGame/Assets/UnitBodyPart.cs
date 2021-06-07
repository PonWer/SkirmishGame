using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBodyPart : MonoBehaviour
{
    public Unit ThisUnit { get; set; }


    public double ImpulseThreshold = 0.01f;
    public double ImpulseHitpoints = 2f;

    private Rigidbody body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float impulseMagnitude)
    {
        //Debug.Log($"limb took {impulseMagnitude} damage");
        if (!(impulseMagnitude > ImpulseThreshold))
        {
            return;
        }

        //Debug.Log("unitBodypart: passed threshold");
        ImpulseHitpoints -= impulseMagnitude;
        if (ImpulseHitpoints <= 0)
        {
            CharacterJoint joint = GetComponent<CharacterJoint>();
            joint.breakForce = 0f;
            //Debug.Log("unitybodypart: limb fell off");

        }
    }

    public void SwingArm(Vector3 direction)
    {

        body.AddForceAtPosition(direction, Vector3.up);

    }
}
