import java.util.Scanner;

public class task_1_Sandbox {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        double width = Double.parseDouble(console.nextLine());
        double length = Double.parseDouble(console.nextLine());
        double pricePerSand = Double.parseDouble(console.nextLine());
        double pricePerBoard = Double.parseDouble(console.nextLine());

        double totalArea = width * length;
        double sandstone = (width - (0.2 + 0.2)) * (length - (0.2 + 0.2));
        double areaOfCurbs = totalArea - sandstone;
        double requiredQuantityOfSand = Math.ceil(sandstone * 20);
        double requiredBoards = Math.ceil(areaOfCurbs / (2.2 * 0.2));
        double priceOfSnad = requiredQuantityOfSand * pricePerSand;
        double priceOfBoards = requiredBoards * pricePerBoard;
        double sum = priceOfSnad + priceOfBoards;
        System.out.printf("%.2f%n",sum);

    }
}
