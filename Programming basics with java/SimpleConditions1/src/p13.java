import java.util.Scanner;

public class p13 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String figure = console.nextLine();
        double a = Double.parseDouble(console.nextLine());
        double area = 0;
        if (figure.equals("square")){
            area = Math.pow(a,2);
        }else if (figure.equals("rectangle")){
            double b = Double.parseDouble(console.nextLine());
            area = a * b;
        }else if (figure.equals("circle")){
            area = Math.PI * Math.pow(a,2);
        }else if (figure.equals("triangle")){
            double h = Double.parseDouble(console.nextLine());
            area = (a * h) /2;
        }

        System.out.printf("%.3f%n",area);
    }
}
