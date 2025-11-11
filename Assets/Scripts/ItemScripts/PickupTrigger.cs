using System.Collections;
using UnityEngine;

public class PickupTrigger : PickupItem
{

    public GameObject target;
    public string triggerType;

    protected override void OnPickup(GameObject player)
    {
        ActivateTrigger(triggerType);
    }

    public void ActivateTrigger(string triggerType)
    {
        switch (triggerType)
        {
            case "destroy":
                Destroy(target);
                break;
            default:
                Debug.Log("Invalid trigger type.");
                break;
        }
    }
}
