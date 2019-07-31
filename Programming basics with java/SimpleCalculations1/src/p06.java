import java.util.Scanner;

public class p06 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double radius = Double.parseDouble(console.nextLine());
        double perimeter = 2 * Math.PI * radius;
        double area = Math.PI * Math.pow(radius,2);

        System.out.println("Area: "+area);
        System.out.println("Perimeter: "+perimeter);
    }
}
