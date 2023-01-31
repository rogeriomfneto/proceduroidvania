using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class ScenesManager : MonoBehaviour
{

    public static ScenesManager instance;

    public delegate void OnSceneLoad(string sceneName, string doorName);
    public static event OnSceneLoad onSceneLoad; 

    public delegate void LoadSceneCalled();
    public static event LoadSceneCalled onLoadSceneCalled;
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
        onLoadSceneCalled?.Invoke();
         
        SceneManager.LoadScene(sceneName);
        Scene scene = SceneManager.GetSceneByName(sceneName);
        
        while (!scene.isLoaded) yield return new WaitForEndOfFrame();

        onSceneLoad?.Invoke(sceneName, doorName);
    }

    public void removeKeyFromScene() {
        string sceneName = getCurrentSceneName();
        getSceneData(sceneName).keyType = KeysEnum.None;
    }

    public DoorData getDoorData(string sceneName, string doorName) {
        return scenesConnectionData.getScene(sceneName).getDoor(doorName);
    }

    public SceneData getSceneData(string sceneName) {
        return scenesConnectionData.getScene(sceneName);
    }


    private Graph createMissionGraph() {
        Graph graph = new Graph(16);
        graph.addVertex("scene1", KeysEnum.None);
        graph.addVertex("scene2", KeysEnum.None);
        graph.addVertex("scene3", KeysEnum.None);

        graph.addEdge(0, 1, KeysEnum.None);
        graph.addEdge(1, 2, KeysEnum.None);

        List<Rule> rulesThatVertexes = new List<Rule>();
        rulesThatVertexes.Add(new AddVertexBetween());
        rulesThatVertexes.Add(new AddLock());
        rulesThatVertexes.Add(new DelayKey());
        
        int [][] vertexes;
        for (int i = 0; i < 5; i++) {
            foreach (var rule in rulesThatVertexes) {
                vertexes = rule.findMatch(graph);
                rule.applyTransformation(graph, vertexes);
            }
        }

        List<Rule> rulesThatAddEdges = new List<Rule>();
        rulesThatAddEdges.Add(new ConnectVertices());
        for (int i = 0; i < 4; i++) {
            foreach (var rule in rulesThatAddEdges) {
                vertexes = rule.findMatch(graph);
                rule.applyTransformation(graph, vertexes);
            }
        }

        graph.debug();
        return graph;
    }

    public string getCurrentSceneName() {
        return SceneManager.GetActiveScene().name;
    }
}
