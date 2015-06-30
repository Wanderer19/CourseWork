package com.company;

import java.util.Collection;
import java.util.Comparator;
import java.util.TreeMap;
import java.util.TreeSet;

public class InvertedIndexBuilder {
    public static TreeMap<String, TreeSet<Integer>> build(Collection<Document> documents){
        TreeMap<String, TreeSet<Integer>> result = new TreeMap<String, TreeSet<Integer>>(new Comparator<String>() {
            @Override
            public int compare(String o1, String o2) {
                return o1.compareToIgnoreCase(o2);
            }
        });

        for (Document document : documents){
            String[] words = document.getText().split("[,. !?\"\':]+");
            for (String word : words){
                if (!result.containsKey(word)){
                    result.put(word, new TreeSet<Integer>());
                }

                TreeSet<Integer> documentsId = result.get(word);
                documentsId.add(document.getId());
            }
        }

        return result;
    }
}
