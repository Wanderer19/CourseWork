package com.company;

public class Edge {
    private Vertex from;
    private Vertex to;

    public Edge(Vertex from, Vertex to){
        setFrom(from);
        setTo(to);
    }

    public void setFrom(Vertex from) {
        this.from = from;
    }

    public Vertex getFrom() {
        return from;
    }

    public void setTo(Vertex to) {
        this.to = to;
    }

    public Vertex getTo() {
        return to;
    }

    @Override
    public boolean equals(Object obj) {
        Edge other = (Edge)obj;
        return from.equals(other.from) && to.equals(other.to);
    }

    @Override
    public int hashCode() {
        return from.hashCode()^to.hashCode();
    }

    @Override
    public String toString() {
        return "( " + from.getId() + " - " + to.getId() +" )";
    }
}
