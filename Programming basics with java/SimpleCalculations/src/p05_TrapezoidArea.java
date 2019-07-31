import java.util.Scanner;

public class p05_TrapezoidArea {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double base1 = Double.parseDouble(console.nextLine());
        double base2 = Double.parseDouble(console.nextLine());
        double height = Double.parseDouble(console.nextLine());
        double area = ((base1 + base2)*height)/2;
        System.out.println("Trapezoid area = "+area);
    }
}
