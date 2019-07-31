import java.util.Scanner;

public class task_5 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        String firstAndLastRow = repeatStr(((3 * n) - 1) / 2 , ".")
                + "x" + repeatStr(((3 * n) - 1) / 2 , ".");
        System.out.println(firstAndLastRow);

        String secondRow = repeatStr(((3 * n) - 3) / 2 ,".")
                + "/x\\" + repeatStr(((3 * n) - 3) / 2 ,".");
        System.out.println(secondRow);

        String thirdRow = repeatStr(((3 * n) - 3) / 2 ,".")
                + "x|x" + repeatStr(((3 * n) - 3) / 2 ,".");
        System.out.println(thirdRow);

        for (int row = 0; row < n / 2 + 1; row++) {
            String firsMiddlePart = repeatStr((((3 * n) - (2 * n + 1)) / 2) - row, ".")
                    + repeatStr(n + row, "x") + "|" + repeatStr(n + row, "x")
                    + repeatStr((((3 * n) - (2 * n + 1)) / 2) - row, ".");
            System.out.println(firsMiddlePart);
        }

        for (int row = 0; row < n / 2; row++) {
            String secondMiddlePart = repeatStr(row + 1, ".")
                    + repeatStr((3 * n - 3) / 2 - row ,"x")
                    + "|" + repeatStr((3 * n - 3) / 2 - row ,"x")
                    + repeatStr(row + 1, ".");
            System.out.println(secondMiddlePart);
        }

        System.out.println(secondRow);
        String lastButOneRow = repeatStr(((3 * n) - 3) / 2 ,".")
                + "\\x/" + repeatStr(((3 * n) - 3) / 2 ,".");
        System.out.println(lastButOneRow);

        for (int row = 0; row < n / 2 + 1; row++) {
            String firsMiddlePart = repeatStr((((3 * n) - (2 * n + 1)) / 2) - row, ".")
                    + repeatStr(n + row, "x") + "|" + repeatStr(n + row, "x")
                    + repeatStr((((3 * n) - (2 * n + 1)) / 2) - row, ".");
            System.out.println(firsMiddlePart);
        }

        for (int row = 0; row < n / 2; row++) {
            String secondMiddlePart = repeatStr(row + 1, ".")
                    + repeatStr((3 * n - 3) / 2 - row ,"x")
                    + "|" + repeatStr((3 * n - 3) / 2 - row ,"x")
                    + repeatStr(row + 1, ".");
            System.out.println(secondMiddlePart);
        }
        System.out.println(thirdRow);
        System.out.println(lastButOneRow);
        System.out.println(firstAndLastRow);
    }
    static String repeatStr (int count ,String text){
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) {
            sb.append(text);
        }
        return sb.toString();
    }
}
