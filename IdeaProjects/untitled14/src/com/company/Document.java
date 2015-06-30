package com.company;

public class Document {
    private int id;
    private String text;

    public Document(int id, String text){
        setId(id);
        setText(text);
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getText() {
        return text;
    }

    public void setText(String text) {
        this.text = text;
    }

    @Override
    public boolean equals(Object obj) {
        Document other = (Document) obj;
        BiFunction<String, String> res =
        return id == other.id && text.equals(other.text);
    }

    @Override
    public int hashCode() {
        return id;
    }
}
