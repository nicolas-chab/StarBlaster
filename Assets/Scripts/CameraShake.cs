using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   [SerializeField] float shakeDuration=0.5f;
   [SerializeField] float shakeMagnitude=0.5f;
   

   Vector3 initialPosition;
    void Start()
    {
        initialPosition=transform.position;
        
    }
    public void Play()
    {
        StartCoroutine(ShakeCamera());
    }
    IEnumerator ShakeCamera()
    {
        float timeElapsed = 0;
        
        while (timeElapsed < shakeDuration)
        {
            timeElapsed+=Time.deltaTime;
            transform.position=initialPosition + (Vector3)Random.insideUnitCircle*shakeMagnitude;
            yield return new WaitForEndOfFrame();
        }
        transform.position=initialPosition;

    }
}
