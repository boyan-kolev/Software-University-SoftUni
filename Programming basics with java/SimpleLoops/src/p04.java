import java.text.DecimalFormat;
import java.util.Scanner;

public class p04 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        DecimalFormat df = new DecimalFormat("#.########################");
        int number = Integer.parseInt(console.nextLine());
        double sum = 0;
        for (int i = 0; i < number; i++) {
            int currentNumber = Integer.parseInt(console.nextLine());
            sum +=currentNumber;
        }
        System.out.println(df.format(sum));
    }
}
