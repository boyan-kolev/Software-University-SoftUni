import java.util.Scanner;

public class p18_PipesInThePool {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int volume = Integer.parseInt(scan.nextLine());
        int pipe1 = Integer.parseInt(scan.nextLine());
        int pipe2 = Integer.parseInt(scan.nextLine());
        double hours = Double.parseDouble(scan.nextLine());

        double water = (hours * pipe1) + (hours * pipe2);
        if (volume >= water) {

            System.out.printf("The pool is %.0f%% full. Pipe 1: %.0f%%. Pipe 2: %.0f%%.",
                    Math.floor((water / volume) * 100),
                    Math.floor(((pipe1 * hours) / water) * 100),
                    Math.floor(((pipe2 * hours) / water) * 100));

        } else {
            System.out.printf("For %1f hours the pool overflows with %.1f liters.", hours, water - volume);
        }
    }
}
