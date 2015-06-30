package Reader;

import java.io.*;
import java.util.*;


public class Reader {
    private Scanner in;

    public ArrayList<String>ReadFile(String file, String encoding) throws FileNotFoundException, IOException{

        ArrayList<String> inputLines = new ArrayList<String>();

        in  = new Scanner(new BufferedReader(new InputStreamReader(new FileInputStream(file), encoding)));


        while (in.hasNext()){
            inputLines.add(in.nextLine());
        }
        for (string line : new string[]{"1", "2", "3"}){
            System.out.println(line);
        }

        System.out.println("Hello");

        return inputLines;
    }

}
