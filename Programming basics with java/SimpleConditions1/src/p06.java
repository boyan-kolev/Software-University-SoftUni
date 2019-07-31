import java.util.Scanner;

public class p06 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int score = Integer.parseInt(console.nextLine());
        double bonusScore = 0;

        if (score <= 100){
            bonusScore += 5;
        }else if (score <= 1000){
            bonusScore = score * 0.2;
        }else {
            bonusScore = score * 0.1;
        }

        if (score % 2 == 0){
            bonusScore += 1;
        }
        if (score % 10 == 5){
            bonusScore += 2;
        }

        double totalScore = score + bonusScore;

        System.out.println(bonusScore);
        System.out.println(totalScore);
    }
}
