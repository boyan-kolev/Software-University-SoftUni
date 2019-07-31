import java.util.Scanner;

public class p16_taskOfExam {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int numberOfTable = Integer.parseInt(console.nextLine());
        double lengthOfTable = Double.parseDouble(console.nextLine());
        double widthOfTable = Double.parseDouble(console.nextLine());

        double areaOfTablecloths = numberOfTable * (lengthOfTable + 2*0.30)*(widthOfTable + 2*0.30);
        double areaOfBox = numberOfTable * (lengthOfTable/2) * (lengthOfTable/2);
        double priceInDollars = (areaOfTablecloths * 7) + (areaOfBox * 9);
        double priceInBGN = priceInDollars * 1.85;

        System.out.printf("%.2f USD%n",priceInDollars);
        System.out.printf("%.2f BGN%n",priceInBGN);

    }
}
