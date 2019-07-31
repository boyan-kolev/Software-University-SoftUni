public class p02 {
    public static void main(String[] args) {
        for (int i = 1; i < 1000; i++) {
            switch (i %10){
                case 7:
                    System.out.println(i);
                    break;
            }
        }
    }
}
