using System.Collections;
using System.Collections.Generic;

public class GraphToSceneData {
    private Graph graph;

    public GraphToSceneData(Graph graph) {
        this.graph = graph;
    }

    public ScenesConnectionData getSceneData() {
        if (graph == null) return null;
        if (graph.vertexCount == 0) return null;

        ScenesConnectionData scenesConnectionData = new ScenesConnectionData();

        // Queue queue = new Queue();
        // bool[] visited = new bool[graph.n];

        // queue.Enqueue(0);

        // while(queue.Count != 0) {
        //     int index = (int) queue.Dequeue();
        //     if (visited[index]) continue;

        //     visited[index] = true;

        //     Vertex v = graph.vertexes[index];
        //     SceneData sceneData = scenesConnectionData.getScene(v.sceneName);
        //     sceneData.keyType = v.keyType;

        //     for (int i = 0; i < graph.n; i++) {
        //         if (graph.adj[index, i] != -1 && !visited[i]) {
        //             queue.Enqueue(i);

        //             KeysEnum keyType = (KeysEnum) graph.adj[index, i];
        //             string firstScene = v.sceneName;
        //             string secondScene = graph.vertexes[i].sceneName;

        //             scenesConnectionData.connect(firstScene, secondScene, keyType);
        //         }
        //     }
        // }

        for (int i = 0; i < graph.vertexCount; i++) {
            Vertex v = graph.vertexes[i];
            SceneData sceneData = scenesConnectionData.getScene(v.sceneName);
            sceneData.keyType = v.keyType;
            for (int j = 0; j < graph.vertexCount; j++) {
                 if (graph.adj[i, j] != -1) {
                    
                    KeysEnum keyType = (KeysEnum) graph.adj[i, j];
                    string firstScene = v.sceneName;
                    string secondScene = graph.vertexes[j].sceneName;

                    scenesConnectionData.connect(firstScene, secondScene, keyType);
                }
            }
        }

        return scenesConnectionData;
    }

}