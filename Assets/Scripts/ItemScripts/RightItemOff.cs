using UnityEngine;

public class RightItemOff : PickupItem
{
    protected override void OnPickup(GameObject player)
    {
        var playerMovement = player.GetComponent<MovementController>();
        playerMovement.LockMovement("right");
    }
}
