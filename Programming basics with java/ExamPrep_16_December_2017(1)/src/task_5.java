import java.util.Scanner;

public class task_5 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int n = Integer.parseInt(console.nextLine());
        String dash = "-";
        String star = "*";
        String twoStars = "**";
        String ampersand = "&";
        String dashAt1_LastRow = repeatStr(((5 * n) - n) / 2,dash);
        String starAt1_LastRow = repeatStr(n,star);
        System.out.printf("%s%s%s%n",dashAt1_LastRow, starAt1_LastRow, dashAt1_LastRow);

        for (int row = 0; row < n / 2; row++) {
            String dashAtFirstPart = repeatStr(((n * 2) - 2) - row - row, dash);
            String starAtFirstPart = repeatStr(row + 1 ,star);
            String ampersandAtFirstPart = repeatStr((n + 2) + row + row ,ampersand);
            System.out.printf("%s%s%s%s%s%n",dashAtFirstPart, starAtFirstPart, ampersandAtFirstPart,
                    starAtFirstPart, dashAtFirstPart);

        }
        for (int row = 0; row < n / 2; row++) {
            String dashAtSecondPart = repeatStr(n - 1 - row ,dash);
            String weavyFeature = repeatStr((3 * n) - 2 + 2 * row,"~");
            System.out.printf("%s%s%s%s%s%n",dashAtSecondPart, twoStars, weavyFeature, twoStars, dashAtSecondPart);
        }

        String middlePart = repeatStr(n / 2,dash) + star + repeatStr(4 * n - 2 ,"|")
                + star + repeatStr(n / 2,dash);
        System.out.println(middlePart);

        for (int row = 0; row < n / 2; row++) {
            String thirdPart = repeatStr(n / 2 + row , dash) + twoStars
                    + repeatStr(n * 4 - 4 - 2 * row, "~")
                    + twoStars + repeatStr(n / 2 + row , dash);
            System.out.println(thirdPart);
        }
        for (int row = 0; row < n / 2; row++) {
            String lastPart = repeatStr(n + 2 * row, dash)
                    + repeatStr(n / 2 -row ,star)
                    +repeatStr(2 * n - 2 * row, ampersand)
                    + repeatStr(n / 2 -row ,star)
                    + repeatStr(n + 2 * row, dash);
            System.out.println(lastPart);
        }
        System.out.printf("%s%s%s%n",dashAt1_LastRow, starAt1_LastRow, dashAt1_LastRow);
    }
    static String repeatStr (int count ,String text){
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < count; i++) {
            sb.append(text);
        }
        return sb.toString();
    }
}
