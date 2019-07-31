import java.util.Scanner;

public class p06CircleAreaAndPerimeter {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        double r =Double.parseDouble(s.nextLine());
        double area = Math.PI*r*r;
        double perimeter = 2*Math.PI*r;

        System.out.println("Area = "+area);
        System.out.println("Perimeter = "+perimeter);
    }
}
