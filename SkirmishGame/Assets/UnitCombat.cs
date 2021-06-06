using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class UnitCombat : MonoBehaviour
{
    public Unit ThisUnit { get; set; }

    public Unit Enemy;

    public float Damage = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ThisUnit?.healthScript?.MarkedForDespawn ?? true)
        {
            return;
        }

        if (Enemy == null || Enemy.gameObject == null || Enemy.GetComponent<UnitHealth>().MarkedForDespawn)
        {
            Enemy = UnitManager.Instance.GetClosestUnit(ThisUnit);

            //No more enemies
            if (Enemy == null)
                return;

            Enemy.healthScript.reportUnitDied += TargetEnemyDied;

            ThisUnit.destinationSetter.target = Enemy.transform; 
        }

        //if (Vector3.Distance(gameObject.transform.position, Enemy.transform.position) < (1f * transform.localScale.x))
        //{
        //    if (Enemy.healthScript.TakeDamage(Damage))
        //    {
        //        ThisUnit.healthScript.CurrentHealth = ThisUnit.healthScript.StartingHealth;
        //        //transform.localScale += new Vector3(1,1,1);
        //    }
        //}
    }

    void TargetEnemyDied(Unit target)
    {
        Enemy.healthScript.reportUnitDied -= TargetEnemyDied;
        Enemy = null;
    }
}
