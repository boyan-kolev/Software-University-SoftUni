import java.util.Scanner;

public class task_4 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int number = Integer.parseInt(console.nextLine());
        double money = Double.parseDouble(console.nextLine());
        double sum = 0.0;
        for (int i = 0; i < number; i++) {
            String toys = console.nextLine();
            if (toys.equalsIgnoreCase("sand clock")){
                sum += 2.20;
            }else if (toys.equalsIgnoreCase("magnet")){
                sum += 1.50;
            }else if (toys.equalsIgnoreCase("cup")){
                sum += 5.00;
            }else if (toys.equalsIgnoreCase("t-shirt")){
                sum += 10.00;
            }
        }
        double remainigMoney =Math.abs(money - sum);
        if (money >= sum){
            System.out.printf("Santa Claus has %.2f more leva left!%n",remainigMoney);
        }else {
            System.out.printf("Santa Claus will need %.2f more leva.",remainigMoney);
        }
    }
}
