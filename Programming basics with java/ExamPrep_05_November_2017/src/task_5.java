import java.util.Scanner;

public class task_5 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());

        for (int row = 0; row < n; row++) {
            System.out.print(repeatStr(n, " "));
            System.out.println("~ ~ ~");
        }
        System.out.println(repeatStr((n * 3 + 6) - 1 ,"="));
        for (int i = 0; i < (n - 2) / 2; i++) {
            System.out.print("|");
            System.out.print(repeatStr((3 * n + 6 )- n - 2,"~"));
            System.out.print("|");
            System.out.print(repeatStr(n - 1 ," "));
            System.out.println("|");

        }
        System.out.print("|");
        System.out.print(repeatStr(n ,"~"));
        System.out.print("JAVA");
        System.out.print(repeatStr(n ,"~"));
        System.out.print("|");
        System.out.print(repeatStr(n - 1, " "));
        System.out.println("|");

        for (int i = 0; i < (n - 3) / 2; i++) {
            System.out.print("|");
            System.out.print(repeatStr((3 * n + 6 )- n - 2,"~"));
            System.out.print("|");
            System.out.print(repeatStr(n - 1 ," "));
            System.out.println("|");

        }
        System.out.println(repeatStr((n * 3 + 6) - 1 ,"="));

        for (int row = 0; row < n; row++) {
            System.out.print(repeatStr(row ," "));
            System.out.print("\\");
            System.out.print(repeatStr(((3 * n + 6 )- n - 2)-row-row,"@"));
            System.out.println("/");
        }

        System.out.println(repeatStr((3 * n + 6)-n,"="));
    }
    static String repeatStr (int count ,String text){
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) {
            sb.append(text);
        }
        return sb.toString();
    }
}
