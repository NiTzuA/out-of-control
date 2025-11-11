using UnityEngine;

public class LeftItem : PickupItem
{
    protected override void OnPickup(GameObject player)
    {
        var playerMovement = player.GetComponent<MovementController>();
        playerMovement.UnlockMovement("left");
    }
}
