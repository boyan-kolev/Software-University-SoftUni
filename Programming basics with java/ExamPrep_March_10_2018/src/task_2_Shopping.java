import java.util.Scanner;

public class task_2_Shopping {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double biudjet = Double.parseDouble(console.nextLine());
        int broiShokoladi = Integer.parseInt(console.nextLine());
        double kolichestvoMlqko = Double.parseDouble(console.nextLine());

        double obshtoShokoladi = broiShokoladi * 0.65;
        double obshtoMlqko = kolichestvoMlqko * 2.70;
        double broiMandarini = Math.floor(broiShokoladi - (broiShokoladi * 0.35));
        double obshtoMandarini = broiMandarini * 0.20;
        double totalPrice = obshtoShokoladi + obshtoMlqko + obshtoMandarini;

        if (biudjet >= totalPrice){
            double ostanaliPari = biudjet - totalPrice;
            System.out.printf("You got this, %.2f money left!%n",ostanaliPari);
        }else {
            double nujniPari = totalPrice - biudjet;
            System.out.printf("Not enough money, you need %.2f more!%n",nujniPari);
        }

    }
}
