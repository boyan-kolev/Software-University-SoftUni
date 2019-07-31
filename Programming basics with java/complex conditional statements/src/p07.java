import java.util.Scanner;

public class p07 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String fruit = console.nextLine().toLowerCase();
        String dayOfWeek = console.nextLine();
        double quantity = Double.parseDouble(console.nextLine());
        double price = -1;

        switch (dayOfWeek){
            case "Monday":
            case "Tuesday":
            case "Wednesday":
            case "Thursday":
            case "Friday":
                switch (fruit){
                    case "banana":
                        price = 2.50;
                        break;
                    case "apple":
                        price = 1.20;
                        break;
                    case "orange":
                        price = 0.85;
                        break;
                    case "grapefruit":
                        price = 1.45;
                        break;
                    case "kiwi":
                        price = 2.70;
                        break;
                    case "pineapple":
                        price =5.50;
                        break;
                    case "grapes":
                        price =3.85;
                        break;
                        default:
                            System.out.println("error");
                            break;
                }
                break;
                default:
                    System.out.println("error");
                    break;
        }

        switch (dayOfWeek){
            case "Saturday":
            case "Sunday":
                switch (fruit){
                    case "banana":
                        price = 2.70;
                        break;
                    case "apple":
                        price = 1.25;
                        break;
                    case "orange":
                        price = 0.90;
                        break;
                    case "grapefruit":
                        price = 1.60;
                        break;
                    case "kiwi":
                        price = 3.00;
                        break;
                    case "pineapple":
                        price = 5.60;
                        break;
                    case "grapes":
                        price = 4.20;
                        break;
                        default:
                            System.out.println("error");
                            break;
                }
                break;
                default:
                    System.out.println("error");
                    break;
        }

        double totalPrice = quantity * price;
        System.out.println(totalPrice);
    }
}
