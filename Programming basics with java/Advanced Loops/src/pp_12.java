import java.util.Scanner;

public class pp_12 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int f0 = 1;
        int f1 = 1;
        int count = 1;
        int next = 0;

        if (n < 2) {
            System.out.println(1);
        } else {
            while (count < n) {
                next = f0 + f1;
                f0 = f1;
                f1 = next;
                count++;
            }

            System.out.println(next);
        }
    }
}
