import java.util.Scanner;

public class p19_taskOfExam {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double priceOfWhiskey = Double.parseDouble(console.nextLine());
        double quantityOfBeer = Double.parseDouble(console.nextLine());
        double quantityOfWine = Double.parseDouble(console.nextLine());
        double quantityOfBrandy = Double.parseDouble(console.nextLine());
        double quantityOfWhiskey = Double.parseDouble(console.nextLine());

        double priceOfBrandy = priceOfWhiskey / 2;
        double priceOfWine = priceOfBrandy -(0.4 * priceOfBrandy);
        double priceOfBeer = priceOfBrandy -(0.8 * priceOfBrandy);

        double sumOfBrandy = quantityOfBrandy * priceOfBrandy;
        double sumOfWine = quantityOfWine * priceOfWine;
        double sumOfBeer = quantityOfBeer * priceOfBeer;
        double sumOfWhiskey = quantityOfWhiskey * priceOfWhiskey;

        double totalSum = sumOfBrandy + sumOfWine + sumOfBeer + sumOfWhiskey;

        System.out.printf("%.2f%n",totalSum);

    }
}
