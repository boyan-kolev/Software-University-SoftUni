import java.util.Scanner;
import java.util.TreeMap;

public class p07_SumsByTown {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int countOfTowns = Integer.parseInt(console.nextLine());
        TreeMap<String, Double> towns = new TreeMap<>();

        for (int i = 0; i < countOfTowns; i++) {
            String[] input = console.nextLine().split("\\|");

            String town = input[0].trim();
            double income = Double.parseDouble(input[1].trim());

            if (towns.containsKey(town) == false){
                towns.put(town, income);
            }else {
                towns.put(town, towns.get(town) + income);
            }



        }

        for (String town : towns.keySet()) {
            System.out.println(town + " -> " + towns.get(town));
        }
    }
}
