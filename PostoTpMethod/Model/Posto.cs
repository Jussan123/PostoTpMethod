/* Método Model Posto
*  Classe responsável por realizar a conexão com o banco de dados e executar os métodos de CRUD
*  Autor: Jussan Igor da Silva
*  Última atualização: 29/05/2023
*/
//Posto (postoId, nome, CNPJ, email)
using Banco;

namespace Model
{
    public class Posto
    {
        public int postoId { get; set; }
        public string nome { get; set; }
        public string CNPJ { get; set; }
        public string email { get; set; }

        public Posto()
        {
        }

        public Posto(string nome, string CNPJ, string email)
        {
            this.nome = nome;
            this.CNPJ = CNPJ;
            this.email = email;

            DataBase db = new DataBase();
            db.Postos.Add(this);
            db.SaveChanges();
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj == this) 
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            Posto posto = (Posto)obj;
            return this.postoId == posto.postoId;
        }

        public override int GetHashCode()
        {
            return this.postoId.GetHashCode();
        }

        public override string ToString()
        {
            return "Posto: " + this.nome + " - CNPJ: " + this.CNPJ + " - Email: " + this.email;
        }

        //----------------------------Métodos CRUD----------------------------

        //Método para Listar todos os Postos
        public static List<Posto> Listar()
        {
            DataBase db = new DataBase();
            return db.Postos.ToList();
        }

        //Método para Buscar um Posto pelo ID
        public static Posto Buscar(int id)
        {
            DataBase db = new DataBase();
            return db.Postos.Find(id);
        }

        // Método para Atualizar um Posto
        public static Posto UpdatePosto(int postoId, string nome, string CNPJ, string email)
        {
            DataBase db = new DataBase();
            Posto posto = db.Postos.Find(postoId);
            posto.nome = nome;
            posto.CNPJ = CNPJ;
            posto.email = email;
            db.SaveChanges();
            return posto;
        }

        // Método para Deletar um Posto
        public static void DeletePosto(int postoId)
        {
            DataBase db = new DataBase();
            Posto posto = db.Postos.Find(postoId);
            db.Postos.Remove(posto);
            db.SaveChanges();
        }

    }
}