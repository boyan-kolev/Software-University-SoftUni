import java.util.Scanner;

public class p11_EqualWords {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String s1 = sc.nextLine();
        String s2 = sc.nextLine();

        s1 = s1.toLowerCase();
        s2 = s2.toLowerCase();

        if (s1.equals(s2)){
            System.out.println("yes");
        }else {
            System.out.println("no");
        }
    }
}
