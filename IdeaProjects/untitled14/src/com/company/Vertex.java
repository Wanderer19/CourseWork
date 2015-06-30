package com.company;

import java.util.ArrayList;

public class Vertex {
    private int id;
    private ArrayList<Vertex> incidentVertexes;

    public Vertex(int id){
        incidentVertexes = new ArrayList<Vertex>();
        setId(id);
    }

    public void addIncidentVertex(Vertex vertex){
        incidentVertexes.add(vertex);
    }

    public void setIncidentVertexes(ArrayList<Vertex> incidentVertexes) {
        this.incidentVertexes = incidentVertexes;
    }

    public ArrayList<Vertex> getIncidentVertexes() {
        return incidentVertexes;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getId() {
        return id;
    }

    @Override
    public boolean equals(Object obj) {
        Vertex other = (Vertex)obj;
        return id == other.id;
    }

    @Override
    public int hashCode() {
        return id;
    }
}
