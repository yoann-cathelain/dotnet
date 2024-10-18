using System.ComponentModel.DataAnnotations;

namespace ClientConvertisseur.Models
{
    public class Devise
    {
        #region Constructeur
        public Devise()
        {
            
        }

        public Devise(int id, string name, double taux)
        {
            _id = id;
            _name = name;
            _taux = taux;
        }
        #endregion

        #region Propriétés
        private int _id;

        /// <summary>
        /// Id d'une devise
        /// </summary>
		public int Id
		{
			get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
                
            }
		}

        
        private string? _name;

        /// <summary>
        /// Nom d'une devise
        /// </summary>

        public string? Name
		{
			get { return _name
            ; }
			set {
                if (_name != value)
                {
                    _name = value;
                }
            }
		}

        private double _taux;

        /// <summary>
        /// Taux d'une devise
        /// </summary>
        public double Taux
        {
            get { return _taux; }
            set
            {
                if (_taux != value)
                {
                    _taux = value;
                }
            }
        }
        #endregion


    }
}
