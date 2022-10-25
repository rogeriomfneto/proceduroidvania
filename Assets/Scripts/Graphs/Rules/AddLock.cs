using System.Collections;
using System.Collections.Generic;

public class AddLock : Rule {

    private KeysEnum key;

     public int[] findMatch(Graph graph) {
        if (graph.vertexCount == 0
            || !graph.acceptsNewVertex()) return new int[0];

        key = graph.getAvailableKey();
        if (key == KeysEnum.None) return new int[0];

        UnityEngine.Debug.Log("caralho de asa");
        for (int i = 0; i < graph.n; i++) {
            for (int j = 0; j < graph.n; j++) {
                if (j == i) continue;
                for (int k = 0; k < graph.n; k++) {
                    if (k == j || k == i) continue;
                    if (match(graph, i, j, k)) {
                        return new int[3] {i, j, k};
                    }
                }
            }
        }

        return new int[0];
     }



     private bool match(Graph graph, int i, int j, int k) {
        return  graph.adj[i, j] != -1 
                && graph.adj[j, k] != -1 
                && graph.vertexes[j].neighborsCount < 4
                && graph.vertexes[j].keyType == KeysEnum.None;
     }

    public void appplyTransformation(Graph graph, int[] vertexes) {
        string nextScene = "scene" + (graph.vertexCount + 1);

        int index = graph.addVertex(nextScene, key);
        graph.addEdge(vertexes[0], index, KeysEnum.None);

        graph.addEdge(vertexes[0], vertexes[1],  key);
    }
}