import java.util.Arrays;
import java.util.Scanner;

public class p08_MaxSequenceOfIncreasingEl {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int[] numbers = Arrays.stream(console.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        if (numbers.length == 1){
            System.out.println(numbers[0]);
            return;
        }

        int currValue = Integer.MIN_VALUE;
        int value = numbers[0];
        int currCount = 1;
        int count = 1;
        boolean isFlag = true;


        for (int i = 1; i < numbers.length; i++) {
            if (numbers[i - 1] < numbers[i]) {
                currValue = numbers[i];
                currCount++;
            } else {

                if (currCount > count) {
                    value = currValue;
                    count = currCount;
                    isFlag = false;
                }
                currCount = 1;
                currValue = numbers[i];
            }
        }

        if (currCount > count) {
            value = currValue;
            count = currCount;
        }


        if (isFlag){
            value = currValue;
            count = currCount;
        }

        for (int i = 0; i < count; i++) {
            System.out.printf("%d ", value - count + 1 + i);
        }
        System.out.println();
    }
}
