import java.util.Scanner;

public class p06_CompareCharArrays {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String[] letters1 = console.nextLine().toLowerCase().split(" ");
        String[] letters2 = console.nextLine().toLowerCase().split(" ");

        int minLength = Math.min(letters1.length, letters2.length);

        for (int i = 0; i < minLength - 1; i++) {
            char letter1 = letters1[i].charAt(0);
            char letter2 = letters2[i].charAt(0);

            if (letter1 < letter2){
                System.out.println(String.join("", letters1));
                System.out.println(String.join("", letters2));
                return;
            }
            else if (letter2 < letter1){
                System.out.println(String.join("", letters2));
                System.out.println(String.join("", letters1));
                return;
            }

        }

        if (letters1.length == minLength){
            System.out.println(String.join("", letters1));
            System.out.println(String.join("", letters2));

        }
        else {
            System.out.println(String.join("", letters2));
            System.out.println(String.join("", letters1));

        }


    }
}
