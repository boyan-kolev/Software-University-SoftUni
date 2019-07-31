import java.util.Scanner;

public class task_2 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double firstTime = Double.parseDouble(console.nextLine());
        double secondTime = Double.parseDouble(console.nextLine());
        double thirdTime = Double.parseDouble(console.nextLine());
        double fishingTime = Double.parseDouble(console.nextLine());
        double totalTime = 1.0 / (1 / firstTime + 1 / secondTime + 1 / thirdTime);
        double timeWithRest = totalTime + (totalTime * 0.15);
        double timeLeft = (fishingTime - timeWithRest);

        if (timeLeft > 0){
            timeLeft = Math.floor(timeLeft);
            System.out.printf("Cleaning time: %.2f%nYes, there is a surprise - time left -> %.0f hours.%n",timeWithRest ,timeLeft);
        }else {
            timeLeft = Math.abs(timeLeft);
            timeLeft = Math.ceil(timeLeft);
            System.out.printf("Cleaning time: %.2f%nNo, there isn't a surprise - shortage of time -> %.0f hours.%n",timeWithRest ,timeLeft);
        }

    }
}
