import java.util.Scanner;

public class December_16_2017 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n1 = Integer.parseInt(console.nextLine());
        int n2 = Integer.parseInt(console.nextLine());

        int lastN1 = n1 % 10;
        n1 = n1 / 10;
        int trirdN1 = n1 % 10;
        n1 = n1 / 10;
        int secondN1 = n1 % 10;
        int firstN1 = n1 / 10;

        int lastN2 = n2 % 10;
        n2 = n2 / 10;
        int trirdN2 = n2 % 10;
        n2 = n2 / 10;
        int secondN2 = n2 % 10;
        int firstN2 = n2 / 10;

        for (int i = firstN1; i <= firstN2; i++) {
            if (i % 2 == 0){
                continue;
            }
            for (int j = secondN1; j <= secondN2; j++) {
                if (j % 2 == 0){
                    continue;
                }
                for (int k = trirdN1; k <= trirdN2; k++) {
                    if (k % 2 == 0){
                        continue;
                    }
                    for (int l = lastN1; l <= lastN2; l++) {
                        if (l % 2 == 0){
                            continue;
                        }
                        System.out.printf("%d%d%d%d ",i, j, k, l);
                    }
                }
            }
        }
    }
}
