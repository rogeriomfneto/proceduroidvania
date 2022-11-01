using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{

    public static ScenesManager instance;

    public delegate void OnSceneLoad(string sceneName, string doorName);
    public static event OnSceneLoad onSceneLoad; 
    private ScenesConnectionData scenesConnectionData;

    void Awake() {
        if (instance == null) {
            instance = this;

            Graph graph = createMissionGraph();
            GraphToSceneData graphToSceneData = new GraphToSceneData(graph);
            scenesConnectionData = graphToSceneData.getSceneData();

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

    public SceneData getSceneData(string sceneName) {
        return scenesConnectionData.getScene(sceneName);
    }


    private Graph createMissionGraph() {
        Graph graph = new Graph(10);
        graph.addVertex("scene1", KeysEnum.None);
        graph.addVertex("scene2", KeysEnum.None);
        graph.addVertex("scene3", KeysEnum.None);

        graph.addEdge(0, 1, KeysEnum.None);
        graph.addEdge(1, 2, KeysEnum.None);

        Rule rule = new AddLock();
        int[][] vertexes = rule.findMatch(graph);
        // Debug.Log("match vertices: ");
        // for (int i = 0; i < vertexes.Length; i++)
        //     Debug.Log("vértice: " + vertexes[i]);
        rule.appplyTransformation(graph, vertexes);

        graph.debug();

        return graph;
    }
}
