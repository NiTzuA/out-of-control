using UnityEngine;

public class DownItemOff : PickupItem
{
    protected override void OnPickup(GameObject player)
    {
        var playerMovement = player.GetComponent<MovementController>();
        playerMovement.LockMovement("down");
    }
}
