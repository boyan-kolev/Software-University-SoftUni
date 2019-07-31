import java.util.Scanner;

public class p12 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int f1 = 1;
        int f2 = 1;
        for (int i = 0; i < n - 1; i++) {
            int next = f1 + f2;
            f1 = f2;
            f2 = next;
        }
        System.out.println(f2);
    }
}
