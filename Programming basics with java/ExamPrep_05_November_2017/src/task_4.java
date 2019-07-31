import java.util.Scanner;

public class task_4 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double n = Integer.parseInt(console.nextLine());
        double poorMark = 0;
        double satisfactoryMark = 0;
        double goodMark = 0;
        double veryGoodMark = 0;
        double excellentMark = 0;
        for (int i = 0; i < n; i++) {
            double points = Double.parseDouble(console.nextLine());
            if (points < 22.5){
                poorMark++;
            }else if (points >= 22.5 && points < 40.5){
                satisfactoryMark ++;
            }else if (points >= 40.5 && points < 58.5){
                goodMark++;
            }else if (points >= 58.5 && points < 76.5){
                veryGoodMark ++;
            }else if (points >= 76.5 && points <= 100){
                excellentMark ++;
            }
        }
        poorMark = (poorMark / n) * 100;
        satisfactoryMark = (satisfactoryMark / n) * 100;
        goodMark = (goodMark / n) * 100;
        veryGoodMark = (veryGoodMark / n) * 100;
        excellentMark = (excellentMark / n) * 100;

        System.out.printf("%.2f%% poor marks%n",poorMark);
        System.out.printf("%.2f%% satisfactory marks%n",satisfactoryMark);
        System.out.printf("%.2f%% good marks%n",goodMark);
        System.out.printf("%.2f%% very good marks%n",veryGoodMark);
        System.out.printf("%.2f%% excellent marks%n",excellentMark);

    }
}
