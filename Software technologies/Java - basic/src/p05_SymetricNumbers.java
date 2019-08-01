import java.util.Scanner;

public class p05_SymetricNumbers {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int num = Integer.parseInt(console.nextLine());

        for (int i = 1; i <= num; i++) {
            String numAsStr = Integer.toString(i);
            String revNum = new StringBuffer(numAsStr).reverse().toString();
            if (numAsStr.equals(revNum)){
                System.out.print(numAsStr + " ");
            }
        }
        System.out.println();
    }
}
