using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnController : MonoBehaviour
{
    public static SpawnController instance;
    private Transform spawnPoint;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    } 

    private void OnEnable() {
        ScenesManager.onSceneLoad += onChangeScene;
    }

    private void OnDisable() {
        ScenesManager.onSceneLoad -= onChangeScene;
    }


    void Start() {
        spawnPoint = PlayerSingleton.instance.transform;
    }

    void respawn() {
        PlayerSingleton.instance.transform.position = spawnPoint.position;
    }

    void onChangeScene(string sceneName, string doorName) {
        Transform doorSpawn = GameObject.Find(doorName).transform.Find("SpawnPoint");
        spawnPoint = doorSpawn;

        respawn();
    }
}
