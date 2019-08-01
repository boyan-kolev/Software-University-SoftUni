import java.util.Scanner;

public class p04_SumNIntegers {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int count = Integer.parseInt(console.nextLine());
        int sum = 0;

        for (int i = 0; i < count; i++) {
            int currNum = Integer.parseInt(console.nextLine());
            sum += currNum;
        }

        System.out.printf("Sum = %d", sum);
    }
}
