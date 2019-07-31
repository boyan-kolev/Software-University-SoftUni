import java.util.Scanner;

public class December_17_2017 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int firstNum = n % 10;
        n = n / 10;
        int secondNum = n % 10;
        int lastNum = n / 10;

        for (int i = 1; i <= firstNum; i++) {
            for (int j = 1; j <= secondNum; j++) {
                for (int k = 1; k <= lastNum; k++) {
                    int sum = i * j * k;
                    System.out.printf("%d * %d * %d = %d;%n",i ,j, k, sum);
                }
            }
        }
    }
}
