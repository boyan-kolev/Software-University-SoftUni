import java.util.Scanner;

public class p07_SumSeconds {
    public static void main(String[] args) {
        Scanner s = new Scanner(System.in);
        int firstTime = Integer.parseInt(s.nextLine());
        int secondTime = Integer.parseInt(s.nextLine());
        int thirdTime = Integer.parseInt(s.nextLine());
        int time = firstTime + secondTime + thirdTime;

        int minutes = time / 60;
        int seconds = time % 60;

        System.out.printf("%d:%02d",minutes, seconds);
    }
}
