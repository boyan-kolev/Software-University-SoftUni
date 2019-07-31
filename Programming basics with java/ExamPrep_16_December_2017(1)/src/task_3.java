import java.util.Scanner;

public class task_3 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int days = Integer.parseInt(console.nextLine());
        String typeOfTheRoom = console.nextLine();
        String evaluation = console.nextLine();
        double priceOfTheRoom = 0.0;
        double discount = 0.0;
        double priceWithDiscount = 0.0;

        if (typeOfTheRoom.equalsIgnoreCase("room for one person")) {
                priceWithDiscount = (days - 1) * 18;

        } else if (typeOfTheRoom.equalsIgnoreCase("apartment")) {
                priceOfTheRoom = (days - 1) * 25;
            if (days < 10) {
                discount = priceOfTheRoom * 0.3;
                priceWithDiscount = priceOfTheRoom - discount;
            } else if (days <= 15) {
                priceWithDiscount = priceOfTheRoom - discount;
            } else {
                discount = priceOfTheRoom * 0.5;
                priceWithDiscount = priceOfTheRoom - discount;
            }
        } else if (typeOfTheRoom.equalsIgnoreCase("president apartment")) {
                priceOfTheRoom = (days - 1) * 35;
            if (days < 10) {
                discount = priceOfTheRoom * 0.1;
                priceWithDiscount = priceOfTheRoom - discount;
            } else if (days <= 15) {
                discount = priceOfTheRoom * 0.15;
                priceWithDiscount = priceOfTheRoom - discount;
            } else {
                discount = priceOfTheRoom * 0.2;
                priceWithDiscount = priceOfTheRoom - discount;
            }

        }
        double totalPrice = 0.0;
        if (evaluation.equalsIgnoreCase("positive")){
            double positiveDiscount = priceWithDiscount * 0.25;
            totalPrice = priceWithDiscount + positiveDiscount;
        }else if (evaluation.equalsIgnoreCase("negative")){
            double negativeDiscount = priceWithDiscount * 0.1;
            totalPrice = priceWithDiscount - negativeDiscount;
        }
        System.out.printf("%.2f",totalPrice);
    }
}