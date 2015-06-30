package com.company;

import java.io.*;
import java.util.ArrayList;
import java.util.TreeMap;
import java.util.TreeSet;

public class Main {
    public final int MAX_LINE_COUNT = 20;

    public void doSomething(){
        ArrayList<Document> documents = new ArrayList<Document>();
        try(BufferedReader reader = new BufferedReader(new FileReader("small.txt"))){
            String line = null;
            int documentNumber = 0;
            while ((line = reader.readLine()) != null){
                documents.add(new Document(documentNumber, line));
                documentNumber++;
            }
        }
        catch (IOException e) {
            e.printStackTrace();
        }


        TreeMap<String, TreeSet<Integer>> result = InvertedIndexBuilder.build(documents);


        try(BufferedReader reader = new BufferedReader(new FileReader("small.queries.txt"))){
            String line = null;
            int documentNumber = 0;
            while ((line = reader.readLine()) != null){
                String[] queries = line.split(" ");
                TreeSet<Integer> res = new TreeSet<Integer>();
                boolean flag = true;
                for (String query : queries){
                    if (result.containsKey(query)){
                        if (flag){
                            res = result.get(query);
                            flag = false;
                        }
                        else{
                            res.retainAll(result.get(query));
                        }
                    }
                }

                for (Integer i : res){
                    System.out.print(i + " ");
                }
                System.out.println();
            }
        }
        catch (IOException e) {
            e.printStackTrace();
        }
    }


    public static void main(String[] args) {
                String [] words = new String[]{"aaa","aab","aac","aad","abc","bbb","ccc","abb","ddd","aa","ab","ac","ba","ad","bc","a","b","c","d"};
        ArrayList<String> ladder = LadderBuilder.build(words, "aaa", "bbb");

        for (String word:ladder){
            System.out.println(word);
        }
    }
}
