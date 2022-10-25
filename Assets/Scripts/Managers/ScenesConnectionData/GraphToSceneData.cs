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

        Queue queue = new Queue();
        bool[] visited = new bool[graph.n];

        queue.Enqueue(0);

        while(queue.Count != 0) {
            int index = (int) queue.Dequeue();
            visited[index] = true;

            Vertex v = graph.vertexes[index];
            SceneData sceneData = scenesConnectionData.getScene(v.sceneName);
            sceneData.keyType = v.keyType;
            
            int currentDoor = 4;
            string doorPrefix = "Door";

            for (int i = 0; i < graph.n; i++) {
                if (graph.adj[index, i] != -1 && !visited[i]) {
                    queue.Enqueue(i);

                    KeysEnum keyType = (KeysEnum) graph.adj[index, i];
                    string firstScene = v.sceneName;
                    string secondScene = graph.vertexes[i].sceneName;

                    int secondDoor = currentDoor == 1 ? 4 : currentDoor - 1;

                    scenesConnectionData.connect(firstScene, doorPrefix + currentDoor, secondScene, doorPrefix + secondDoor, keyType);
                    currentDoor = currentDoor == 4 ? 1 : currentDoor + 1;
                }
            }
        }

        return scenesConnectionData;
    }

}