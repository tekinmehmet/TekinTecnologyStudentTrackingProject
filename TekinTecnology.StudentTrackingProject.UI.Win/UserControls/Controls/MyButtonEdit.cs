using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using TekinTecnology.StudentTrackingProject.UI.Win.Interfaces;

namespace TekinTecnology.StudentTrackingProject.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]//toolboxda göstermek için
    public class MyButtonEdit : ButtonEdit, IStatusBarKisaYol
    {
        public MyButtonEdit()
        {
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; }

        #region Events

        private long? _id;
        [Browsable(false)]//properties de göstermemek için
        public long? Id
        {
            get => _id; //=> return anlamına gelir süslü paranteze gerek kalmaz
            set
            {
                var oldValue = _id;
                var newValue = value;

                if (newValue == oldValue) return;

                _id = value;
                //if(IdCahanged!=null)
                IdCahanged(this, new IdChangedEventArgs(oldValue, newValue));
                //IdCahanged?.Invoke(this, new IdChangedEventArgs(oldValue, newValue));//yukardakiyle aynı ıdchanged null değilse bunu çağır(invoke) demek.
            }
        }


        public event EventHandler<IdChangedEventArgs> IdCahanged = delegate { }; //IdChanged değişkeni hiç bir zaman null olmayacak boş bir delegate olacak değer almazsa
                                                                                 //public event EventHandler<IdChangedEventArgs> IdCahanged;//bu kullanımla beraber sadece 37.satır yeterli olur.

        #endregion
    }
        public class IdChangedEventArgs:EventArgs
        {
            public IdChangedEventArgs(long? oldValue,long? newValue)
            {
                OldValue = oldValue;
                NewValue = newValue;
            }
            public long? OldValue { get;}
            public long? NewValue { get;}
        }
}
