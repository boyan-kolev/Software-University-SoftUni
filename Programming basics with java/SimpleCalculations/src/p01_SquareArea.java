import java.util.Scanner;

public class p01_SquareArea {
    public static void main(String[] args) {
        System.out.print("Enter a: ");
        Scanner scan = new Scanner(System.in);
        double side = Double.parseDouble(scan.nextLine());
        double area = Math.pow(side, 2);
        System.out.printf("area is %f",area);

    }
}
