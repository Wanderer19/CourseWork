package com.company;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.TreeSet;

public class LadderBuilder {
    public static ArrayList<String> build(String[] dictionary, String initialWord, String targetWord){
        HashMap<String, Integer> dict = new HashMap<>();
        int index = 0;

        for (String word : dictionary){
            dict.put(word, index);
            index++;
        }

        Graph graph = buildGraph(dict, getAlphabet(dictionary));
        ArrayList<Vertex> path = graph.getShortestPath(
                graph.getVertexById(dict.get(initialWord)), graph.getVertexById(dict.get(targetWord)));

        if (path == null){
            return null;
        }

        ArrayList<String> result = new ArrayList<>();
        for (Vertex vertex: path){
            result.add(dictionary[vertex.getId()]);
        }

        return result;
    }

    private static TreeSet<Character> getAlphabet(String[] dictionary){
        TreeSet<Character> alphabet = new TreeSet<>();
        for (String word : dictionary){
            char[] letters = word.toCharArray();
            for (char letter : letters){
                alphabet.add(letter);
            }
        }

        return alphabet;
    }

    private static Graph buildGraph(HashMap<String, Integer> dictionary, TreeSet<Character> alphabet){
        Graph graph = new Graph(dictionary.size());
        Vertex[] vertexes = new Vertex[dictionary.size()];
        for (int wordId : dictionary.values()){
            vertexes[wordId] = new Vertex(wordId);
            graph.addVertex(vertexes[wordId]);
        }

        for (String word: dictionary.keySet()){
            TreeSet<String> words = getWords(word, alphabet);
            for (String child : words){
                if (dictionary.containsKey(child)){
                    vertexes[dictionary.get(word)].addIncidentVertex(vertexes[dictionary.get(child)]);
                    vertexes[dictionary.get(child)].addIncidentVertex(vertexes[dictionary.get(word)]);
                }
            }
        }

        return graph;
    }

    private static TreeSet<String> getWords(String word, TreeSet<Character> alphabet){
        TreeSet<String> words = new TreeSet<>();
        char[] lettersWord = word.toCharArray();

        for (int i = 0; i < word.length(); ++i){

            for (char letter : alphabet) {
                char oldLetter = lettersWord[i];
                lettersWord[i] = letter;
                words.add(new String(lettersWord));
                lettersWord[i] = oldLetter;
            }
        }
        return words;
    }
}
