import java.util.Scanner;

public class task_6 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int m = Integer.parseInt(console.nextLine());
        int count = 0;
        String number ="";
        for (int i = 1; i <= 9; i++) {
            for (int j = 1; j <= 9; j++) {
                for (int k = 1; k <= 9; k++) {
                    for (int l = 1; l <= 9; l++) {
                        if (i * j + k * l == m) {
                            if (i < j && k > l) {
                                System.out.print(i + "" + j + "" + k + "" + l + " ");
                                count++;
                                if (count == 4) {
                                    number = (i + "" + j + "" + k + "" + l);
                                }
                            }
                        }
                    }
                }
            }
        }
        System.out.println();
        if (count >= 4){
        System.out.println("Password: " + number);
        }else System.out.println("No!");
    }
}
