import java.util.Scanner;

public class task_3_Retirement {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String pol = console.nextLine();
        int vuzrast = Integer.parseInt(console.nextLine());
        int trudovStaj = Integer.parseInt(console.nextLine());

        if (vuzrast < 1 || vuzrast > 10000 || trudovStaj < 1 || trudovStaj > 10000){
            System.out.println("Invalid input.");
        }
        if (pol.equalsIgnoreCase("male")){
            if (vuzrast >= 64 && trudovStaj >= 38){
                System.out.printf("Ready to retire at %d and %d years of experience!%n",vuzrast ,trudovStaj);
            }else if (vuzrast < 64 && trudovStaj >= 38){
                int razlika = 64 - vuzrast;
                System.out.printf("Worked enough, but not old enough. Years left to retirement: %d.%n",razlika);
            }else if (vuzrast >= 64 && trudovStaj < 38){
                int razlika1 = 38 - trudovStaj;
                System.out.printf("Old enough, but haven't worked enough. Work experience left to retirement: %d.%n",razlika1);
            }else {
                int razlikagodini = 64 - vuzrast;
                int razlikaTrudovStaj = 38 - trudovStaj;
                System.out.printf("Too early. Years left to retirement: %d. Work experience left to retirement: %d.%n",razlikagodini ,razlikaTrudovStaj);
            }
        }else if (pol.equalsIgnoreCase("female")){
            if (vuzrast >= 61 && trudovStaj >= 35){
                System.out.printf("Ready to retire at %d and %d years of experience!%n",vuzrast ,trudovStaj);
            }else if (vuzrast < 61 && trudovStaj >= 35){
                int razlika = 61 - vuzrast;
                System.out.printf("Worked enough, but not old enough. Years left to retirement: %d.%n",razlika);
            }else if (vuzrast >= 61 && trudovStaj < 35){
                int razlika1 = 35 - trudovStaj;
                System.out.printf("Old enough, but haven't worked enough. Work experience left to retirement: %d.%n",razlika1);
            }else {
                int razlikagodini = 61 - vuzrast;
                int razlikaTrudovStaj = 35 - trudovStaj;
                System.out.printf("Too early. Years left to retirement: %d. Work experience left to retirement: %d.%n",razlikagodini ,razlikaTrudovStaj);
            }
        }else {
            System.out.println("Invalid input.");
        }


    }
}
