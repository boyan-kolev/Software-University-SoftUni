import java.util.Scanner;

public class pp_14 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int num ;
        for (int row = 0; row < n; row++) {
            for (int col = 0; col < n; col++) {
                num = row + col + 1;
                if (num > n){
                    num = 2 * n - num;
                }
                System.out.print(num + " ");
            }
            System.out.println();
        }
    }
}
