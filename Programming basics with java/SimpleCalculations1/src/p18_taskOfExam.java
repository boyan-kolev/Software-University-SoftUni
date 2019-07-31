import java.util.Scanner;

public class p18_taskOfExam {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int days = Integer.parseInt(console.nextLine());
        int confectioners = Integer.parseInt(console.nextLine());
        int cake = Integer.parseInt(console.nextLine());
        int wafer = Integer.parseInt(console.nextLine());
        int pancake = Integer.parseInt(console.nextLine());

        double sumCake = cake * 45;
        double sumWafer = wafer * 5.80;
        double sumPancake = pancake * 3.20;

        double sumDays = (sumCake + sumWafer + sumPancake)*confectioners;
        double totalSum = sumDays * days;

        double sumAfterCosts = totalSum -(totalSum /8);

        System.out.printf("%.2f%n",sumAfterCosts);

    }
}
