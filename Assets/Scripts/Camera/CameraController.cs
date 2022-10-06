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
        DoorAction.onSceneChange += changeBounds;
    }

    private void OnDisable() {
        DoorAction.onSceneChange -= changeBounds;
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

    private void changeBounds(Scene scene) {
        List<GameObject> objects = new List<GameObject>();
        scene.GetRootGameObjects(objects);
        GameObject newLevelBounds = objects.Find(obj => obj.name == "LevelBounds");
        levelBounds = newLevelBounds.GetComponent<BoxCollider2D>();
    }
}
