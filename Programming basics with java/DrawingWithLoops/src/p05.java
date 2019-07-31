import java.util.Scanner;

public class p05 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        //first part
        System.out.print("+ ");
        System.out.print(repeatStr(n-2 ,"- "));
        System.out.println("+");

        //Middle part
        for (int i = 0; i < n -2; i++) {
            System.out.print("| ");
            System.out.print(repeatStr(n -2, "- "));
            System.out.println("|");
        }

        //Last part
        System.out.print("+ ");
        System.out.print(repeatStr(n-2 ,"- "));
        System.out.println("+");

    }
    static String repeatStr (int count ,String text){
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) {
            sb.append(text);
        }
        return sb.toString();
    }
}
