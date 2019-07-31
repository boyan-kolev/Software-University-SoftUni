import java.util.Scanner;

public class p07 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int leftSum = 0;
        int rightSum = 0;
        int totalSum;
        for (int i = 0; i < n*2 ; i++) {
            if (i < n){
                int currentLeftSum = Integer.parseInt(console.nextLine());
                leftSum += currentLeftSum;
            }else {
                int currentRightSum = Integer.parseInt(console.nextLine());
                rightSum += currentRightSum;
            }
        }
        if (leftSum == rightSum){
            System.out.printf("Yes, sum = %d%n",leftSum);
        }else {
            totalSum = Math.abs(leftSum - rightSum);
            System.out.printf("No, diff = %d%n",totalSum);
        }
    }
}
