import java.util.Scanner;

public class p06 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        
        //First part
        for (int row = 0; row < n; row++) {
            System.out.print(repeatStr(n - 1 - row, " "));
            System.out.println(repeatStr(row + 1, "* "));
        }
        //Last part 
            for (int row = 0; row < n -1; row++) {
                System.out.print(repeatStr(row +1, " "));
                System.out.println(repeatStr(n -1 -row, "* "));
            }    
        }
    static  String repeatStr (int count ,String text){
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) {
            sb.append(text);
        }
        return sb.toString();
    }
}
