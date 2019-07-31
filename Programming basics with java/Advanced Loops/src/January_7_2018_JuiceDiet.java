import java.util.Scanner;

public class January_7_2018_JuiceDiet {
    public static void main(String[] args) {
        Scanner console = new Scanner(System.in);
        int r = Integer.parseInt(console.nextLine());
        int s = Integer.parseInt(console.nextLine());
        int c = Integer.parseInt(console.nextLine());
        int a = Integer.parseInt(console.nextLine());
        double maxMl = 0.0;
        double totakMl = 0.0;

        int r1 = 0;
        int s1 = 0;
        int c1 = 0;


        for (int i = 0; i <= c; i++) {
            for (int j = 0; j <= s; j++) {
                for (int k = 0; k <= r; k++) {
                    double rMl = i * 4.5;
                    double sMl = j * 7.5;
                    double cMl = k * 15;

                    totakMl = rMl + sMl + cMl;
                    if (totakMl <= a){
                        if (totakMl > maxMl) {
                            maxMl = totakMl;
                                c1 = i;
                                s1 = j;
                                r1 = k;

                        }
                    }
                }
            }

        }
        System.out.printf("%d %d %d %.0f",r1 ,s1, c1,maxMl);
    }
}