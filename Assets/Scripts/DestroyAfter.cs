using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    public float timeToDestroy = 3f;
    AudioSource audioSource;

    void Start()
    {
        StartCoroutine(DestroyAfterTime());
        StartCoroutine(WaitJustALittle());
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }

    IEnumerator WaitJustALittle()
    {
        yield return new WaitForSeconds(0.15f);
        audioSource.Play();
    }
}
