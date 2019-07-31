import java.util.Scanner;

public class p07 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());

        //First row
        System.out.print(repeatStr(n, " "));
        System.out.println(" |");


        for (int row = 0; row < n; row++) {
            //Left side
            System.out.print(repeatStr(n -1 -row, " "));
            System.out.print(repeatStr(row +1 ,"*" ));

            //Middlle part
            System.out.print(" | ");

            //Right side
            System.out.println(repeatStr(row +1 ,"*"));
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
