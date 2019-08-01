import java.util.Arrays;
import java.util.Scanner;

public class p03_ThreeIntegerSum {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);

        int[] numbers = Arrays.stream(console.nextLine().split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        int num1 = numbers[0];
        int num2 = numbers[1];
        int num3 = numbers[2];

        if (!checkNumbers(num1, num2, num3) && !checkNumbers(num3, num2, num1) && !checkNumbers(num1, num3, num2)){
            System.out.println("No");
        }


    }

    public static boolean checkNumbers(int num1, int num2, int result){
        if (num1 > num2){
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }

        if (num1 + num2 == result){
            System.out.printf("%d + %d = %d", num1, num2, result);
        }else {

            return false;
        }

        return true;

    }
}
