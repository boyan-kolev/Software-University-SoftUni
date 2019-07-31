import java.text.DecimalFormat;
import java.util.Scanner;

public class p11 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        DecimalFormat df = new DecimalFormat("#.########################");
        double evenSum = 0;
        double evenMin = Integer.MAX_VALUE;
        double evenMax = Integer.MIN_VALUE;
        double oddSum = 0;
        double oddMin = Integer.MAX_VALUE;
        double oddMax = Integer.MIN_VALUE;
        for (int i = 1; i <= n ; i++) {
            double currentNumber = Double.parseDouble(console.nextLine());
            if (i % 2 == 0){
                evenSum += currentNumber;
                if (currentNumber >= evenMax){
                    evenMax = currentNumber;
                }
                if (currentNumber <= evenMin){
                    evenMin = currentNumber;
                }
            }else {
                oddSum += currentNumber;
                if (currentNumber >= oddMax){
                    oddMax = currentNumber;
                }
                if (currentNumber <= oddMin) {
                    oddMin = currentNumber;
                }
            }
        }
        System.out.println("OddSum="+df.format(oddSum)+",");
        if (oddMin == Integer.MAX_VALUE){
            System.out.println("OddMin=No,");
        }else {
            System.out.println("OddMin="+df.format(oddMin)+",");
        }
        if (oddMax == Integer.MIN_VALUE){
            System.out.println("OddMax=No,");
        }else {
            System.out.println("OddMax="+df.format(oddMax)+",");
        }

        System.out.println("EvenSum="+df.format(evenSum)+",");
        if (evenMin == Integer.MAX_VALUE){
            System.out.println("EvenMin=No,");
        }else {
            System.out.println("EvenMin="+df.format(evenMin)+",");
        }
        if (evenMax == Integer.MIN_VALUE){
            System.out.println("EvenMax=No,");
        }else {
            System.out.println("EvenMax="+df.format(evenMax));
        }
    }
}
