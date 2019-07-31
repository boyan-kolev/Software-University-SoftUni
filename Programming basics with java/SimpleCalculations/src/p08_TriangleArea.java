import java.util.Scanner;

public class p08_TriangleArea {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        double side =Double.parseDouble(sc.nextLine());
        double height =Double.parseDouble(sc.nextLine());

        double area = (side*height)/2;
        System.out.printf("The area of triangle is: %.2f",area);

    }
}
