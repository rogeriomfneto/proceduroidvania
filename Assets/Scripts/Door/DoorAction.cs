using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAction : MonoBehaviour
{

    public delegate void OnSceneChange(Scene scene);
    public static event OnSceneChange onSceneChange; 
    private PlayerController player;

    [SerializeField]
    public Transform exitPoint;

    [SerializeField]
    public Transform spawnPoint;

    [SerializeField]
    public string sceneToLoad;

    void Start() {
        player = PlayerSingleton.instance.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
           changeScene();
        }
    }

    private void changeScene() {
        player.transform.position = exitPoint.position;
        Scene scene = SceneManager.GetSceneByName(sceneToLoad);
        SceneManager.SetActiveScene(scene);
        onSceneChange?.Invoke(scene);
    }
}
