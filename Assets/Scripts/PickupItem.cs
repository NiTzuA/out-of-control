using UnityEngine;

public class PickupItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnPickup(collision.gameObject);
            Destroy(gameObject);
        }

    }
    protected virtual void OnPickup(GameObject player)
    {
        Debug.Log("Item has no action...");
    }
}
