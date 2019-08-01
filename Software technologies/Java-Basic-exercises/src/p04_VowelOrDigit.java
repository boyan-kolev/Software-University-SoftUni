import java.util.Scanner;

public class p04_VowelOrDigit {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        char input = console.nextLine().charAt(0);
        input = Character.toLowerCase(input);

        if (Character.isDigit(input)){
            System.out.println("digit");
        }
        else if (isVowel(input)){
            System.out.println("vowel");
        }
        else {
            System.out.println("other");
        }
    }

    public static boolean isVowel(char symbol){
        switch (symbol){
            case 'a':
            case 'e':
            case 'i':
            case 'o':
            case 'u':
                return true;
        }

        return  false;
    }
}
