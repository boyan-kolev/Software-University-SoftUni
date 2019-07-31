import java.util.Scanner;

public class p08 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double number = Double.parseDouble(console.nextLine());
        String inputUnit = console.nextLine();
        String outputUnit = console.nextLine();


        if (inputUnit.equals("mm")){
            number = number / 1000;
        }else if (inputUnit.equals("cm")){
            number = number / 100;
        }else if (inputUnit.equals("mi")){
            number = number / 0.000621371192;
        }else if (inputUnit.equals("in")){
            number = number / 39.3700787;
        }else if (inputUnit.equals("km")){
            number = number / 0.001;
        }else if (inputUnit.equals("ft")){
            number = number / 3.2808399;
        }else if (inputUnit.equals("yd")){
            number = number / 1.0936133;
        }

        if (outputUnit.equals("mm")){
            number = number * 1000;
        }else if (outputUnit.equals("cm")){
            number = number * 100;
        }else if (outputUnit.equals("mi")){
            number = number * 0.000621371192;
        }else if (outputUnit.equals("in")){
            number = number * 39.3700787;
        }else if (outputUnit.equals("km")){
            number = number * 0.001;
        }else if (outputUnit.equals("ft")){
            number = number * 3.2808399;
        }else if (outputUnit.equals("yd")){
            number = number * 1.0936133;
        }

        System.out.printf("%.8f %s",number, outputUnit);

    }
}
