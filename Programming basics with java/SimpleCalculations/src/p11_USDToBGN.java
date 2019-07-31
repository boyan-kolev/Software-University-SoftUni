import java.util.Scanner;

public class p11_USDToBGN {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double usd = Double.parseDouble(console.nextLine());
        double bgn = usd * 1.79549;
        System.out.printf("bgn: %.2f",bgn);
    }
}
