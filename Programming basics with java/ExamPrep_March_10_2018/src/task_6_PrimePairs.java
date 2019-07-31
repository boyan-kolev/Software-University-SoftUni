import java.util.Scanner;

public class task_6_PrimePairs {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int num1 = Integer.parseInt(console.nextLine());
        int num2 = Integer.parseInt(console.nextLine());
        int razlika1 = Integer.parseInt(console.nextLine());
        int razlika2 = Integer.parseInt(console.nextLine());


        int kraina1 = num1 + razlika1;
        int kraina2 = num2 + razlika2;

        for (int i = num1; i <= kraina1; i++) {
            for (int j = num2; j <= kraina2; j++) {
                int currNum = 2;
                int currNum1 = 2;
                boolean isPrime = true;
                while (currNum < i) {
                    if (i % currNum == 0) {
                        isPrime = false;
                        break;
                    }
                    currNum++;
                }
                boolean isPrimet = true;
                while (currNum1 < j) {
                    if (j % currNum1 == 0) {
                        isPrimet = false;
                        break;
                    }
                    currNum1++;
                }
                if (isPrimet && isPrime) {
                    System.out.println(i + "" + j + " ");
                }

            }
        }
    }
}
