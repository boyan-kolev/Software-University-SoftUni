import java.util.Scanner;

public class p05 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double side1 = Double.parseDouble(console.nextLine());
        double side2 = Double.parseDouble(console.nextLine());
        double height = Double.parseDouble(console.nextLine());

        double area = (side1 + side2)* height/2;
        System.out.println(area);
    }
}
