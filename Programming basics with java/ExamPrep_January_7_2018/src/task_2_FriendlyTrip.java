import java.util.Scanner;

public class task_2_FriendlyTrip {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int distanse = Integer.parseInt(console.nextLine());
        int costOfFuel = Integer.parseInt(console.nextLine());
        double priceOfFuel = Double.parseDouble(console.nextLine());
        int sum = Integer.parseInt(console.nextLine());

        double carConsumator = (distanse * costOfFuel) / 100;
        double totalCosts = carConsumator * priceOfFuel;
        double available = sum - totalCosts;

        if (available >= 0){
            System.out.printf("You can take a trip. %.2f money left.%n",available);
        }else {
            double newSum = sum / 5.0;
            System.out.printf("Sorry, you cannot take a trip. Each will receive %.2f money.%n",newSum);
        }
    }
}
