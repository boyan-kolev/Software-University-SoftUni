import java.util.Scanner;

public class march_26_2016 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        for (int i = 0; i <= 9; i++) {
            for (int j = 0; j <= 9; j++) {
                for (int k = 0; k <= 9; k++) {
                    for (int l = 0; l <= 9; l++) {
                        for (int m = 0; m < 9; m++) {
                            for (int o = 0; o <= 9; o++) {
                                if (i * j * k * l * m * o == n){
                                    System.out.printf("%d%d%d%d%d%d ",i, j, k, l, m, o);
                                }
                            }
                        }
                    }
                }
            }

        }

    }
}
