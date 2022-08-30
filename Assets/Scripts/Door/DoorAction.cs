using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAction : MonoBehaviour
{

    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private Transform exitPoint;

    [SerializeField]
    private string sceneToLoad;
    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            player.transform.position = exitPoint.position;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
