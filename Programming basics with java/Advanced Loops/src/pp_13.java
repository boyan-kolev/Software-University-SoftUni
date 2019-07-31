import java.util.Scanner;

public class pp_13 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int count = 1;
        int count1 = 1;
        while (count1 <= n){
            for (int i = 1; i <= count ; i++) {
                System.out.print(count1 + " ");
                count1++;
                if (count1 == n +1){
                    return;
                }
            }
            System.out.println();
            count++;
        }
    }
}
