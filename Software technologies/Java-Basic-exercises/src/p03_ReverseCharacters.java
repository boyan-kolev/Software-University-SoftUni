import java.util.Scanner;

public class p03_ReverseCharacters {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        char letter1 = console.next().charAt(0);
        char letter2 = console.next().charAt(0);
        char letter3 = console.next().charAt(0);

        String splitLetter = Character.toString(letter3);
        splitLetter += Character.toString(letter2);
        splitLetter += Character.toString(letter1);

        System.out.println(splitLetter);

    }
}
