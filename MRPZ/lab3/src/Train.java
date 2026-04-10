import java.time.LocalTime;

public class Train {
    private String destination;
    private int trainNumber;
    private LocalTime departureTime;
    private int generalSeats;
    private int coupeSeats;
    private int platskartSeats;
    private int svSeats;

    public Train(String destination, int trainNumber, LocalTime departureTime,
            int generalSeats, int coupeSeats, int platskartSeats, int svSeats) {
        this.destination = destination;
        this.trainNumber = trainNumber;
        this.departureTime = departureTime;
        this.generalSeats = generalSeats;
        this.coupeSeats = coupeSeats;
        this.platskartSeats = platskartSeats;
        this.svSeats = svSeats;
    }

    public String getDestination() {
        return destination;
    }

    public LocalTime getDepartureTime() {
        return departureTime;
    }

    public int getGeneralSeats() {
        return generalSeats;
    }

    @Override
    public String toString() {
        return String.format("| %-15s | %-12d | %-10s | %-8d | %-5d | %-8d | %-2d |",
                destination, trainNumber, departureTime, generalSeats, coupeSeats, platskartSeats, svSeats);
    }
}
