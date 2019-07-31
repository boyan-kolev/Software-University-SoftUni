import java.time.LocalDate;
        import java.time.format.DateTimeFormatter;
        import java.util.Scanner;

public class p13 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        String birthDay = console.nextLine();
        DateTimeFormatter format = DateTimeFormatter.ofPattern("dd-MM-yyyy");
        LocalDate localDate = LocalDate.parse(birthDay,format);
        LocalDate result = localDate.plusDays(999);

        System.out.println(format.format(result));
    }
}
