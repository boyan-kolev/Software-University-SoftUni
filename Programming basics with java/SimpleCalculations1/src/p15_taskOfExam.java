import java.util.Scanner;

public class p15_taskOfExam {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int length = Integer.parseInt(console.nextLine());
        int width = Integer.parseInt(console.nextLine());
        int height = Integer.parseInt(console.nextLine());
        double inputPercent = Double.parseDouble(console.nextLine());

        int volume = length * width * height;
        double liters = volume * 0.001;
        double percent = inputPercent * 0.01;
        double totalLiters = liters * (1-percent);

        System.out.printf("%.3f",totalLiters);
    }
}
