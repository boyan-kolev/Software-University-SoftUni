import java.util.Scanner;

public class p13 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int row = 0;
        int count = 0;
        while (true){
            row++;
            for (int i = 1; i <= row; i++) {
                count++;
                System.out.print(count + " ");
                if (count == n){
                    return;
                }
            }
            System.out.println();
        }
    }
}
