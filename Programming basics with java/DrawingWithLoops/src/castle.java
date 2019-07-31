import java.util.Scanner;

public class castle {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        int middle = ((n + 1) /2)* 2 - 4;
        char slash1 = '/';
        char slash2 ='\\';
        char verticalLine = '|';
        String widthCol = repeatStr(n /2 ,"^");
        String undreScore = repeatStr(n /2 ,"_");
        String middleUnderScore = repeatStr(middle,"_");
        String gap = repeatStr((2 * n)- 2 ," ");
        String leftRightGap = repeatStr(((2 * n) - middle - 2) /2," ");
        String middleGap = repeatStr(middle," ");

        //First row
        System.out.printf("%c%s%c%s%c%s%c%n",slash1, widthCol, slash2,
                middleUnderScore, slash1, widthCol, slash2);

        //Middle part
        for (int row = 0; row < n - 3; row++) {
            System.out.printf("%c%s%c%n",verticalLine, gap, verticalLine);
        }

        //Last row - 1
        System.out.printf("%c%s%s%s%c%n", verticalLine, leftRightGap,
                middleUnderScore, leftRightGap ,verticalLine);

        //Last row
        System.out.printf("%c%s%c%s%c%s%c%n",slash2, undreScore, slash1,
                middleGap, slash2, undreScore, slash1);
    }
    static String repeatStr (int count ,String text){
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) {
            sb.append(text);
        }
        return sb.toString();
    }
}
