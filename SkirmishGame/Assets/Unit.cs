using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Pathfinding;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitHealth healthScript;
    public UnitCombat combatScript;
    public AIDestinationSetter destinationSetter;
    public List<UnitBodyPart> bodyParts;
    public List<Weapon> weapons;

    // Start is called before the first frame update
    void Awake()
    {
        healthScript = gameObject.GetComponent<UnitHealth>();
        combatScript = gameObject.GetComponent<UnitCombat>();
        destinationSetter = gameObject.GetComponent<AIDestinationSetter>();
        bodyParts = gameObject.GetComponentsInChildren<UnitBodyPart>().ToList();
        weapons = gameObject.GetComponentsInChildren<Weapon>().ToList();

        healthScript.ThisUnit = this;
        combatScript.ThisUnit = this;
        bodyParts.ForEach(x => x.ThisUnit = this);
        weapons.ForEach(x => x.ThisUnit = this);

    }
}