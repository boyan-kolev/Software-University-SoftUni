import java.util.Scanner;

public class p17PriceForTransport {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int distance = Integer.parseInt(console.nextLine());
        String period = console.nextLine();

        if ((distance >= 1) && (distance <= 5000)) {
            double optim = -1;
            if (distance < 20) {
                if (period.equals("day")) {
                    optim = 0.70 + distance * 0.79;
                } else if (period.equals("night")) {
                    optim = 0.70 + distance * 0.90;
                }
            }
            else if (distance < 100){
                optim = distance * 0.09;
            }else {
                optim = distance * 0.06;
            }
            System.out.println(optim);
        }

    }
}
