import java.util.Scanner;

public class p08_MetricConverter {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        double distance = Double.parseDouble(scanner.nextLine());
        String inputUnit = scanner.nextLine();
        String outputUnit = scanner.nextLine();

        double milimeters = 1000;
        double centimeters = 100;
        double miles = 0.000621371192;
        double inches = 39.3700787;
        double kilometers = 0.001;
        double feet = 3.2808399;
        double yards = 1.0936133;

        if (inputUnit.equals("mm")){
            distance = distance / milimeters;
        }else if (inputUnit.equals("cm")){
            distance = distance / centimeters;
        }else if (inputUnit.equals("mi")){
            distance = distance / miles;
        }else  if (inputUnit.equals("in")){
            distance = distance / inches;
        }else if (inputUnit.equals("km")){
            distance = distance / kilometers;
        }else if (inputUnit.equals("ft")){
            distance = distance / feet;
        }else if (inputUnit.equals("yd")){
            distance =  distance / yards;
        }


        if (outputUnit.equals("mm")){
            distance = distance * milimeters;
        }else if (outputUnit.equals("cm")){
            distance = distance * centimeters;
        }else if (outputUnit.equals("mi")){
            distance = distance * miles;
        }else  if (outputUnit.equals("in")){
            distance = distance * inches;
        }else if (outputUnit.equals("km")){
            distance = distance * kilometers;
        }else if (outputUnit.equals("ft")){
            distance = distance * feet;
        }else if (outputUnit.equals("yd")){
            distance =  distance * yards;
        }

        System.out.printf("%.8f %s",distance , outputUnit);
    }
}
