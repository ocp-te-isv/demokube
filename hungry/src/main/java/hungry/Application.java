package hungry;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@SpringBootApplication
@RestController
public class Application {

    @RequestMapping("/")
    public String home() {
        int numThreads = 4;
        double load = 0.9;
        long duration = 5000;
        BusyThread[] threads = new BusyThread[numThreads];

        for (int thread = 0; thread < numThreads; thread++) {
            threads[thread] = new BusyThread("Thread" + thread, load, duration);
            threads[thread].start();
        }
        for (int thread = 0; thread < numThreads; thread++) {
            try {
                 threads[thread].join();
                break;
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        return "Om nom nom 🌯";
    }

    @RequestMapping("/health")
    public String health() {
        return "";
    }

    public static void main(String[] args) {
        SpringApplication.run(Application.class, args);
    }

}