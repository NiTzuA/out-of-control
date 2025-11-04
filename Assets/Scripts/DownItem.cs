using UnityEngine;

public class DownItem : PickupItem
{
    protected override void OnPickup(GameObject player)
    {
        var playerMovement = player.GetComponent<MovementController>();
        playerMovement.UnlockMovement("down");
    }
}
