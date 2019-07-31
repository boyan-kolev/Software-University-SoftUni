import java.util.Scanner;

public class p03 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        System.out.println("1");
        for (int i = 1; i <= n; i++) {
            double currNum = Math.pow(2,i);
            System.out.println((int)currNum);
        }

    }
}
