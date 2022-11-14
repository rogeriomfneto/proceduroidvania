using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectVertices : Rule {

     public int[][] findMatch(Graph graph) {
        if (graph.vertexCount == 0) return new int[0][];

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
        return  graph.adj[i, j] == -1
                && graph.vertexes[j].keyType == KeysEnum.None
                && graph.vertexes[i].outCount < 2
                && graph.vertexes[j].inCount < 2;
     }

    public void applyTransformation(Graph graph, int[][] vertexes) {
        if (vertexes.Length == 0) return;

        int random = Random.Range(0, vertexes.Length);

        int first = vertexes[random][0];
        int second = vertexes[random][1];

        UnityEngine.Debug.Log("Connecting vertices " + first + " and "+ second);

        graph.addEdge(first, second, KeysEnum.None);
    }
}