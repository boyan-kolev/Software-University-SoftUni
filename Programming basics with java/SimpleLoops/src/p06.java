import java.util.Scanner;

public class p06 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int maxNum = Integer.MAX_VALUE;
        for (int i = 0; i < n; i++) {
            int currentNumber = Integer.parseInt(console.nextLine());
            if (currentNumber <= maxNum){
                maxNum = currentNumber;
            }
        }
        System.out.println(maxNum);
    }
}
