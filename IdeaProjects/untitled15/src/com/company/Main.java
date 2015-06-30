package com.company;

import javafx.util.Pair;

import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class Main {

    public static void main(String[] args) {
	// write your code here
        int[] array = new int[]{1, 2, 3, 4, 5};

        List<Integer> list = Arrays.asList(1, 2, 3, 4, 5, 6, 7);
        //list.forEach(n -> System.out.println(n));

        list.stream()
                .filter((x) -> x % 2 == 0)
                .collect(Collectors.toList())
                .forEach(System.out::println);

        System.out.println(list.stream().map(x -> x + 1).reduce((x1, x2) -> x1 + x2).get());

        List<List<Integer>> lines = Arrays.asList(Arrays.asList(1, 2, 3), Arrays.asList(0, -1, 2), Arrays.asList(5, -10, 100));

        List<List<Integer>> res = lines.stream()
                                        .map((x) -> x.stream()
                                                .filter(y -> y > 0)
                                                .collect(Collectors.toList()))
                                        .collect(Collectors.toList());

        System.out.println("--------------");
        res.stream().map(x -> String.join(" , ", x.stream().map(y -> y.toString()).collect(Collectors.toList()))).forEach(System.out::println);

        List<Integer> a = Arrays.asList(2, 3, 4);
        int result = a.stream().reduce((x, y) -> x-y).get();

        System.out.println(result);

        List<String> words = Arrays.asList("masha", "dasha", "sasha", "denis", "masha", "denis");


        Map<Character, List<String>> collect = words.stream().collect(Collectors.groupingBy(x -> x.charAt(0)));

        for (char key : collect.keySet()){
            System.out.println(key + ":");
           System.out.println(collect.get(key).stream().collect(Collectors.joining(",")));
        }

        String text = "masha loved denis";

        Integer val = 0;
        List<Integer> list2 = Stream.generate(val::intValue).limit(10).collect(Collectors.toList());
        List<Integer> collect1 = Stream.iterate(0, x -> x + 1).limit(5).collect(Collectors.toList());
        collect1.forEach(System.out::println);

        String text1 = "Masha, dasha, nastya, alesya!!! Masha loved denis, denis loved masha!!";
        getDict(text1, 100).forEach(System.out::println);

        List<Document> documents = Arrays.asList(new Document(1, "Hello world!"), new Document(2, "World, world, world... Just words..."), new Document(3, "Words — power"), new Document(4, ""));
        getInvertedIndex(documents).forEach((k, v) ->System.out.println( k + " : " + v.stream().map(x -> x.getValue().toString()).collect(Collectors.joining(" , "))));
    }

    public static Map<String, List<Pair<String, Integer>>> getInvertedIndex(List<Document> documents){
        Stream<Pair<String, Integer>> pairStream = documents.stream()
                .map(doc -> Stream.of(doc.Text.toLowerCase().split("\\W+"))
                        .filter(w -> !w.isEmpty())
                        .distinct()
                        .map(w -> new Pair<String, Integer>(w, doc.Id)))
                .reduce((x, y) -> Stream.concat(x, y))
                .get();

        return pairStream.collect(Collectors.groupingBy((x) -> x.getKey()));
    }

    public static boolean ContainsKey(List<String> text, String key){
        return text.stream()
                    .map(line -> line.split(" ")[0])
                    .collect(Collectors.toMap(x -> x, x ->x))
                    .containsKey(key);
    }

    public static List<Pair<String, Integer>> getDict(String text, int limit){
        return
                Stream.of(text.split("\\W+"))
                        .filter(word -> !word.isEmpty())
                        .map(word -> word.toLowerCase())
                        .collect(Collectors.groupingBy(word -> word))
                        .entrySet()
                        .stream()
                        .map(group -> new Pair<String, Integer>(group.getKey(), group.getValue().size()))
                        .limit(limit)
                        .sorted(Comparator.comparing(Pair<String, Integer>::getValue).reversed().thenComparing(Comparator.comparing(Pair<String, Integer>::getKey)))
                        .collect(Collectors.toList());

    }
}
