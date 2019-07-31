import java.util.Scanner;

public class task_5_Sword {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        String firstRow = repeatStr(((2 * n) - 2) / 2, "#")
                + "/^\\" + repeatStr(((2 * n) - 2) / 2, "#");
        System.out.println(firstRow);
        for (int row = 0; row < n / 2; row++) {
            String firstPart = repeatStr(((2 * n) - 4) / 2 - row ,"#")
                    + "." + repeatStr(3 + 2 * row ," ")
                    + "." + repeatStr(((2 * n) - 4) / 2 - row ,"#");
            System.out.println(firstPart);
        }

        String tab = repeatStr(n / 2 ," ");
        String diez = repeatStr((((2 * n) + 1) - (3 + ((n / 2) * 2))) / 2 ,"#");
        repeatStr((((2 * n) + 1) - (3 + ((n / 2) * 2))) / 2 ," ");
        char cherta = '|';
        String S = diez + cherta + tab + "S" + tab + cherta + diez;
        System.out.println(S);
        String O = diez + cherta + tab + "O" + tab + cherta + diez;
        System.out.println(O);
        String F = diez + cherta + tab + "F" + tab + cherta + diez;
        System.out.println(F);
        String T = diez + cherta + tab + "T" + tab + cherta + diez;
        System.out.println(T);

        for (int row = 0; row < n - 4; row++) {
            String spaces = diez + cherta + repeatStr((n / 2) * 2 + 1 , " ")
                    + cherta + diez;
            System.out.println(spaces);
        }

        if (n == 4){
            System.out.println("#|     |#");
        }

        String U = diez + cherta + tab + "U" + tab + cherta + diez;
        System.out.println(U);
        String N = diez + cherta + tab + "N" + tab + cherta + diez;
        System.out.println(N);
        String I = diez + cherta + tab + "I" + tab + cherta + diez;
        System.out.println(I);

        String kliomba = "@" + repeatStr(((2 * n) + 1) - 2 ,"=" ) + "@";
        System.out.println(kliomba);

        for (int row = 0; row < n / 2; row++) {
            String lastPart = repeatStr((n + 3) / 2 , "#")
                    + "|" + repeatStr(((2 * n) + 1 ) - ((n + 3) / 2) * 2 - 2 ," ")
                    + "|" + repeatStr((n + 3) / 2 , "#");
            System.out.println(lastPart);
        }

        String lastRow = repeatStr((n + 3) / 2 , "#")
                + "\\" + repeatStr(((2 * n) + 1 ) - ((n + 3) / 2) * 2 - 2 ,".")
                + "/" + repeatStr((n + 3) / 2 , "#");
        System.out.println(lastRow);

    }
    static String repeatStr (int count ,String text){
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) {
            sb.append(text);
        }
        return sb.toString();
    }
}
