import java.util.Scanner;

public class p07 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int sec1 = Integer.parseInt(console.nextLine());
        int sec2 = Integer.parseInt(console.nextLine());
        int sec3 = Integer.parseInt(console.nextLine());

        int sumSec = sec1 + sec2 + sec3;
        int minutes = sumSec / 60;
        int secunds = sumSec % 60;

        System.out.printf("%d:%02d%n",minutes, secunds);
    }
}
