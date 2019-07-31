import java.util.Scanner;

public class task_4 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int days = Integer.parseInt(console.nextLine());
        double totalLiters = 0.0;
        double degreesMultLiters = 0.0;
        for (int i = 0; i < days; i++) {
            double quantity = Double.parseDouble(console.nextLine());
            double degrees = Double.parseDouble(console.nextLine());
            totalLiters += quantity;
            degreesMultLiters = degreesMultLiters + quantity * degrees;
        }
        double totalDegrees = degreesMultLiters / totalLiters;
        System.out.printf("Liter: %.2f%n",totalLiters);
        System.out.printf("Degrees: %.2f%n",totalDegrees);

        if (totalDegrees < 38){
            System.out.println("Not good, you should baking!");
        }else if (totalDegrees <= 42){
            System.out.println("Super!");
        }else if (totalDegrees > 42){
            System.out.println("Dilution with distilled water!");
        }
    }
}
