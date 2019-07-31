import java.util.Scanner;

public class p10 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double rad = Double.parseDouble(console.nextLine());
        double deg = Math.round(rad*(180/Math.PI));

        System.out.println(deg);

    }
}
