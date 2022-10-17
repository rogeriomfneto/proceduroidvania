
using System.Collections;
using System.Collections.Generic;

public class Graph {

    public int[,] adj;

    public Vertex[] vertexes;

    public int n;

    public int count = 0;

    public Graph(int n) {
        adj = new int[n, n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                adj[i, j] = -1;

        vertexes = new Vertex[n];

        this.n = n;
    }

    public int addVertex(string sceneName, KeysEnum keyType) {
        int index = count++;
        vertexes[index] = new Vertex(index, sceneName, keyType);
        return index;
    }

    public void addEdge(int index1, int index2, KeysEnum keyType) {
        UnityEngine.Debug.Log("addEdge: " + adj[index1, index2]);
        adj[index1, index2] = (int) keyType;
    }

    public void bfs() {
        if (count == 0) return;
        
        Queue queue = new Queue();
        bool[] visited = new bool[n];

        queue.Enqueue(0);

        UnityEngine.Debug.Log("Bfs:");
        while(queue.Count != 0) {
            int index = (int) queue.Dequeue();
            visited[index] = true;
            UnityEngine.Debug.Log(index);
            for (int i = 0; i < n; i++) {
                if (adj[index, i] != -1 && !visited[i]) {
                    queue.Enqueue(i);
                }
            }
        }

    }

    public void debug() {
        UnityEngine.Debug.Log("Debug graph: ");
        for (int i = 0; i < count; i++) {
            UnityEngine.Debug.Log(i + ": ");
            for (int j = 0; j < n; j++) {
                if (adj[i, j] != -1)
                    UnityEngine.Debug.Log(((KeysEnum) adj[i,j]).ToString() + " " + j);
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