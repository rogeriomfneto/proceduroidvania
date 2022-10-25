using System.Collections;
using System.Collections.Generic;

public interface Rule {
    public int[] findMatch(Graph graph);
    public void appplyTransformation(Graph g, int[] vertexes);
}