import java.util.Scanner;

public class p10 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String animal = console.nextLine().toLowerCase();
        String animalClass ;

        switch (animal){
            case "dog":
                animalClass = "mammal";
                break;
            case "crocodile":
            case "tortoise":
            case "snake":
                animalClass = "reptile";
                break;
            default:
                animalClass = "unknown";
                break;
        }

        System.out.println(animalClass);
    }
}
