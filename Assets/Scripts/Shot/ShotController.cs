using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField]
    private float shotSpeed = 12f;

    [SerializeField]
    private float timeToDestroy = 3f;

    [SerializeField]
    private Rigidbody2D rb;

    void Start()
    {
        rb.velocity = new Vector2(shotSpeed , 0);
        destroyAfterDelay();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(gameObject);
    }


    private void destroyAfterDelay() {
        StartCoroutine(destroyCoroutine());
    }

    IEnumerator destroyCoroutine() {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
    }
}
