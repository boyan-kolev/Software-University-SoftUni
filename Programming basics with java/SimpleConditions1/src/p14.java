import java.util.Scanner;

public class p14 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int hours = Integer.parseInt(console.nextLine());
        int minutes = Integer.parseInt(console.nextLine());
        int min15 = minutes + 15;
        if (min15 > 59){
            min15 = min15-60;
            hours += 1;
        }
        if (hours > 23){
            hours = 0;
        }

        System.out.printf("%d:%02d",hours,min15);
    }
}
