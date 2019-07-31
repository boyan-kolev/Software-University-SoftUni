import java.util.Scanner;

public class p15 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int num1 = Integer.parseInt(console.nextLine());
        int num2 = Integer.parseInt(console.nextLine());
        int num3 = Integer.parseInt(console.nextLine());

        if ((num1==num2)&&(num1==num3)) {
            System.out.println("yes");
        }else {
            System.out.println("no");
        }
    }
}
