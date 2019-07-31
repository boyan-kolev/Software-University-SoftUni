import java.util.Scanner;

public class p09 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int numberOfDay = Integer.parseInt(console.nextLine());
        String dayOfWeek ;

        switch (numberOfDay){
            case 1 :
                dayOfWeek = "Monday";
                break;
            case 2 :
                dayOfWeek = "Tuesday";
                break;
            case 3 :
                dayOfWeek = "Wednesday";
                break;
            case 4 :
                dayOfWeek = "Thursday";
                break;
            case 5 :
                dayOfWeek = "Friday";
                break;
            case 6 :
                dayOfWeek = "Saturday";
                break;
            case 7 :
                dayOfWeek = "Sunday";
                break;
            default:
                dayOfWeek = "Error";
                break;

        }
        System.out.println(dayOfWeek);
    }
}
