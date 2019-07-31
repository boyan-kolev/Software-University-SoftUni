import java.util.Scanner;

public class task_3 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double weight = Double.parseDouble(console.nextLine());
        String type = console.nextLine();
        int distance = Integer.parseInt(console.nextLine());
        double price = 0;
        double nadcenka = 0;
        double transportKm = 0;

        if (type.equalsIgnoreCase("standard")){
            if (weight < 1){
                price = distance * 0.03;
            }else if (weight >= 1 && weight <= 10){
                price = distance * 0.05;
            }else if (weight >= 11 && weight <= 40){
                price = distance * 0.10;
            }else if (weight >= 41 && weight <= 90){
                price = distance * 0.15;
            }else if (weight >= 91 && weight <= 150){
                price = distance * 0.20;
            }
        }else if (type.equalsIgnoreCase("express")){
            if (weight < 1){
                transportKm = distance * 0.03;
                nadcenka = distance * (weight * (0.80 * 0.03));
                price = nadcenka + transportKm;
            }else if (weight >= 1 && weight <= 10){
                transportKm = distance * 0.05;
                nadcenka = distance * (weight * (0.40 * 0.05));
                price = nadcenka + transportKm;
            }else if (weight >= 11 && weight <= 40){
                transportKm = distance * 0.10;
                nadcenka = distance * (weight * (0.05 * 0.10));
                price = nadcenka + transportKm;
            }else if (weight >= 41 && weight <= 90){
                transportKm = distance * 0.15;
                nadcenka = distance * (weight * (0.02 * 0.15));
                price = nadcenka + transportKm;
            }else if (weight >= 91 && weight <= 150){
                transportKm = distance * 0.20;
                nadcenka = distance * (weight * (0.01 * 0.20));
                price = nadcenka + transportKm;
            }
        }
        System.out.printf("The delivery of your shipment with weight of %.3f kg. would cost %.2f lv.%n",weight ,price);
    }
}
