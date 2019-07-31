import java.util.Scanner;

public class p10 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int leftRight = (n - 1) / 2;

        if (n % 2 == 0) {
            // First part
            for (int row = 0; row < (n + 1) / 2; row++) {
                System.out.print(repeatStr(((n - 2) / 2) - row, "-"));
                System.out.print("*");
                System.out.print(repeatStr(row * 2, "-"));
                System.out.print("*");
                System.out.println(repeatStr(((n - 2) / 2) - row, "-"));
            }
            //Last part
            for (int row = 0; row < (n - 1) / 2; row++) {
                    System.out.print(repeatStr(row + 1, "-"));
                    System.out.print("*");
                    System.out.print(repeatStr(n - 4 - row - row, "-"));
                    System.out.print("*");
                    System.out.println(repeatStr(row + 1, "-"));

            }


         // n = odd
        }else {
            //First row
            if (n != 1) {
                System.out.print(repeatStr(n / 2, "-"));
                System.out.print("*");
                System.out.println(repeatStr(n / 2, "-"));
            }
            //Middle part 1
            for (int row = 0; row < (n - 1) /2; row++) {
                System.out.print(repeatStr(((n - 3 ) /2) - row, "-"));
                System.out.print("*");
                System.out.print(repeatStr(2* row +1, "-"));
                System.out.print("*");
                System.out.println(repeatStr(((n - 3 ) /2) - row, "-"));

            }
            //Middle part 2
            for (int row = 0; row < (n - 2) /2; row++) {
                System.out.print(repeatStr(row + 1 ,"-"));
                System.out.print("*");
                System.out.print(repeatStr((n - 4 - (2*row)),"-"));
                System.out.print("*");
                System.out.println(repeatStr(row + 1 ,"-"));
            }
            //last row
            System.out.print(repeatStr(n /2, "-"));
            System.out.print("*");
            System.out.println(repeatStr(n /2, "-"));
        }


    }
    static String repeatStr (int count, String text){
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) {
            sb.append(text);
        }
        return sb.toString();
    }
}
