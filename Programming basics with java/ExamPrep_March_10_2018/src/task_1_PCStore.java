import java.util.Scanner;

public class task_1_PCStore {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double procesor = Double.parseDouble(console.nextLine());
        double videokarta = Double.parseDouble(console.nextLine());
        double rampamet = Double.parseDouble(console.nextLine());
        int countPlatki = Integer.parseInt(console.nextLine());
        double procent = Double.parseDouble(console.nextLine());

        double procesorVleva = procesor * 1.57;
        double videokartaVleva = videokarta * 1.57;
        double rampametVleva = rampamet * 1.57;
        double totalPricePlatki = rampametVleva * countPlatki;
        double procesorSOtstupka = procesorVleva * procent;
        procesorSOtstupka = procesorVleva - procesorSOtstupka;
        double videokartaSotstupka = videokartaVleva * procent;
        videokartaSotstupka = videokartaVleva - videokartaSotstupka;

        double totalPrice = totalPricePlatki + procesorSOtstupka + videokartaSotstupka;

        System.out.printf("Money needed - %.2f leva.%n",totalPrice);

    }
}
