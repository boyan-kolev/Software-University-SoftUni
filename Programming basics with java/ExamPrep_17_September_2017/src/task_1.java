import java.util.Scanner;

public class task_1 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int length = Integer.parseInt(console.nextLine());
        int width = Integer.parseInt(console.nextLine());
        int height = Integer.parseInt(console.nextLine());
        double percentInput = Double.parseDouble(console.nextLine());
        double volume = length * width * height;
        double totalLiters = volume * 0.001;
        double percent = percentInput * 0.01;
        double neededLiters = totalLiters * (1 - percent);
        System.out.printf("%.3f%n",neededLiters);




    }
}
