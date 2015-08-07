using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniDeb
{
     [Serializable()]
    class ConnectionArrayList
    {
        public ArrayList Conns { get; set; }


        public ConnectionArrayList() {
            this.Conns = new ArrayList();
        }

        //Deserialization constructor.
        public ConnectionArrayList(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            Conns = (ArrayList)info.GetValue("Conns", typeof(ArrayList));
           
        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Conns", Conns);
        }
    }
}
