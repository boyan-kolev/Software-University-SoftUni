import java.util.Arrays;
import java.util.Collections;
import java.util.Scanner;

public class p06_Largest3Numbers {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int[] numbers = Arrays.stream(console.nextLine()
                .split(" "))
                .mapToInt(Integer::parseInt)
                .toArray();

        Arrays.sort(numbers);

        for (int i = numbers.length - 1; i >= 0 ; i--) {
            if (i == numbers.length - 4){
                break;
            }
            System.out.println(numbers[i]);
        }

    }
}
