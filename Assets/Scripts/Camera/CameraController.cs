using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    private BoxCollider2D levelBounds;
    private float halfHeight, halfWidth;
    // Update is called once per frame

    void Start() {
        player = FindObjectOfType<PlayerController>().transform;
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;
    }
    
    void FixedUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(player.position.x, levelBounds.bounds.min.x + halfWidth, levelBounds.bounds.max.x - halfWidth), 
            Mathf.Clamp(player.position.y, levelBounds.bounds.min.y + halfHeight, levelBounds.bounds.max.y - halfHeight), 
            transform.position.z);
    }
}
