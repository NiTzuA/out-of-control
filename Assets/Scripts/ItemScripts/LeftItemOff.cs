using UnityEngine;

public class LeftItemOff : PickupItem
{
    protected override void OnPickup(GameObject player)
    {
        var playerMovement = player.GetComponent<MovementController>();
        playerMovement.LockMovement("left");
    }
}
