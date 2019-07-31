import java.util.Scanner;

public class task_5_Butterfly {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        for (int row = 0; row < n - 2; row++) {
            String firstPart = repeatStr(row + 1,"*\\")
                    + repeatStr((4 * n) - 8 - 4 * row ," ")
                    +repeatStr(row + 1 ,"/*");
            System.out.println(firstPart);
        }
        String backslash1 = repeatStr(((4 * n) - 4) / 2, "\\/" );
        System.out.println(backslash1);

        for (int row = 0; row < n / 2; row++) {
            String middlePart = repeatStr(((4 * n) - 10) / 2 ,"<" )
                    + "*|**|*" + repeatStr(((4 * n) - 10) / 2 ,">");
            System.out.println(middlePart);
        }

        String backslash2 = repeatStr(((4 * n) - 4) / 2, "/\\" );
        System.out.println(backslash2);

        for (int row = 0; row < n - 2; row++) {
            String lastPart = repeatStr(((4 * n) - 8) / 4 - row ,"*/")
                    + repeatStr(4 + 4 * row ," ")
                    + repeatStr(((4 * n) - 8) / 4 - row ,"\\*");
            System.out.println(lastPart);
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
