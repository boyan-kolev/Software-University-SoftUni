import java.util.Scanner;

public class p07 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double x1 = Double.parseDouble(console.nextLine());
        double y1 = Double.parseDouble(console.nextLine());
        double x2 = Double.parseDouble(console.nextLine());
        double y2 = Double.parseDouble(console.nextLine());

        double side1 = Math.max(x1,x2)-Math.min(x1,x2);
        double side2 = Math.max(y1,y2)-Math.min(y1,y2);

        double area = side1 * side2;
        double perimeter = 2*(side1 + side2);

        System.out.println(area);
        System.out.println(perimeter);

    }
}
