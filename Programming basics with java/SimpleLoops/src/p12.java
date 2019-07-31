import java.util.Scanner;

public class p12 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int diff = 0;
        int prevSum = 0;
        int currSum =0;
        int maxDiff = 0;
        for (int i = 0; i < n; i++) {
            prevSum = currSum;
            int number1 = Integer.parseInt(console.nextLine());
            int number2 = Integer.parseInt(console.nextLine());
            currSum = number1 + number2;
            if (i != 0){
                diff = Math.abs(currSum - prevSum);
                if (diff != 0 && diff > maxDiff){
                    maxDiff = diff;
                }
            }

        }
        if (maxDiff == 0) {
            System.out.printf("Yes, value=%d%n", currSum);
        }else {
            System.out.printf("No, maxdiff=%d%n",maxDiff);
        }
    }
}
