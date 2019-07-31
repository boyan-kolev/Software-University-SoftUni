import java.util.Scanner;

public class task_4_ASCIICombinations {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int sum1 = 0;
        int sum2 = 0;
        int sum3 = 0;
        int sum4 = 0;
        String result1 = "";
        String result2 = "";
        String result3 = "";
        String result4 = "";
        int output = 0;
        StringBuilder sb1 = new StringBuilder();
        StringBuilder sb2 = new StringBuilder();
        StringBuilder sb3 = new StringBuilder();
        StringBuilder sb4 = new StringBuilder();
        for (int i = 0; i < n; i++) {
            char symbol = console.next().charAt(0);
            if (Character.toString(symbol).matches("[0-9?]")) {
                sb1.append(symbol);
                output = ((int) symbol);
                sum1 += output;
            } else if (Character.toString(symbol).matches("[A-Z?]")) {
                sb2.append(symbol);
                output = ((int) symbol);
                sum2 += output;
            } else if (Character.toString(symbol).matches("[a-z?]")) {
                sb3.append(symbol);
                output = ((int) symbol);
                sum3 += output;
            } else {
                sb4.append(symbol);
                output = ((int) symbol);
                sum4 += output;
            }
        }

        int max1 = Math.max(sum1, sum2);
        int max2 = Math.max(sum3, sum4);
        int max = Math.max(max1, max2);
        StringBuilder maxValue = new StringBuilder();
        if (max == sum1) {
            maxValue = sb1;
        } else if (max == sum2) {
            maxValue = sb2;
        }else if (max == sum3) {
            maxValue = sb3;
        }else if (max == sum4) {
            maxValue = sb4;
        }
        if (sum1 == sum2 || sum1 == sum3 ||sum1 == sum4){
            maxValue = sb1;
        }else if (sum2 == sum3 || sum2 == sum4){
            maxValue = sb2;
        }else if (sum3 == sum4){
            maxValue = sb3;
        }

        System.out.printf("Biggest ASCII sum is:%d%n",max);
        System.out.printf("Combination of characters is:%s",maxValue);
    }
}
