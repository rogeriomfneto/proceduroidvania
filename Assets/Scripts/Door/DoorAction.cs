using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAction : MonoBehaviour
{
    private PlayerController player;

    [SerializeField]
    private Transform exitPoint;

    [SerializeField]
    private string sceneToLoad;

    [SerializeField]
    private KeysEnum keyType;

    void Start() {
        player = SpawnController.instance.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            player.transform.position = exitPoint.position;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
