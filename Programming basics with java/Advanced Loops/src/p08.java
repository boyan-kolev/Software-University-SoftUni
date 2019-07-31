import java.util.Scanner;

public class p08 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int count = 1;
        int result = 1;
        while (count <= n){
            result *= count;
            count ++;
        }
        System.out.println(result);
    }
}
