using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAction : MonoBehaviour
{
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
        string sceneName = SceneManager.GetActiveScene().name;
        DoorData doorData = ScenesManager.instance.getDoorData(sceneName, gameObject.name);
        ScenesManager.instance.LoadNewScene(doorData.destinationScene, doorData.destinationDoor);
    }
}
