using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVertexBetween : Rule {

     public int[][] findMatch(Graph graph) {
        if (graph.vertexCount == 0
            || !graph.acceptsNewVertex()) return new int[0][];

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
        return  graph.adj[i, j] ==  (int) KeysEnum.None 
                && graph.vertexes[j].keyType == KeysEnum.None;
     }

    public void applyTransformation(Graph graph, int[][] vertexes) {
        if (vertexes.Length == 0) return;

        int random = Random.Range(0, vertexes.Length);

        int first = vertexes[random][0];
        int second = vertexes[random][1];

        UnityEngine.Debug.Log("Adding vertex between " + first + " and "+ second);

        string nextScene = "scene" + (graph.vertexCount + 1);

        int index = graph.addVertex(nextScene, KeysEnum.None);
        KeysEnum key = (KeysEnum) graph.adj[first, second];

        graph.deleteEdge(first, second);
        graph.addEdge(first, index, key);
        graph.addEdge(index, second, KeysEnum.None);
    }
}