import java.util.Scanner;

public class p12 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double rate = Double.parseDouble(console.nextLine());

        if (rate <= 10){
            System.out.println("slow");
        }else if (rate <= 50){
            System.out.println("average");
        }else if (rate <= 150){
            System.out.println("fast");
        }else if (rate <= 1000){
            System.out.println("ultra fast");
        }else {
            System.out.println("extremely fast");
        }
    }
}
