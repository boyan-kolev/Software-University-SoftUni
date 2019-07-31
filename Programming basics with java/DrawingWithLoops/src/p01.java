import java.util.Scanner;

public class p01 {
    public static void main(String[] args){
        Scanner console = new Scanner(System.in);
        for (int i = 0; i < 10; i++) {
            System.out.println(repeatStr(10 ,"*"));
        }
    }
    static String repeatStr (int count ,String text){
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) {
            sb.append(text);
        }
        return sb.toString();
    }
}
