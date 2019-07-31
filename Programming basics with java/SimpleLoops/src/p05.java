import java.text.DecimalFormat;
import java.util.Scanner;

public class p05 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int minNum = Integer.MIN_VALUE;
        for (int i = 0; i < n; i++) {
            int currentNumber = Integer.parseInt(console.nextLine());
            if (currentNumber >= minNum){
                minNum = currentNumber;
            }
        }
        System.out.println(minNum);
    }
}
