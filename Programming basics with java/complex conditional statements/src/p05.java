import java.util.Scanner;

public class p05 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int number = Integer.parseInt(console.nextLine());

        boolean isItBiggerThan100 = number >= 100;
        boolean isLessThan200 = number <= 200;
        boolean isEqualsTo_0 = number == 0;

        if (!((isItBiggerThan100 && isLessThan200) || isEqualsTo_0)){
            System.out.println("invalid");
        }else {

        }
    }
}
