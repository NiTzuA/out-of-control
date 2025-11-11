using UnityEngine;
using TMPro;
using System.Collections;

public class TextHint : MonoBehaviour
{
    public TMP_Text hint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(TextFade());
            
        }

    }
    IEnumerator TextFade()
    {
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime;
            Color color = hint.color;

            color.a = elapsedTime;

            hint.color = color;

            yield return null;
        }

        Destroy(gameObject);
    }
}
