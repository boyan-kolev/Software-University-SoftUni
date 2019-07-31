import java.util.Scanner;

public class p08 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String town = console.nextLine();
        double salesVolume = Double.parseDouble(console.nextLine());
        double commission = -1;

        if (town.equals("Sofia")) {
            if (salesVolume >= 0 && salesVolume <= 500) {
                commission = 0.05;
            } else if (salesVolume > 500 && salesVolume <= 1000) {
                commission = 0.07;
            } else if (salesVolume > 1000 && salesVolume <= 10000) {
                commission = 0.08;
            } else if (salesVolume > 10000) {
                commission = 0.12;
            }
        } else if (town.equals("Varna")) {
            if (salesVolume >= 0 && salesVolume <= 500) {
                commission = 0.045;
            } else if (salesVolume > 500 && salesVolume <= 1000) {
                commission = 0.075;
            } else if (salesVolume > 1000 && salesVolume <= 10000) {
                commission = 0.10;
            } else if (salesVolume > 10000) {
                commission = 0.13;
            }

        } else if (town.equals("Plovdiv")) {
            if (salesVolume >= 0 && salesVolume <= 500) {
                commission = 0.055;
            } else if (salesVolume > 500 && salesVolume <= 1000) {
                commission = 0.08;
            } else if (salesVolume > 1000 && salesVolume <= 10000) {
                commission = 0.12;
            } else if (salesVolume > 10000) {
                commission = 0.145;
            }
        } else {
            System.out.println("error");
        }
        if (commission == -1) {
            System.out.println("error");
        } else {
            commission = commission * salesVolume;

            System.out.printf("%.2f", commission);
        }
    }
}
