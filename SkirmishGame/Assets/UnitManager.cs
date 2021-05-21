using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public readonly List<Unit> Units = new List<Unit>();
    public readonly List<Unit> RemovedUnitsThisFrame = new List<Unit>();

    private static UnitManager _instance;

    public static UnitManager Instance => _instance = _instance ?? (UnitManager)FindObjectOfType(typeof(UnitManager));

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void LateUpdate()
    {
        RemovedUnitsThisFrame.ForEach(x => Units.Remove(x));
        RemovedUnitsThisFrame.Clear();
    }

    public void AddUnit(Unit unit)
    {
        Units.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        RemovedUnitsThisFrame.Add(unit);
    }

    public Unit GetClosestUnit(Unit sourceUnit)
    {
        Unit currentClosest = null;
        var currentDistance = Mathf.Infinity;

        var currentPos = sourceUnit.transform.position;

        foreach (var testUnit in Units)
        {
            if (testUnit == sourceUnit)
            {
                continue;
            }

            var dist = Vector3.Distance(testUnit.transform.position, currentPos);
            if (dist > currentDistance)
            {
                continue;
            }

            currentClosest = testUnit;
            currentDistance = dist;
        }
        return currentClosest;
    }
}
