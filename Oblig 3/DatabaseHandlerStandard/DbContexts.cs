using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using DatabaseHandlerStandard.Model;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace DatabaseHandlerStandard
{
    public class BookingDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<RoomService> RoomServices { get; set; }


        public List<RoomService> GetRoomServicesForHotelRoom(HotelRoom room)
        {
            return RoomServices.ToList().Where(rs => rs.Room.Id == room.Id).ToList();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=JOAKIM-PC\OBLIG;Initial Catalog=master;Integrated Security=True");
        }

        public void DeleteRoomService(RoomService rs)
        {
            RoomServices.Remove(rs);
            SaveChanges();
        }

        public void AddRoomService(RoomService rs)
        {
            RoomServices.Add(rs);
            SaveChanges();
        }

        public List<HotelRoom> getRoomsInTimeperiod((DateTime? , DateTime?) dates)
        {

            List<HotelRoom> roomList = this.HotelRooms.ToList();
            List <Reservation> resList = this.Reservations.ToList();

            //Removes rooms that are already reserved in the time period chosen
            foreach (Reservation res in resList)
            {
                if ((dates.Item1 >= res.startDate && dates.Item1 <= res.endDate) || (dates.Item2 >= res.startDate && dates.Item2 <= res.endDate))
                {
                    int id = res.HotelRoomId;
                    roomList.RemoveAll((x) => x.Id == id);
                }
            }

            return roomList;
        }

        public void DeleteReservation(int id)
        {
            List<Reservation> resList = Reservations.ToList();
            Reservation toDelete = resList.Find(x => id == x.Id);
            Reservations.Remove(toDelete);
            this.SaveChanges();
        }
        public Reservation findReservation(int id)
        {
            return Reservations.ToList().Find(x => id == x.Id);
        }

        public HotelRoom findHotelRoom(int id)
        {
            return HotelRooms.ToList().Find(x => id == x.Id);
        }

        public void replaceReservation(Reservation reservation)
        {
            Reservation toDelete = findReservation(reservation.Id);
            DeleteReservation(toDelete.Id);
            Reservations.Add(reservation);
            this.SaveChanges();
            
        }

        public void AddReservation(int hotelRoomId, int sessionUserId, (DateTime?, DateTime?) dates)
        {

            List<User> userList = this.Users.ToList();
            List<HotelRoom> hrList = this.HotelRooms.ToList();
            DbSet<Reservation> resSet = this.Reservations;
            

            //Find hotelroom chosen
            HotelRoom hotelRoom = hrList.Find(x => x.Id == hotelRoomId);

            //Find user
            User user = userList.Find(x => x.Id == sessionUserId);


            //Creates the reservation
            Reservation reservation = new Reservation()
            {
                startDate = dates.Item1,
                endDate = dates.Item2,
                User = user,
                HotelRoom = hotelRoom,
                Status = "Created"
            };

            resSet.Add(reservation);
            this.SaveChanges();

        }
        public void AddUser(User rs)
        {
            Users.Add(rs);
            SaveChanges();
        }
        public void AddHotelRoom(HotelRoom rs)
        {
            HotelRooms.Add(rs);
            SaveChanges();
        }
    }
}