import java.util.Scanner;

public class ex_01 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double n = Double.parseDouble(console.nextLine());
        int count1 = 0;
        int count2 = 0;
        int count3 = 0;
        int count4 = 0;
        int count5 = 0;

        double p1 ,p2, p3, p4, p5;

        for (int i = 0; i < n; i++) {
            int currentNumber = Integer.parseInt(console.nextLine());
            if (currentNumber < 200){
                count1++;
            }else if (currentNumber <= 399){
                count2++;
            }else if (currentNumber <= 599){
                count3++;
            }else if (currentNumber <= 799){
                count4++;
            }else {
                count5++;
            }
        }
        p1 = count1 /n * 100;
        p2 = count2 /n * 100;
        p3 = count3 /n * 100;
        p4 = count4 /n * 100;
        p5 = count5 /n * 100;

        System.out.printf("%.2f%n%.2f%n%.2f%n%.2f%n%.2f%n",p1, p2, p3, p4, p5);
    }
}
