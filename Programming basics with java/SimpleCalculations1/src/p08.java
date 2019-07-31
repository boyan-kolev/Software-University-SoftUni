import java.util.Scanner;

public class p08 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double side = Double.parseDouble(console.nextLine());
        double height = Double.parseDouble(console.nextLine());

        double area = (side * height)/2;
        System.out.printf("Triangle area = %.2f",area);
    }
}
