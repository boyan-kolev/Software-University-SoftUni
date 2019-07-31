import java.util.Scanner;

public class march_6_2016 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int l = Integer.parseInt(console.nextLine());
        for (int i = 1; i < n; i++) {
            for (int j = 1; j < n; j++) {
                for (char letter1 = 'a'; letter1 < l + 'a'; letter1++) {
                    for (char letter2 = 'a'; letter2 < l + 'a'; letter2++) {
                        for (int k = Math.max(i,j)+ 1; k <= n; k++) {
                            System.out.print(i);
                            System.out.print(j);
                            System.out.print(letter1);
                            System.out.print(letter2);
                            System.out.print(k + " ");
                        }
                    }
                }
                
            }
        }
    }
}
