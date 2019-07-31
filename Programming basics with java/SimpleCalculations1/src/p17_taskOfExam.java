import java.util.Scanner;

public class p17_taskOfExam {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double lengthOfHall = Double.parseDouble(console.nextLine());
        double widthOfHall = Double.parseDouble(console.nextLine());
        double sideOfWardrobe = Double.parseDouble(console.nextLine());

        double areaOfHall = (lengthOfHall * 100)*(widthOfHall * 100);
        double areaOfWardrobe = Math.pow((sideOfWardrobe*100), 2);
        double areaOfBench = areaOfHall / 10;
        double freeSpace = areaOfHall - areaOfWardrobe - areaOfBench;
        double numberOfDancers = freeSpace / (40 + 7000);

        double result = Math.floor(numberOfDancers);

        System.out.printf("%.0f",result);

    }
}
