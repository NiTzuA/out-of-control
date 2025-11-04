using UnityEngine;

public class RightItem : PickupItem
{
    protected override void OnPickup(GameObject player)
    {
        var playerMovement = player.GetComponent<MovementController>();
        playerMovement.UnlockMovement("right");
    }
}
