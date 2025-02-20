using BookMyMovieDataAccessLayer;
using BookMyMovieDataAccessLayer.Models;

namespace BookMyMovieConsoleApp
{
    internal class Program
    {

        public static BookMyMovieRepository Repository { get; set; }
        static Program()
        {
            Repository = new BookMyMovieRepository();
        }
        static void Main(string[] args)
        {
            //TestGetAllUsers();
            //TestGetBookings();
            //TestAddMovie();
            //TestAddTheatre();
            //TestUpdateUserDetails();
            //TestCancelBooking();
           // TestDeleteUser();

        }

        public static void TestGetAllUsers()
        {
            List<User> users = Repository.GetAllUsers();

            if (users != null)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine("Id: " + users[i].UserId + " Name: " + users[i].FirstName + " Email: " + users[i].Email);
                }
            }
            else
            {
                Console.WriteLine("No users found or an error occurred.");
            }

        }

        public static void TestGetBookings()
        {
            List<Booking> bookings = Repository.GetBookings();
            if (bookings != null && bookings.Count > 0)
            {
                Console.WriteLine("Bookings where seats booked > 3:");
                foreach (var booking in bookings)
                {
                    Console.WriteLine("Booking ID:" + booking.BookingId + " User ID: " + booking.UserId + " Movie Id: " + booking.MovieId + "Theater Id:" + booking.TheaterId + " Seats Booked: " + booking.SeatsBooked);
                }
            }
            else
            {
                Console.WriteLine("No bookings found or an error occurred.");
            }
        }

        public static void TestAddMovie()
        {
            Movie newMovie = new Movie
            {
                Title = "Interstellar",
                Genre = "Sci-Fi",
                Duration = 169, // Duration in minutes 
                ReleaseDate = new DateOnly(2014, 11, 7)
            };

            bool isAdded = Repository.AddMovie(newMovie);
            if (isAdded)
            {
                Console.WriteLine("Movie added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add the movie.");

            }

        }

        public static void TestAddTheatre()
        {
            Theater newTheater = new Theater
            {
                Name = "Grand Cinemas",
                Location = "Los Angeles, CA",
                TotalSeats = 300
            };

            bool isAdded = Repository.AddTheatre(newTheater);

            if (isAdded)
            {
                Console.WriteLine("Theater added successfully.");
            }
            else
            {
                Console.WriteLine("Failed to add the mtheater.");

            }

        }


        public static void TestUpdateUserDetails()
        {
            User updatedUser = new User
            {
                UserId = 1, // Assuming a user with ID 1 exists
                Email = "new.email@example.com",
                ContactNumber = "9998887776"
            };

            int updateResult = Repository.UpdateUserDetails(updatedUser);
            if (updateResult == 1)
            {
                Console.WriteLine("User details updated successfully.");
            }
            else if(updateResult == -1)
            {
                Console.WriteLine("User not found.");
            }
            else
            {
                Console.WriteLine("An error occurred while updating user Details");
            }
        }

        public static void TestCancelBooking()
        {
            int bookingId = 1;
            int cancelResult = Repository.CancelBooking(bookingId);
            if (cancelResult == 1)
            {
                Console.WriteLine("Booking cancelled successfully.");
            }
            else if (cancelResult == -1)
            {
                Console.WriteLine("Booking not found.");
            }
            else
            {
                Console.WriteLine("An error occurred while canceling the Booking");
            }
        }


        public static void TestDeleteUser()
        {
            int userId = 4;
            bool deleteResult = Repository.DeleteUser(userId);
            if (deleteResult)
            {
                Console.WriteLine("User deleted successfully.");
            }
            else
            {
                Console.WriteLine("User could not be deleted either does not  exist or has associated bookings");
            }
        }
    }
}

