import java.util.Scanner;

public class p13 {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int h = Integer.parseInt(console.nextLine());
        int x = Integer.parseInt(console.nextLine());
        int y = Integer.parseInt(console.nextLine());

        boolean isItInside1 = (x > 0 && x < 3*h && y > 0 && y < h);
        boolean isItInside2 = (x > h && x < 2*h && y > 0 && y < 4*h);

        boolean isOnLeftOrRight1 = ((x == 0 || x == 3*h) && (y >= 0 && y <= h));
        boolean isOnBottomBorder1 = (y == 0 && x >= 0 && x <=3*h);
        boolean isOnTopBorder1 = (y == h && ((x >= 0 && x <= h)||(x >= 2*h && x <= 3*h)));
        boolean isOnLeftOrRight2 = ((x == h || x == 2*h)&&(y >= h && y <= 4*h));
        boolean isOnTopBorder2 = (y == 4*h && (x >= h && x <= 2*h));

        boolean isOnAnyBorder = isOnLeftOrRight1 || isOnBottomBorder1
                || isOnTopBorder1 || isOnLeftOrRight2 || isOnTopBorder2;

        if (isItInside1 || isItInside2){
            System.out.println("inside");
        }else if (isOnAnyBorder){
            System.out.println("border");
        }else {
            System.out.println("outside");
        }


    }
}
