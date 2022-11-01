using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLock : Rule {

    private KeysEnum key;

     public int[][] findMatch(Graph graph) {
        if (graph.vertexCount == 0
            || !graph.acceptsNewVertex()) return new int[0][];

        key = graph.getAvailableKey();
        if (key == KeysEnum.None) return new int[0][];

        List<int[]> matches = new List<int[]>();

        for (int i = 0; i < graph.n; i++) {
            for (int j = 0; j < graph.n; j++) {
                if (j == i) continue;
                if (match(graph, i, j)) {
                    matches.Add(new int[2]{i, j});
                }
            }
        }

        return matches.ToArray();
     }



     private bool match(Graph graph, int i, int j) {
        return  graph.adj[i, j] != -1 
                && graph.vertexes[i].outCount < 2
                && graph.vertexes[j].inCount < 2;
     }

    public void appplyTransformation(Graph graph, int[][] vertexes) {
        if (vertexes.Length == 0) return;

        int random = Random.Range(0, vertexes.Length);

        string nextScene = "scene" + (graph.vertexCount + 1);

        int index = graph.addVertex(nextScene, key);
        graph.addEdge(vertexes[random][0], index, KeysEnum.None);

        graph.setEdge(vertexes[random][0], vertexes[random][1],  key);
    }
}