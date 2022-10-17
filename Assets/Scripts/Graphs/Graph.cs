using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Graph {

    private List<List<Pair<int, KeysEnum>>> adj;

    private List<Vertex> vertexes;

    public Graph(int n) {
        adj = new List<List<Pair<int, KeysEnum>>>(n);
        vertexes = new List<Vertex>(n);
    }

    public void addVertex(string sceneName, KeysEnum keyType) {
        int index = vertexes.Count;
        vertexes.Add(new Vertex(index, sceneName, keyType));
        adj.Add(new List<Pair<int, KeysEnum>>());
    }

    public void addEdge(int index1, int index2, KeysEnum keyType) {
        adj[index1].Add(new Pair<int, KeysEnum>(index2, keyType));
    }

    public void bfs() {
        if (vertexes.Count == 0) return;
        
        Queue queue = new Queue();
        bool[] visited = new bool[vertexes.Count];

        queue.Enqueue(0);

        UnityEngine.Debug.Log("Bfs:");
        while(queue.Count != 0) {
            int index = (int) queue.Dequeue();
            visited[index] = true;
            UnityEngine.Debug.Log(index);
            for (int i = 0; i < adj[index].Count; i++) {
                if (!visited[adj[index][i].First]) {
                    queue.Enqueue(adj[index][i].First);
                }
            }
        }

    }
}

public class Vertex {
    public int index;
    public string sceneName;
    public KeysEnum keyType;

    public Vertex(int index, string sceneName, KeysEnum keyType) {
        this.index = index;
        this.sceneName = sceneName;
        this.keyType = keyType;
    }

} 

public class Pair<T, U> {
    public Pair() {
    }

    public Pair(T first, U second) {
        this.First = first;
        this.Second = second;
    }

    public T First { get; set; }
    public U Second { get; set; }
};