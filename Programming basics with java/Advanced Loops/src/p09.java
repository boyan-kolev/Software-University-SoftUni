import java.util.Scanner;

public class p09 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int num = Integer.parseInt(console.nextLine());
        int lastNum ;
        int currNum = num;
        int result = 0;
        while (currNum != 0){
            lastNum = currNum % 10;
            result += lastNum;
            currNum /= 10;
        }
        System.out.println(result);
    }
}
