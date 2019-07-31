import java.util.Scanner;

public class p01 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        System.out.print("Enter a: ");
        double a = Double.parseDouble(console.nextLine());
        double area =Math.pow(a,2);
        System.out.println(area);
    }
}
