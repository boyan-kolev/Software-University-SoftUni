import java.util.Scanner;

public class p11 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());


        for (int row = 0; row < (n + 1) /2; row++) {
            int leftRight = (n - 1) / 2;
            System.out.print(repeatStr(leftRight, "-"));
            System.out.print("*");

            int mid = n - 2 * leftRight - 2;
            if (mid >= 0){
                System.out.print(repeatStr(mid,"-"));
                System.out.print("*");
            }
            System.out.println(repeatStr(leftRight, "-"));
            leftRight--;
            
        }

        for (int row = 0; row < (n - 1) / 2; row++) {
            int leftRight = (n - 1) / 2;
            System.out.print(repeatStr(row +1 ,"-"));
            System.out.print("*");
            int mid = n - 2 * leftRight - 2;
            if (mid >= 0){
                System.out.print(repeatStr(n - 4 -row -row ,"-"));
                System.out.print("*");
            System.out.println(repeatStr(row +1 ,"-"));
            leftRight--;
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
