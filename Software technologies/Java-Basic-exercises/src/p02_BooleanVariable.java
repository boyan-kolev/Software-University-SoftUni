import java.util.Scanner;

public class p02_BooleanVariable {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String input = console.nextLine();

        Boolean bool = Boolean.valueOf(input);

        if (bool){
            System.out.println("Yes");
        }
        else {
            System.out.println("No");
        }
    }
}
