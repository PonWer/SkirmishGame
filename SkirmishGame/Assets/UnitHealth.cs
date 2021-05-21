using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public delegate void UnitDiedDelegate(Unit unit);

public class UnitHealth : MonoBehaviour
{
    public Unit ThisUnit { get; set; }

    [Header("StartingValues")]
    public double StartingHealth;
    public double TimeFromDeathToDespawn;

    [Header("Health")]
    public double CurrentHealth;

    [Header("Despawner")]
    public bool MarkedForDespawn;
    public double TimeUntilDespawn;

    public UnitDiedDelegate reportUnitDied;
    
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = StartingHealth;

        UnitManager.Instance.AddUnit(ThisUnit);
    }

    // Update is called once per frame
    void Update()
    {
        if (MarkedForDespawn)
        {
            TimeUntilDespawn--;

            if(TimeUntilDespawn <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        else if(CurrentHealth <= 0)
        {
            HandleUnitDeath(true);
        }
        else if (transform.position.y < -100)
        {
            HandleUnitDeath(false);
        }
    }

    private void HandleUnitDeath(bool longDespawn)
    {
        MarkedForDespawn = true;

        UnitManager.Instance.RemoveUnit(ThisUnit);
        reportUnitDied?.Invoke(ThisUnit);

        if (longDespawn)
        {
            TimeUntilDespawn = TimeFromDeathToDespawn;
            TurnUnitToRagdoll();
        }
        else
        {
            TimeFromDeathToDespawn = 5;
        }
    }

    private void TurnUnitToRagdoll()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GetComponent<RichAI>().enabled = false;
        GetComponent<AIDestinationSetter>().enabled = false;
        GetComponent<Seeker>().enabled = false;
    }

    public bool TakeDamage(double damage)
    {
        CurrentHealth -= damage;
        return CurrentHealth <= 0;
    }
}
