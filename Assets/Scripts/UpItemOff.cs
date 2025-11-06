using UnityEngine;

public class UpItemOff : PickupItem
{
    protected override void OnPickup(GameObject player)
    {
        var playerMovement = player.GetComponent<MovementController>();
        playerMovement.LockMovement("up");
    }
}
