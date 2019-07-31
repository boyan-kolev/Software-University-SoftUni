import java.util.Scanner;

public class p12 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double sum = Double.parseDouble(console.nextLine());
        String inputCurrency = console.nextLine();
        String outputCurrency = console.nextLine();

        double USD = 1.79549;
        double EUR = 1.95583;
        double GBR = 2.53405;

        if(inputCurrency.equals("USD")){
            sum = sum * USD ;
        }
        else if(inputCurrency.equals("EUR")){
            sum = sum * EUR ;
        }
        else if(inputCurrency.equals("GBP")){
            sum = sum * GBR ;
        }

        if (outputCurrency.equals("USD")){
            sum = sum / USD ;
        }
        else if (outputCurrency.equals("EUR")){
            sum = sum / EUR ;
        }
        else if (outputCurrency.equals("GBP")){
            sum = sum / GBR ;
        }
        System.out.printf("%.2f %s",sum ,outputCurrency);
    }
}
