import java.util.Scanner;

public class task_3 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String termOfTheContract = console.nextLine();
        String typeOfTheContract = console.nextLine();
        String addedInternet = console.nextLine();
        int countOfMonth = Integer.parseInt(console.nextLine());
        double sum = 0.0;

        if (termOfTheContract.equalsIgnoreCase("one")){
            if (typeOfTheContract.equalsIgnoreCase("Small")){
                sum = 9.98;
            }else if (typeOfTheContract.equalsIgnoreCase("Middle")){
                sum = 18.99;
            }else if (typeOfTheContract.equalsIgnoreCase("Large")){
                sum = 25.98;
            }else if (typeOfTheContract.equalsIgnoreCase("ExtraLarge")){
                sum = 35.99;
            }
        }else if (termOfTheContract.equalsIgnoreCase("two")){
            if (typeOfTheContract.equalsIgnoreCase("Small")){
                sum = 8.58;
            }else if (typeOfTheContract.equalsIgnoreCase("Middle")){
                sum = 17.09;
            }else if (typeOfTheContract.equalsIgnoreCase("Large")){
                sum = 23.59;
            }else if (typeOfTheContract.equalsIgnoreCase("ExtraLarge")){
                sum = 31.79;
            }
        }
        double internet = 0.0;
        if (addedInternet.equalsIgnoreCase("yes")){
            if (sum <= 10){
                internet = 5.50;
            }else if (sum <= 30){
                internet = 4.35;
            }else {
                internet = 3.85;
            }
        }
        double sumWithInternet = sum + internet;

        if (termOfTheContract.equalsIgnoreCase("two")){
            sumWithInternet = sumWithInternet - ((sumWithInternet * 3.75) / 100);
        }

        double finalPrice = countOfMonth * sumWithInternet;
        System.out.printf("%.2f lv.%n",finalPrice);
    }
}
