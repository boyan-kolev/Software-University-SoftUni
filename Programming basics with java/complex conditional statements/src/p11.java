import java.util.Scanner;

public class p11 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String projectionType = console.nextLine();
        int rows = Integer.parseInt(console.nextLine());
        int coloums = Integer.parseInt(console.nextLine());
        double price = -1;
        int numberOfPlaces = rows * coloums;

        if (projectionType.equals("Premiere")){
            price = 12.00;
        }else if (projectionType.equals("Normal")){
            price = 7.50;
        }else if (projectionType.equals("Discount")){
            price = 5.00;
        }
        double totalPrice = price * numberOfPlaces;
        System.out.printf("%.2f leva",totalPrice);

    }
}
