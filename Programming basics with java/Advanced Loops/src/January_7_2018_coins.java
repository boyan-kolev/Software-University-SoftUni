import java.text.DecimalFormat;
import java.util.Scanner;

public class January_7_2018_coins {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double n = Double.parseDouble(console.nextLine());
        boolean isValid = true;
        int count = 0;
        double num;

        if (n <= 0) {
            return;
        }

        while (isValid){
            if (n >= 2){
                n -= 2;
                count++;
            }else if (n >= 1 && n < 2){
                n -= 1;
                count++;
            }else if (n >= 0.50 && n < 1){
                num = n - 0.50;
                n = (int)(num * 100 +0.5) / 100.0;
                count++;
            }else if (n >= 0.20 && n < 0.50){
                num = n - 0.20;
                n = (int)(num * 100 +0.5) / 100.0;
                count++;
            }else if (n >= 0.10 && n < 0.20){
                num = n - 0.10;
                n = (int)(num * 100 +0.5) / 100.0;
                count++;
            }else if (n >= 0.05 && n < 0.10){
                num = n - 0.05;
                n = (int)(num * 100 +0.5) / 100.0;
                count++;
            }else if (n >= 0.02 && n < 0.05){
                num = n - 0.02;
                n = (int)(num * 100 +0.5) / 100.0;
                count++;
            }else {
                num = n - 0.01;
                n = (int)(num * 100 +0.5) / 100.0;
                count++;
            }

            if (n < 0.01){
                isValid = false;
            }
        }
        System.out.println(count);
    }
}
