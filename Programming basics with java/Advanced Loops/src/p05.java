import java.util.Scanner;

public class p05 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int currNum = 1;
        while (currNum <= n){
            System.out.println(currNum);
            currNum = currNum * 2 + 1;
        }
    }
}
