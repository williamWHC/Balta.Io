using M01A22_Events.Model;

namespace M01A22_Events
{
    public class Room : ObjectResponse
    {
        private int seatsInUse = 0;
        ObjectResponse? objectResponse;

        public Room(3)
        {
            objectResponse = new ObjectResponse();
        }

        public int NumberRoom { get; set; }
        public int CapacityRoom { get; set; }
        public int Seats { get; set; }

        //Metodo
        public void ReserveSeat()
        {
            seatsInUse++;

            //Valida a capacidade de assentos.
            if (seatsInUse >= Seats)
            {
                //Evento Dispara email de comunicação.
                OnRoomSoldOut(EventArgs.Empty);
                objectResponse.Messagem = "Capacidade dos assentos atingido. ";
            }
            else
            {
                //Evento => Email de comunicação 
                objectResponse.Messagem = "Reservado com sucesso!";
            }

        }

        //Criar evento para quando a sala estiver cheia RoomSoldOut => Sala Esgotada.
        public event EventHandler RoomSoldOutEvent;

        public virtual void OnRoomSoldOut(EventArgs e)
        {
            EventHandler handler = RoomSoldOutEvent;
            handler?.Invoke(this, e);
        }

    }

}