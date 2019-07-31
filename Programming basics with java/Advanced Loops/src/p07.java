import java.util.Scanner;

public class p07 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int a = Integer.parseInt(console.nextLine());
        int b = Integer.parseInt(console.nextLine());

        while (true){
            int nextNum = a % b;
            if (nextNum == 0){
                System.out.println(b);
                return;
            }
            a = b ;
            b = nextNum;

        }
    }
}
