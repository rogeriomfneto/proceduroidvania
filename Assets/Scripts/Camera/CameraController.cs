using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private Transform player;

    [SerializeField]
    private BoxCollider2D levelBounds;
    private float halfHeight, halfWidth;
    // Update is called once per frame

    public static CameraController instance;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    } 

    private void OnEnable() {
        ScenesManager.onSceneLoad += onChangeBounds;
    }

    private void OnDisable() {
        ScenesManager.onSceneLoad -= onChangeBounds;
    }

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

    private void onChangeBounds(string sceneName, string doorName) {
        GameObject newLevelBounds = GameObject.Find("LevelBounds");
        levelBounds = newLevelBounds.GetComponent<BoxCollider2D>();
    }
}
