using UnityEngine;

public class UpItem : PickupItem
{
    protected override void OnPickup(GameObject player)
    {
        var playerMovement = player.GetComponent<MovementController>();
        playerMovement.UnlockMovement("up");
    }
}
