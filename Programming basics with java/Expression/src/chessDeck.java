import java.util.Scanner;

public class chessDeck {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        System.out.print("Enter nimber: ");
        int n = Integer.parseInt(console.nextLine());

        for (int i = 0; i < n; i++) {
            System.out.print("-");
        }
        System.out.println();

        for (int i = 0; i < n - 2; i++) {
            if (i % 2 == 0) {
                for (int j = 0; j < n; j++) {
                    if (j == 0 || j == n - 1) {
                        System.out.print("|");
                    } else {
                        if (j % 2 == 0) {
                            System.out.print("*");
                        } else {
                            System.out.print(" ");
                        }
                    }
                }


            } else {
                for (int j = 0; j < n; j++) {
                    if (j == 0 || j == n - 1) {
                        System.out.print("|");
                    } else {
                        if (j % 2 == 0) {
                            System.out.print(" ");
                        } else {
                            System.out.print("*");
                        }
                    }

                }
            }
            System.out.println();
        }

        for (int i = 0; i < n; i++) {
            System.out.print("-");

        }
    }
}