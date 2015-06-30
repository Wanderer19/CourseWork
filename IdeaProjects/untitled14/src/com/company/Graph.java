package com.company;

import java.util.ArrayList;
import java.util.LinkedList;

public class Graph {
    private ArrayList<Vertex> vertexes;
    private int size;

    public Graph(int size){
        this.size = size;
        vertexes = new ArrayList<Vertex>(size);
    }

    public void addVertex(Vertex vertex){
        vertexes.add(vertex);
    }

    public Vertex getVertexById(int id){
        for (Vertex vertex : vertexes){
            if (vertex.getId() == id){
                return vertex;
            }
        }

        return null;
    }
    public ArrayList<Vertex> getShortestPath(Vertex startVertex, Vertex finishVertex){
        LinkedList<Vertex> queue = new LinkedList<>();
        queue.add(finishVertex);

        boolean[] used = new boolean[size];
        used[finishVertex.getId()] = true;

        Vertex[] parents = new Vertex[size];
        parents[finishVertex.getId()] = finishVertex;

        while (!queue.isEmpty()){
            Vertex currentVertex = queue.poll();

            for (Vertex vertex : currentVertex.getIncidentVertexes()){
                if (!used[vertex.getId()]){
                    used[vertex.getId()] = true;
                    parents[vertex.getId()] = currentVertex;
                    queue.add(vertex);
                }
            }
        }

        if (!used[startVertex.getId()]){
            return null;
        }

        ArrayList<Vertex> result = new ArrayList<Vertex>();
        Vertex to = startVertex;
        while (!to.equals(finishVertex)){
            result.add(to);
            to = parents[to.getId()];
        }
        result.add(finishVertex);

        return result;
    }
}
