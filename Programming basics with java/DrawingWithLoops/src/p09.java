import java.util.Scanner;

public class p09 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());

        for (int row = 0; row < (n + 1)/2; row++) {
            if (n % 2 == 0){
                System.out.print(repeatStr(((n -2)/2 )-row ,"-"));
                System.out.print(repeatStr((row + 1) *2 ,"*"));
                System.out.println(repeatStr(((n -2 )/2)-row ,"-"));

            }else {
                System.out.print(repeatStr(((n - 1) /2 )-row ,"-"));
                System.out.print(repeatStr(row +row +1 ,"*"));
                System.out.println(repeatStr(((n - 1) /2 )-row ,"-"));
            }
        }

        for (int row = 0; row < n / 2; row++) {
            System.out.print("|");
            System.out.print(repeatStr(n -2 ,"*"));
            System.out.println("|");
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
