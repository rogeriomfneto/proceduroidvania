using System.Collections;
using System.Collections.Generic;

public class AddLock : Rule {
     public int[] findMatch(Graph graph) {
        if (graph.count == 0) return  new int[0];
        
        Queue queue = new Queue();
        bool[] visited = new bool[graph.n];

        queue.Enqueue(0);

        while(queue.Count != 0) {
            int index = (int) queue.Dequeue();
            visited[index] = true;

            for (int i = 0; i < graph.n; i++) {
                for (int j = 0; j < graph.n; j++) {
                    if (graph.adj[i, index] != -1 && graph.adj[index, j] != -1 && graph.vertexes[index].keyType == KeysEnum.None) {
                        return new int[3] {i, index, j};
                    }
                }
            }
            
            for (int i = 0; i < graph.n; i++) {
                if (graph.adj[index, i] != -1 && !visited[i]) {
                    queue.Enqueue(i);
                }
            }
        }

        return new int[0];
     }

    public void appplyTransformation(Graph graph, int[] vertexes) {
        int index = graph.addVertex("scene4", KeysEnum.Red);
        graph.addEdge(vertexes[0], index, KeysEnum.None);

        graph.addEdge(vertexes[0], vertexes[1],  KeysEnum.Red);
    }
}