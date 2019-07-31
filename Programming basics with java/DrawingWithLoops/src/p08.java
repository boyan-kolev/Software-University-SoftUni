import java.util.Scanner;

public class p08 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        //first row

        for (int row = 0; row < n; row++) {
            //first part
            if ((row == 0 || row == n - 1)) {
                System.out.print(repeatStr(2 * n, "*"));

            } else {
                System.out.print("*");
                System.out.print(repeatStr((n * 2) - 2, "/"));
                System.out.print("*");
            }

            //Middle part
            if (n % 2 == 0) {//even line
                if (row == n/2 -1){
                    System.out.print(repeatStr(n ,"|"));
                }else {
                    System.out.print(repeatStr(n ," "));
                }
            }else {//odd line
                if (row == n /2){
                    System.out.print(repeatStr(n ,"|"));
                }else {
                    System.out.print(repeatStr(n ," "));
                }
            }

            //last part
            if ((row == 0 || row == n - 1)) {
                System.out.println(repeatStr(2 * n, "*"));

            } else {
                System.out.print("*");
                System.out.print(repeatStr((n * 2) - 2, "/"));
                System.out.println("*");
            }
        }
    }
    static String repeatStr (int count ,String text){
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) {
            sb.append(text);
        }
        return sb.toString();
    }
}
