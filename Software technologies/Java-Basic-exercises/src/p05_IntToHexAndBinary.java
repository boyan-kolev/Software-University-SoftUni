import java.util.Scanner;

public class p05_IntToHexAndBinary {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int decNum = Integer.parseInt(console.nextLine());

        String hexNum = Integer.toHexString(decNum).toUpperCase();
        String binaryNum = Integer.toBinaryString(decNum);

        System.out.println(hexNum);
        System.out.println(binaryNum);
    }
}
