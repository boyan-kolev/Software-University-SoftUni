import java.util.Scanner;

public class p04 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int number = 1;
        for (int i = 0; i <= n; i += 2) {
            System.out.println(number);
            number *= 4;
        }
    }
}

