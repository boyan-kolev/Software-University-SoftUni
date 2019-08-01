import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class p01_VariableInHexFormat {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));

        String hexNum = reader.readLine();

        int number = Integer.parseInt(hexNum, 16);

        System.out.println(number);
    }
}
