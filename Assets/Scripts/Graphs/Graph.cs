
using System.Collections;
using System.Collections.Generic;

public class Graph {

    public int[,] adj;

    public Vertex[] vertexes;

    public int n;

    public int vertexCount = 0;

    private Stack availableKeys;

    public Graph(int n) {
        adj = new int[n, n];

        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                adj[i, j] = -1;

        vertexes = new Vertex[n];

        this.n = n;

        this.availableKeys = new Stack();
        this.availableKeys.Push(KeysEnum.Red);
        this.availableKeys.Push(KeysEnum.Green);
        this.availableKeys.Push(KeysEnum.Blue);
        this.availableKeys.Push(KeysEnum.Yellow);
    }

    public int addVertex(string sceneName, KeysEnum keyType) {
        int index = vertexCount++;
        vertexes[index] = new Vertex(index, sceneName, keyType);
        return index;
    }

    public void addEdge(int index1, int index2, KeysEnum keyType) {
        if (vertexes[index1].outCount >= 2 || vertexes[index2].inCount >= 2 ) {
            UnityEngine.Debug.LogError("can't connect new edge from " + index1 + " to " + index2 + "\n" + vertexes[index1].outCount + " " + vertexes[index2].inCount);
            return;
        }

        setEdge(index1, index2, keyType);   

        vertexes[index1].outCount++;
        vertexes[index2].inCount++;
        UnityEngine.Debug.Log("addEdge: " + index1 + " " + index2 + " = " + (keyType));

    }

    public void setEdge(int index1, int index2, KeysEnum keyType) {
         adj[index1, index2] = (int) keyType;
    }

    public KeysEnum getAvailableKey() {
        if (this.availableKeys.Count == 0) return KeysEnum.None;
        return (KeysEnum) this.availableKeys.Pop();
    }

    public bool acceptsNewVertex() {
        return this.vertexCount < n;
    }

    public void bfs() {
        if (vertexCount == 0) return;
        
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
        for (int i = 0; i < vertexCount; i++) {
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
    public int inCount = 0;
    public int outCount = 0;

    public Vertex(int index, string sceneName, KeysEnum keyType) {
        this.index = index;
        this.sceneName = sceneName;
        this.keyType = keyType;
    }

} 
