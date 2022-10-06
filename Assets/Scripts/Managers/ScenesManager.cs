using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public static ScenesManager instance;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    } 

    void Start() {
        SceneManager.LoadScene("scene2", LoadSceneMode.Additive);
        connectScenes("Test", "scene2", "Door1", "Door1");
    }

    public void connectScenes(string sceneName1, string sceneName2, string doorName1, string doorName2) {
        StartCoroutine(connectScenesCo("Test", "scene2", "Door1", "Door1"));
    }

    public IEnumerator connectScenesCo(string sceneName1, string sceneName2, string doorName1, string doorName2) {
        Scene scene1 = SceneManager.GetSceneByName(sceneName1);
        Scene scene2 = SceneManager.GetSceneByName(sceneName2);

        while(!scene2.isLoaded) yield return new WaitForEndOfFrame();

        List<GameObject> objects = new List<GameObject>();
        scene1.GetRootGameObjects(objects);
        GameObject door1 = objects.Find(obj => obj.name == doorName1);

        // Debug.Log("scene2: " + scene2.rootCount);
        objects = new List<GameObject>();
        scene2.GetRootGameObjects(objects);
        GameObject door2 = objects.Find(obj => obj.name == doorName2);

        connectDoors(sceneName1, sceneName2, door1, door2);
        yield return null;
    }

    public void connectDoors(string sceneName1, string sceneName2, GameObject door1, GameObject door2) {
        DoorAction action1 = door1.GetComponent<DoorAction>();
        DoorAction action2 = door2.GetComponent<DoorAction>();

        action1.exitPoint = action2.spawnPoint;
        action2.exitPoint = action1.spawnPoint;

        action1.sceneToLoad = sceneName2;
        action2.sceneToLoad = sceneName1;
    }
}
