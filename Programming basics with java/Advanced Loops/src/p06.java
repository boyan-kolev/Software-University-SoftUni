import java.util.Scanner;

public class p06 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n;
        do {
            n = Integer.parseInt(console.nextLine());
        } while (n < 1 || n > 100);
        System.out.println(n);
    }
}




