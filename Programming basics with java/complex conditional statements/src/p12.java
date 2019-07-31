import java.util.Scanner;

public class p12 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String year = console.nextLine().toLowerCase();
        double p = Double.parseDouble(console.nextLine());
        int h = Integer.parseInt(console.nextLine());
        double weekendSofia = 48 - h;
        double saturdaySofia = weekendSofia * 3/4;
        double holidaySofia = p * 2/3;
        double totalGames = saturdaySofia + h + holidaySofia;
        double additionalGames = 0;

        if (year.equals("leap")){
            additionalGames = 0.15 * totalGames;
        }
        totalGames = Math.floor(totalGames + additionalGames);

        System.out.printf("%.0f",totalGames);
    }
}
