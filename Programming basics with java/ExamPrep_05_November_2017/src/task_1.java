import java.util.Scanner;

public class task_1 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int lenght = Integer.parseInt(console.nextLine());
        int width = Integer.parseInt(console.nextLine());
        double hight = Double.parseDouble(console.nextLine());
        double priceM2 = Double.parseDouble(console.nextLine());
        double weightM3 = Double.parseDouble(console.nextLine());

        double lenghtOfNetwork = 2 * (lenght + width);
        double priceOfNetwork = lenghtOfNetwork * priceM2;
        double areaOfNetwork = lenghtOfNetwork * hight;
        double weightOfNetwork = areaOfNetwork * weightM3;

        System.out.printf("%.0f%n",lenghtOfNetwork);
        System.out.printf("%.2f%n",priceOfNetwork);
        System.out.printf("%.3f%n",weightOfNetwork);
    }
}
