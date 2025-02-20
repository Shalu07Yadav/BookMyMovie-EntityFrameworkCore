using BookMyMovieDataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMyMovieDataAccessLayer
{
    public class BookMyMovieRepository
    {
        public BookMyMovieDbContext Context { get; set; }
        public BookMyMovieRepository()
        {
            Context = new BookMyMovieDbContext();
        }

        //read operation
        public List<User> GetAllUsers()
        {
            List<User> Users= new List<User>();
            try
            {
                Users=Context.Users.ToList();
            }
            catch (Exception ex)
            {
                Users = null;
            }

            return Users;
        }

        //get booking
        public List<Booking> GetBookings()
        {
            List<Booking> Bookings = new List<Booking>();
            try
            {
                Bookings=(from b in Context.Bookings
                          where b.SeatsBooked>=3
                          orderby b.TheaterId 
                          select b).ToList();
               
            }
            catch (Exception ex)
            {

                Bookings = null;
            }
            return Bookings;
        }

        //add movie
        public bool AddMovie(Movie movie)
        {
            bool status = false;
            try
            {
                Context.Movies.Add(movie);
                Context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {

                status = false;
            }
            return status;
        }

        //add theater
        public bool AddTheatre(Theater theater)
        {
            bool status = false;
            try
            {
               Context.Theaters.Add(theater);
                Context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {

                status = false;
            }
            return status;
        }

        //update user details
        public int UpdateUserDetails(User user)
        {

            int status = 0;
            try
            {
              Context.Users.Add(user);
                Context.SaveChanges();
                status = 1;
            }
            catch (Exception ex)
            {

                status = -99;
            }

            return status;
        }

        //cancel
        public int CancelBooking(int bookingId)
        {
            int status = 0;
            Booking booking= Context.Bookings.Find(bookingId);
            if (booking == null)
            {
                return -1;
            }
            try
            {
                Context.Bookings.Remove(booking);
                Context.SaveChanges();
                status = 1;
            }
            catch (Exception ex)
            {

                status = -99;
            }
            return status;
        }

        //7th 
        public bool DeleteUser(int userId)
        {
            User user = Context.Users.Find(userId);
            var temp = AlreadyBooking(userId);

            bool status= false;
            try
            {
                
                Context.Users.Remove(user);
                Context.SaveChanges();
                status = true;
                
            }
            catch (Exception ex)
            {

                status = false;
            }
            return status;
        }

        public int AlreadyBooking(int userId)
        {

            var m = Context.Bookings.Where(u => u.UserId == userId).Select(u => u).First();
            try
            {
                if (m != null)
                {
                    return 0;
                }
                return 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eception message is: {ex.Message}");
                return -99;
            }
        }

    }
}
