using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour
{
    public Camera cam;
    public float shakeForce;
    Vector3 initialPosition;

    public void PlayMovementDisabledAnimation()
    {
        initialPosition = cam.transform.position;
        StartCoroutine(Shake(initialPosition));
        
    }

    IEnumerator Shake(Vector3 initialPosition)
    {
        
        float elapsedTime = 0f;

        while (elapsedTime < 0.1f)
        {
            elapsedTime += Time.deltaTime;
            Vector3 offset = Random.insideUnitSphere;
            offset.z = 0f;

            cam.transform.position = initialPosition + offset * shakeForce;
            yield return null;
        }

        cam.transform.position = initialPosition;
    }
}
