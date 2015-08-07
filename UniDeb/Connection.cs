using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UniDeb
{
    [Serializable()]
    class Connection
    {
        public String Id { get; set; }
        public Boolean IsDefault { get; set; }
        public String Url { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

        public Connection(String id, Boolean isDefault, String url, String username, String password)
        {
            this.Id = id;
            this.IsDefault = isDefault;
            this.Url = url;
            this.Username = username;
            this.Password = password;
        }

        //Deserialization constructor.
        public Connection(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            Id = (String)info.GetValue("Id", typeof(string));
            IsDefault = (Boolean)info.GetValue("isDefault", typeof(Boolean));
            Url = (String)info.GetValue("Url", typeof(string));
            Username = (String)info.GetValue("Username", typeof(string));
            Password = (String)info.GetValue("Password", typeof(string));
        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("Id", Id);
            info.AddValue("IsDefault", IsDefault);
            info.AddValue("Url", Url);
            info.AddValue("Username", Username);
            info.AddValue("Password", Password);
        }

        public override string ToString()
        {
            return this.Url;
        }
    }
}

