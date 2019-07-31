import java.util.Scanner;

public class p08 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int evenSum = 0;
        int oddSum = 0;
        int totalSum = 0;
        for (int i = 0; i < n; i++) {
            if (i % 2 ==0){
                int currentEvenSum = Integer.parseInt(console.nextLine());
                evenSum += currentEvenSum;
            }else {
                int currentOddSum = Integer.parseInt(console.nextLine());
                oddSum += currentOddSum;
            }
        }
        if (evenSum == oddSum){
            System.out.printf("Yes%nSum = %d",evenSum);
        }else {
            totalSum = Math.abs(evenSum - oddSum);
            System.out.printf("No%nDiff = %d",totalSum);
        }
    }
}
