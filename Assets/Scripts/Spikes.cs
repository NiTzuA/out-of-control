using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(collision.gameObject); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
