import java.util.Scanner;

public class p10 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int maxNum = Integer.MIN_VALUE;
        int sum = 0;
        int diff = 0;
        for (int i = 0; i < n; i++) {
            int currentNumber = Integer.parseInt(console.nextLine());
            sum += currentNumber;
            if (maxNum <= currentNumber){
                maxNum = currentNumber;
            }
        }
        if ((maxNum == (sum - maxNum))){
            System.out.printf("Yes%nSum = %d",(sum - maxNum));
        }else {
            diff = Math.abs((sum - maxNum)-maxNum);
            System.out.printf("No%nDiff = %d",diff);
        }
    }
}
