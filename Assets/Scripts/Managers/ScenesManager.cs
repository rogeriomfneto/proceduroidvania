using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public static ScenesManager instance;

    public delegate void OnSceneLoad(string sceneName, string doorName);
    public static event OnSceneLoad onSceneLoad; 
    ScenesConnectionData scenesConnectionData = new ScenesConnectionData();

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void LoadNewScene(string sceneName, string doorName) {
        StartCoroutine(LoadNewSceneCo(sceneName, doorName));
    }

    private IEnumerator LoadNewSceneCo(string sceneName, string doorName) {
        SceneManager.LoadScene(sceneName);
        Scene scene = SceneManager.GetSceneByName(sceneName);
        
        while (!scene.isLoaded) yield return new WaitForEndOfFrame();

        onSceneLoad?.Invoke(sceneName, doorName);
    }

    public DoorData getDoorData(string sceneName, string doorName) {
        return scenesConnectionData.getScene(sceneName).getDoor(doorName);
    }


}
