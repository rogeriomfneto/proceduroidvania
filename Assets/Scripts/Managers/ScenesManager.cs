using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public static ScenesManager instance;

    public delegate void OnSceneLoad(string sceneName, string doorName);
    public static event OnSceneLoad onSceneLoad; 
    ScenesConnectionData scenesConnectionData = new ScenesConnectionData();

    Graph graph = new Graph(5);

    void Awake() {
        if (instance == null) {
            instance = this;

            graph.addVertex("cena1", KeysEnum.None);
            graph.addVertex("cena2", KeysEnum.None);
            graph.addVertex("cena3", KeysEnum.None);

            graph.addEdge(0, 2, KeysEnum.None);
            graph.addEdge(2, 1, KeysEnum.None);

            Rule rule = new AddLock();
            int[] vertexes = rule.findMatch(graph);
            rule.appplyTransformation(graph, vertexes);

            graph.debug();

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
