using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace hotelmvc.Models
{
    public static class DB
    {
        public static Utente GetUtentebyusername(string username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from utente where Username = @username", conn);
            cmd.Parameters.AddWithValue("username", username);
            SqlDataReader sqlDataReader;

            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            Utente user = new Utente();
            while (sqlDataReader.Read())
            {
                user.IDutente = Convert.ToInt32(sqlDataReader["IDutente"]);
                user.username = sqlDataReader["username"].ToString();
                user.password = sqlDataReader["password"].ToString();
                user.role = sqlDataReader["role"].ToString();
            }

            conn.Close();
            return user;
        }

        public static void Creacliente(string CF, string cognome, string nome, string citta, string provincia, string email, string cellulare, string telefono)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO cliente ( CF,cognome,nome,citta,provincia,email,cellulare,telefono) VALUES(@CF,@cognome,@nome,@citta,@provincia,@email,@cellulare,@telefono)";
                cmd.Parameters.AddWithValue("CF", CF);
                cmd.Parameters.AddWithValue("cognome", cognome);
                cmd.Parameters.AddWithValue("nome", nome);
                cmd.Parameters.AddWithValue("citta", citta);
                cmd.Parameters.AddWithValue("provincia", provincia);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("cellulare", cellulare);
                cmd.Parameters.AddWithValue("telefono", telefono);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }

        public static List<Cliente> getclienti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM cliente ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Cliente> cliente = new List<Cliente>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Cliente c = new Cliente();
                c.IDcliente = Convert.ToInt32(sqlDataReader["IDcliente"]);
                c.CF = sqlDataReader["CF"].ToString();
                c.cognome = sqlDataReader["cognome"].ToString();
                c.nome = sqlDataReader["nome"].ToString();
                c.citta = sqlDataReader["citta"].ToString();
                c.provincia = sqlDataReader["provincia"].ToString();
                c.email = sqlDataReader["email"].ToString();
                c.cellulare = sqlDataReader["cellulare"].ToString();
                c.telefono = sqlDataReader["telefono"].ToString();

                cliente.Add(c);
            }

            conn.Close();
            return cliente;
        }
        public static Cliente getclienteId(int IDcliente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from cliente where IDcliente = @IDcliente", conn);
            cmd.Parameters.AddWithValue("IDcliente", IDcliente);
            SqlDataReader sqlDataReader;

            conn.Open();

            Cliente c = new Cliente();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                c.IDcliente = Convert.ToInt32(sqlDataReader["IDcliente"]);
                c.CF = sqlDataReader["CF"].ToString();
                c.cognome = sqlDataReader["cognome"].ToString();
                c.nome = sqlDataReader["nome"].ToString();
                c.citta = sqlDataReader["citta"].ToString();
                c.provincia = sqlDataReader["provincia"].ToString();
                c.email = sqlDataReader["email"].ToString();
                c.cellulare = sqlDataReader["cellulare"].ToString();
                c.telefono = sqlDataReader["telefono"].ToString();

            }

            conn.Close();
            return c;
        }
        public static void modificaCliente(int IDcliente, string CF, string cognome, string nome, string citta, string provincia, string email, string cellulare, string telefono)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE cliente SET CF=@CF,cognome=@cognome,nome=@nome,citta=@citta,provincia=@provincia,email=@email,cellullare=@cellulare,telefono=@telefono WHERE IDcliente = @IDcliente";
                cmd.Parameters.AddWithValue("IDcliente", IDcliente);
                cmd.Parameters.AddWithValue("CF", CF);
                cmd.Parameters.AddWithValue("cognome", cognome);
                cmd.Parameters.AddWithValue("nome", nome);
                cmd.Parameters.AddWithValue("citta", citta);
                cmd.Parameters.AddWithValue("provincia", provincia);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("cellulare", cellulare);
                cmd.Parameters.AddWithValue("telefono", telefono);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public static void Remuovicliente(int IDcliente)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM cliente where IDcliente=@IDcliente";
            cmd.Parameters.AddWithValue("IDcliente", IDcliente);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
        public static void Creacamera(string descrizione, bool singola, bool doppia)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO camera ( descrizione,singola,doppia) VALUES(@descrizione,@singola,@doppia)";
                cmd.Parameters.AddWithValue("descrizione", descrizione);
                cmd.Parameters.AddWithValue("singola", singola);
                cmd.Parameters.AddWithValue("doppia", doppia);

                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }
        }
        public static List<Camera> getcamere()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM camera ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Camera> camera = new List<Camera>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Camera c = new Camera();
                c.IDcamera = Convert.ToInt32(sqlDataReader["IDcamera"]);
                c.descrizione = sqlDataReader["descrizione"].ToString();
                c.singola = Convert.ToBoolean(sqlDataReader["singola"].ToString());
                c.doppia = Convert.ToBoolean(sqlDataReader["doppia"].ToString());


                camera.Add(c);
            }

            conn.Close();
            return camera;
        }
        public static Camera getcameraId(int IDcamera)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from camera where IDcamera = @IDcamera", conn);
            cmd.Parameters.AddWithValue("IDcamera", IDcamera);
            SqlDataReader sqlDataReader;

            conn.Open();

            Camera c = new Camera();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                c.IDcamera = Convert.ToInt32(sqlDataReader["IDcamera"]);
                c.descrizione = sqlDataReader["descrizione"].ToString();
                c.singola = Convert.ToBoolean(sqlDataReader["singola"].ToString());
                c.doppia = Convert.ToBoolean(sqlDataReader["doppia"].ToString());
            }

            conn.Close();
            return c;
        }

        public static void modificaCamera(int IDcamera, string descrizione, bool singola, bool doppia)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE camera SET descrizione=@descrizione,singola=@singola,doppia=@doppia WHERE IDcamera = @IDcamera";
                cmd.Parameters.AddWithValue("IDcamera", IDcamera);
                cmd.Parameters.AddWithValue("descrizione", descrizione);
                cmd.Parameters.AddWithValue("singola", singola);
                cmd.Parameters.AddWithValue("doppia", doppia);
                int IsOk = cmd.ExecuteNonQuery();


            }

            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

        public static void Remuovicamera(int IDcamera)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM camera where IDcamera=@IDcamera";
            cmd.Parameters.AddWithValue("IDcamera", IDcamera);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public static void CreaPrenotazione(DateTime dataprenotazione, string annoprenotazione, DateTime iniziosoggiorno, DateTime finesoggiorno, double caparra, double tariffa, bool mezzapensione, bool pensione, bool colazioneinclusa, int IDcliente, int IDcamera)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO prenotazione (dataprenotazione,annoprenotazione,iniziosoggiorno,finesoggiorno,caparra, tariffa,mezzapensione,pensione,colazioneinclusa,IDcliente,IDcamera ) VALUES(@dataprenotazione,@annoprenotazione,@iniziosoggiorno,@finesoggiorno,@caparra, @tariffa,@mezzapensione,@pensione,@colazioneinclusa,@IDcliente,@IDcamera )";
                cmd.Parameters.AddWithValue("dataprenotazione", dataprenotazione);
                cmd.Parameters.AddWithValue("annoprenotazione", annoprenotazione);
                cmd.Parameters.AddWithValue("iniziosoggiorno", iniziosoggiorno);
                cmd.Parameters.AddWithValue("finesoggiorno", finesoggiorno);
                cmd.Parameters.AddWithValue("caparra", caparra);
                cmd.Parameters.AddWithValue("tariffa", tariffa);
                cmd.Parameters.AddWithValue("mezzapensione", mezzapensione);
                cmd.Parameters.AddWithValue("pensione", pensione);
                cmd.Parameters.AddWithValue("colazioneinclusa", colazioneinclusa);
                cmd.Parameters.AddWithValue("IDcliente", IDcliente);
                cmd.Parameters.AddWithValue("IDcamera", IDcamera);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }


        }

        public static List<Prenotazione> getprenotazioni()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM prenotazione ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Prenotazione> prenotazione = new List<Prenotazione>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Prenotazione c = new Prenotazione();
                c.IDprenotazione = Convert.ToInt32(sqlDataReader["IDprenotazione"]);
                c.dataprenotazione = Convert.ToDateTime(sqlDataReader["dataprenotazione"]);
                c.annoprenotazione = sqlDataReader["annoprenotazione"].ToString();
                c.iniziosoggiorno = Convert.ToDateTime(sqlDataReader["iniziosoggiorno"]);
                c.finesoggiorno = Convert.ToDateTime(sqlDataReader["finesoggiorno"]);
                c.caparra = Convert.ToDouble(sqlDataReader["caparra"]);
                c.tariffa = Convert.ToDouble(sqlDataReader["tariffa"]);
                c.mezzapensione = Convert.ToBoolean(sqlDataReader["mezzapensione"].ToString());
                c.pensione = Convert.ToBoolean(sqlDataReader["pensione"].ToString());
                c.colazioneinclusa = Convert.ToBoolean(sqlDataReader["colazioneinclusa"].ToString());
                c.IDcliente = Convert.ToInt32(sqlDataReader["IDcliente"]);
                c.IDcamera = Convert.ToInt32(sqlDataReader["IDcamera"]);
                prenotazione.Add(c);
            }

            conn.Close();
            return prenotazione;
        }

        public static Prenotazione getprenotazioneId(int ID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("select * from prenotazione where IDprenotazione = @ID", conn);
            cmd.Parameters.AddWithValue("ID", ID);
            SqlDataReader sqlDataReader;

            conn.Open();

            Prenotazione c = new Prenotazione();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                c.IDprenotazione = Convert.ToInt32(sqlDataReader["IDprenotazione"]);
                c.dataprenotazione = Convert.ToDateTime(sqlDataReader["dataprenotazione"]);
                c.annoprenotazione = sqlDataReader["annoprenotazione"].ToString();
                c.iniziosoggiorno = Convert.ToDateTime(sqlDataReader["iniziosoggiorno"]);
                c.finesoggiorno = Convert.ToDateTime(sqlDataReader["finesoggiorno"]);
                c.caparra = Convert.ToDouble(sqlDataReader["caparra"]);
                c.tariffa = Convert.ToDouble(sqlDataReader["tariffa"]);
                c.mezzapensione = Convert.ToBoolean(sqlDataReader["mezzapensione"].ToString());
                c.pensione = Convert.ToBoolean(sqlDataReader["pensione"].ToString());
                c.colazioneinclusa = Convert.ToBoolean(sqlDataReader["colazioneinclusa"].ToString());
                c.IDcliente = Convert.ToInt32(sqlDataReader["IDcliente"]);
                c.IDcamera = Convert.ToInt32(sqlDataReader["IDcamera"]);
            }

            conn.Close();
            return c;
        }

        public static void modificaPrenotazione(int IDprenotazione, DateTime dataprenotazione, string annoprenotazione, DateTime iniziosoggiorno, DateTime finesoggiorno, double caparra, double tariffa, bool mezzapensione, bool pensione, bool colazioneinclusa, int IDcliente, int IDcamera)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE prenotazione SET dataprenotazione=@dataprenotazione,iniziosoggiorno=@iniziosoggiorno,finesoggiorno=@finesoggiorno,caparra=@caparra,tariffa=@tariffa,mezzapensione=@mezzapensione,pensione=@pensione,colazioneinclusa=@colazioneinclusa,IDcliente=@IDcliente,IDcamera=@IDcamera WHERE IDprenotazione = @IDprenotazione";
                cmd.Parameters.AddWithValue("IDprenotazione", IDprenotazione);
                cmd.Parameters.AddWithValue("dataprenotazione", dataprenotazione);
                cmd.Parameters.AddWithValue("annoprenotazione", annoprenotazione);
                cmd.Parameters.AddWithValue("iniziosoggiorno", iniziosoggiorno);
                cmd.Parameters.AddWithValue("finesoggiorno", finesoggiorno);
                cmd.Parameters.AddWithValue("caparra", caparra);
                cmd.Parameters.AddWithValue("tariffa", tariffa);
                cmd.Parameters.AddWithValue("mezzapensione", mezzapensione);
                cmd.Parameters.AddWithValue("pensione", pensione);
                cmd.Parameters.AddWithValue("colazioneinclusa", colazioneinclusa);
                cmd.Parameters.AddWithValue("IDcliente", IDcliente);
                cmd.Parameters.AddWithValue("IDcamera", IDcamera);
                int IsOk = cmd.ExecuteNonQuery();


            }

            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }
        public static void Creaservizio(DateTime data, string descrizione, int quantita, double prezzo, int IDprenotazione)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO servizio ( data,descrizione,quantita,prezzo,IDprenotazione) VALUES(@data,@descrizione,@quantita,@prezzo,@IDprenotazione)";
                cmd.Parameters.AddWithValue("data", data);
                cmd.Parameters.AddWithValue("descrizione", descrizione);
                cmd.Parameters.AddWithValue("quantita", quantita);
                cmd.Parameters.AddWithValue("prezzo", prezzo);
                cmd.Parameters.AddWithValue("IDprenotazione", IDprenotazione);

                int IsOk = cmd.ExecuteNonQuery();

            }

            catch { }
            finally
            {
                conn.Close();
            }

        }

        public static List<Servizi> getservizi()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SELECT * FROM servizio ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Servizi> servizio = new List<Servizi>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Servizi c = new Servizi();
                c.IDservizio = Convert.ToInt32(sqlDataReader["IDservizio"]);
                c.data= Convert.ToDateTime(sqlDataReader["data"]);
                c.descrizione = sqlDataReader["descrizione"].ToString();
                c.quantita= Convert.ToInt32(sqlDataReader["quantita"]);
                c.prezzo = Convert.ToDouble(sqlDataReader["prezzo"]);
                c.IDprenotazione = Convert.ToInt32(sqlDataReader["IDprenotazione"]);
               
                servizio.Add(c);
            }

            conn.Close();
            return servizio;
        }

      
    }
}