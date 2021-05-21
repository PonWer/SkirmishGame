using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitHealth healthScript;
    public UnitCombat combatScript;
    public AIDestinationSetter destinationSetter;

    // Start is called before the first frame update
    void Awake()
    {
        healthScript = gameObject.GetComponent<UnitHealth>();
        combatScript = gameObject.GetComponent<UnitCombat>();
        destinationSetter = gameObject.GetComponent<AIDestinationSetter>();

        healthScript.ThisUnit = this;
        combatScript.ThisUnit = this;
    }
}