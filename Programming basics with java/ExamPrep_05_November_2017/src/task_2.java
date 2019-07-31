import java.util.Scanner;

public class task_2 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double quantity = Double.parseDouble(console.nextLine());
        int countOfBoxes = Integer.parseInt(console.nextLine());
        int countOfJar = Integer.parseInt(console.nextLine());
        double totalLiutenica = quantity / 5;
        double jar = totalLiutenica / 0.535;
        double boxes = jar / countOfJar;
        double tempKasetki = 0;
        double tempBurkani = 0;

        System.out.printf("Total lutenica: %.0f kilograms.%n",Math.floor(totalLiutenica));
        if (boxes > countOfBoxes){
            tempKasetki = boxes - countOfBoxes;
            tempBurkani = jar - (countOfBoxes * countOfJar);
            System.out.printf("%.0f boxes left.%n",Math.floor(tempKasetki));
            System.out.printf("%.0f jars left.%n",Math.floor(tempBurkani));

        }else if (boxes < countOfBoxes){
            tempKasetki = countOfBoxes - boxes;
            tempBurkani = (countOfBoxes * countOfJar) - jar;
            System.out.printf("%.0f more boxes needed.%n",Math.floor(tempKasetki));
            System.out.printf("%.0f more jars needed.%n",Math.floor(tempBurkani));
        }
    }
}
