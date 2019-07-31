import java.util.Scanner;

public class p15_3EqualNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        double number1 = Double.parseDouble(scan.nextLine());
        double number2 = Double.parseDouble(scan.nextLine());
        double number3 = Double.parseDouble(scan.nextLine());

        if ((number1 == number2)&&(number2 == number3)){
            System.out.println("yes");
        }else {
            System.out.println("no");
        }
    }
}
