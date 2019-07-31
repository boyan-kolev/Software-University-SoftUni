import java.util.Scanner;

public class p04 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String FirstName = console.nextLine();
        String LastName = console.nextLine();
        int age = Integer.parseInt(console.nextLine());
        String town = console.nextLine();

        System.out.printf("You are %s %s, a %d-years old person from %s.",FirstName, LastName, age ,town);
    }
}
