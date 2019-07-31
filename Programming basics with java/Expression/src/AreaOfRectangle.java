import java.util.Scanner;

public class AreaOfRectangle {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        System.out.print("Enter a:" );
        int a = Integer.parseInt(console.nextLine());
        System.out.print("Enter b: ");
        int b = Integer.parseInt(console.nextLine());

        System.out.println("result is: "+( a * b));
    }
}
